using DeeTree;

namespace DeeTree
{
    using System;

    public enum CtbIncomeEnum
    {
        Below = 1,
        Above = 2
    }

    public class CtbIncomeDecision : Decision
    {
        public CtbIncomeEnum CtbIncomeEnum { get; set; }

        public override string GetDecisionSummary()
        {
            return String.Format("{4} {3} {0}"
                , Environment.NewLine
                , Question
                , Result
                , Amount
                , CtbIncomeEnum
                );
        }
    }

    public enum NationalityEnum
    {
        UK = 1,
        US = 2,
        Aus = 3
    }

    public class NationalityDecision : Decision
    {
        public NationalityEnum NationalityEnum { get; set; }

        public override string GetDecisionSummary()
        {
            return String.Format(
                "Branch:{4} : {1} ; Enum: {3} ;{0}"
                , Environment.NewLine
                , GetType().ToString()
                , Question
                , NationalityEnum
                , Result
                , Amount
                );
        }
    }

    public enum UkPartEnum
    {
        England = 1,
        NI = 2,
        Wales = 3,
        Scotland = 5
    }

    public class UkPartDecision : Decision
    {
        public UkPartEnum UkPartEnum { get; set; }

        public override string GetDecisionSummary()
        {
            return String.Format(
                "Branch:{4} : {1} ; Enum: {3} ;{0}"
                , Environment.NewLine
                , GetType().ToString()
                , Question
                , UkPartEnum
                , Result
                , Amount
                );
        }
    }
}

namespace DecisionTree.ClientModels
{
    using System;

    public enum SandwichFillTypeEnum
    {
        Salad = 1, Cheese = 2, Ham = 3
    }

    public class SandwichFillDecision : Decision
    {
        public SandwichFillTypeEnum SandwichFillType { get; set; }

        public override string GetDecisionSummary()
        {
            return String.Format(
                "Branch:{4} : {1} ; Enum: {3} ;{0}"
                , Environment.NewLine
                , GetType().ToString()
                , Question
                , SandwichFillType
                , Result
                , Amount
                );
        }
    }

    public enum CakeTypeEnum
    {
        Choc = 1, Vanilla = 2
    }

    public class CakeTypeDecision : Decision
    {
        public CakeTypeEnum CakeType { get; set; }

        public override string GetDecisionSummary()
        {
            return String.Format(
                "Branch:{4} : {1} ; Enum: {3} ;{0}"
                , Environment.NewLine
                , GetType().ToString()
                , Question
                , CakeType
                , Result
                , Amount
                );
        }
    }

    public enum FatSpreadEnum
    {
        Margarine = 1, Butter = 2
    }

    public class FatSpreadDecision : Decision
    {
        public FatSpreadEnum FatSpread { get; set; }

        public override string GetDecisionSummary()
        {
            return String.Format(
                "Branch:{4} : {1} ; Enum: {3} ;{0}"
                , Environment.NewLine
                , GetType().ToString()
                , Question
                , FatSpread
                , Result
                , Amount
                );
        }
    }

    public enum BreadTypeEnum
    {
        Brown = 1, White = 2, Wholemeal = 3, Rye = 20
    }

    public class BreadTypeDecision : Decision
    {
        public BreadTypeEnum BreadType { get; set; }

        public override string GetDecisionSummary()
        {
            return String.Format(
                "Branch:{4} : {1} ; Enum: {3} ;{0}"
                , Environment.NewLine
                , GetType().ToString()
                , Question
                , BreadType
                , Result
                , Amount
                );
        }
    }

    public enum ProductEnum
    {
        Sandwich = 1,
        Cake = 2,
        Curry = 4
    }

    public class CornerShopStartDecision : Decision
    {
        public ProductEnum ProductEnum { get; set; }

        public override string GetDecisionSummary()
        {
            return String.Format(
                "Branch:{4} : {1} ; Enum: {3} ;{0}"
                , Environment.NewLine
                , GetType().ToString()
                , Question
                , ProductEnum
                , Result
                , Amount
                );
        }
    }
}