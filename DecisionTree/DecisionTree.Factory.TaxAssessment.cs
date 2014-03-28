namespace DeeTree
{
    using System;
    using System.Collections.Generic;

    public static class QuestionnaireFactory
    {
        public static IDecision GetCtbQuestionnaire()
        {
            // Code

            // decision and branches
            var ctbIncomeDecision = GetCtbIncomeDecision();

            // decision and branches
            var ukPartDecision = GetUkPartDecision(
                    branches: new Dictionary<int, IDecision>
                    {
                        {(int)UkPartEnum.England,ctbIncomeDecision}
                    }
                );

            // decision and branches
            var questionnaire = GetNationalityDecision(
                branches: new Dictionary<int, IDecision>
                    {
                        {(int)NationalityEnum.UK,ukPartDecision}
                    }
                );

            // Return
            return questionnaire;
        }

        public static Decision GetCtbIncomeDecision(Dictionary<int, IDecision> branches = null)
        {
            // default param
            branches = branches ?? new Dictionary<int, IDecision> { };

            // Code

            // question and decision
            Action<IDecision, IDecision> question = (d, answer) =>
            {
                var decision = d as CtbIncomeDecision;

                if (decision != null)
                {
                    // ask question
                    Console.WriteLine("{0}", decision.Question);
                    var ans = Console.ReadLine() ?? string.Empty;

                    // assign/calculate properties of the decision
                    decision.Amount = (float)Convert.ToInt32(ans);

                    //
                    var branchChoice = Convert.ToInt32(ans);
                    //var branchChoice = (int)1;
                    if (decision.Amount < 10)
                    {
                        decision.CtbIncomeEnum = CtbIncomeEnum.Below;
                        branchChoice = 1;
                    }
                    else
                    {
                        decision.CtbIncomeEnum = CtbIncomeEnum.Above;
                        branchChoice = 2;
                    }

                    // assign branch choice given users answers
                    decision.Result = branchChoice;
                }
            };
            var retd = new CtbIncomeDecision
            {
                Question = string.Format("[/1] {0} ?", Enum<CtbIncomeEnum>.EnumsStringSummary()),
                Mutator = question,
                Branches = branches
            };

            // Return
            return retd;
        }

        public static Decision GetNationalityDecision(Dictionary<int, IDecision> branches = null)
        {
            // default param
            branches = branches ?? new Dictionary<int, IDecision> { };

            // Code

            // question and decision
            Action<IDecision, IDecision> question = (d, a) =>
            {
                var decision = d as NationalityDecision;
                var answer = a as NationalityDecision;

                if (decision != null)
                {
                    // ask question
                    //var typ = decision.GetType();
                    //var typnm = typ.ToString();

                    var branchChoice = 0;

                    if (answer != null)
                    {
                        // automapper
                        decision.NationalityEnum = answer.NationalityEnum;
                        decision.Result = answer.Result;
                    }
                    else
                    {
                        Console.WriteLine("{0}", decision.Question);
                        var ans = Console.ReadLine() ?? string.Empty;
                        branchChoice = Convert.ToInt32(ans);

                        // assign/calculate properties of the decision
                        decision.NationalityEnum = (NationalityEnum)branchChoice;
                        //decision.Amount = 0f;

                        // assign branch choice given users answers
                        decision.Result = branchChoice;
                    }
                }
            };

            var retd = new NationalityDecision
            {
                Question = string.Format("[/1] {0} ?", Enum<NationalityEnum>.EnumsStringSummary()),
                Mutator = question,
                Branches = branches
            };

            // Return
            return retd;
        }

        public static Decision GetUkPartDecision(Dictionary<int, IDecision> branches = null)
        {
            // default param
            branches = branches ?? new Dictionary<int, IDecision> { };

            // Code

            // question and decision
            Action<IDecision, IDecision> question = (d, a) =>
            {
                var decision = d as UkPartDecision;
                var answer = a as UkPartDecision;

                if (decision != null)
                {
                    /////////////////
                    var branchChoice = 0;

                    if (answer != null)
                    {
                        // automapper
                        decision.UkPartEnum = answer.UkPartEnum;
                        decision.Result = answer.Result;
                    }
                    else
                    {
                        // ask question
                        Console.WriteLine("{0}", decision.Question);
                        var ans = Console.ReadLine() ?? string.Empty;

                        //var branchChoice = Convert.ToInt32(ans);
                        //var branchChoice = (int)1;

                        // assign/calculate properties of the decision
                        decision.UkPartEnum = (UkPartEnum)Convert.ToInt32(ans);
                        //decision.Amount = 7.4f;

                        // assign branch choice given users answers
                        decision.Result = branchChoice;
                    }
                    /// //////////////
                }
            };
            var retd = new UkPartDecision
            {
                Question = string.Format("[/1] {0} ?", Enum<UkPartEnum>.EnumsStringSummary()),
                Mutator = question,
                Branches = branches
            };

            // Return
            return retd;
        }
    }
}