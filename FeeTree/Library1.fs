namespace FeeTree

open Xunit

type Client ={
    Name:string
    Income:int
    YearsInJob:int
    UsesCreditCard:bool
    CriminalRecord:bool
}

type QueryInfo = 
    {Title : string
     Check : Client->bool
     Positive : Decision
     Negative : Decision
    }
and Decision = 
    | Result of string 
    | Query of QueryInfo

module FeeTreeEvaluator =
    let rec testClientTree(client, tree) = 
        match tree with 
        | Result(message) -> printfn "offer loan %s" message
        | Query(qinfo) ->
            let result,case  =
                if(qinfo.Check(client)) then "yes", qinfo.Positive
                else "no" , qinfo.Negative
            printfn " - %s ? %s" qinfo.Title result
            testClientTree(client, case)

type ``Fee Tree Spec``() = 

    [<Fact>]
    member this.``f# decision treee basic``() = 

        let rec tree = 
            Query({ Title="More than 40K"
                    Check = (fun cl -> cl.Income > 40000 )
                    Positive = moreThan40;Negative = lessThan40})
        and moreThan40 = 
            Query({ Title="criminal record ?"
                    Check = (fun cl -> cl.CriminalRecord )
                    Positive = Result("NO");Negative = Result("YES")})
        and lessThan40 = 
            Query({ Title="Years in job ?"
                    Check = (fun cl -> cl.YearsInJob >1  )
                    Positive = Result("YES");Negative = usesCredit})
        and usesCredit = 
            Query({ Title="uses credit ?"
                    Check = (fun cl -> cl.UsesCreditCard   )
                    Positive = Result("YES");Negative = Result("NO")})

        let john  = {Name="John";Income=39000;CriminalRecord=true;YearsInJob=0;UsesCreditCard=false}

        FeeTreeEvaluator.testClientTree (john ,tree)

        System.Console.WriteLine(".")

        Assert.True |> ignore
        ()


