using DecisionTree.ClientModels;
using DeeTree;
using System;
using System.Collections.Generic;

namespace DeeTreeFactory
{
    public static class CornerShopQuestionnaireFactory
    {
        public static Decision GetCornerShopQuestionnaire()
        {
            // Code

            // bread type decision and branches
            var breadTypeDecision = GetBreadTypeDecision();

            // decision and branches
            var fatSpreadDecision =
                GetFatSpreadTypeDecision(
                    branches: new Dictionary<int, IDecision> { { 1, breadTypeDecision } }
                );

            // decision and branches
            var sandwichDecision = GetSandwichDecision(
                branches: new Dictionary<int, IDecision> { { 1, fatSpreadDecision } }
            );

            // decision and branches
            var cakeDecision = GetCakeDecision();

            // decision and branches
            var questionnaire = GetCornerShopStartDecision(
                //branches: new List<IDecision> { sandwichDecision, cakeDecision }
                branches: new Dictionary<int, IDecision> { { 1, sandwichDecision }, { 2, cakeDecision } }
            );

            // Return
            return questionnaire;
        }

        public static Decision GetCornerShopStartDecision(Dictionary<int, IDecision> branches = null)
        {
            // default param
            branches = branches ?? new Dictionary<int, IDecision> { };

            // question and decision
            Action<IDecision, IDecision> cornerShopProductQuestion = (d, a) =>
            {
                var decision = d as CornerShopStartDecision;

                if (decision != null)
                {
                    // ask question
                    Console.WriteLine("{0}", decision.Question);
                    var ans = Console.ReadLine() ?? string.Empty;

                    // branch choice ...
                    var branchChoice = Convert.ToInt32(ans);
                    //var branchChoice = (int)BranchChoiceEnum.NotKnown;

                    // assign/calculate properties of the decision
                    decision.ProductEnum = (ProductEnum)branchChoice;
                    decision.Amount = 3.2f;

                    // assign branch choice given users answers
                    decision.Result = branchChoice;
                }
            };

            var questionnaire = new CornerShopStartDecision
            {
                Question = string.Format("[/1] {0} ?", Enum<ProductEnum>.EnumsStringSummary()),
                Mutator = cornerShopProductQuestion,
                Branches = branches
            };

            return questionnaire;
        }

        public static Decision GetCakeDecision(Dictionary<int, IDecision> branches = null)
        {
            // default param
            branches = branches ?? new Dictionary<int, IDecision> { };

            Action<IDecision, IDecision> cakeQuestion = (d, a) =>
            {
                var decision = d as CakeTypeDecision;

                if (decision != null)
                {
                    // ask question
                    Console.WriteLine("{0}", decision.Question);
                    var ans = Console.ReadLine() ?? string.Empty;

                    // branch choice ...
                    //var branchChoice = Convert.ToInt32(ans);
                    var branchChoice = (int)BranchChoiceEnum.NotKnown;

                    // assign/calculate properties of the decision
                    decision.CakeType = (CakeTypeEnum)Convert.ToInt32(ans);
                    decision.Amount = 3.2f;

                    // assign branch choice given users answers
                    decision.Result = branchChoice;
                }
            };

            var cakeDecision = new CakeTypeDecision
            {
                Question = string.Format("[/1] {0} ?", Enum<CakeTypeEnum>.EnumsStringSummary()),
                Mutator = cakeQuestion,
                Branches = branches
            };

            return cakeDecision;
        }

        public static Decision GetSandwichDecision(Dictionary<int, IDecision> branches = null)
        {
            // default param
            branches = branches ?? new Dictionary<int, IDecision> { };

            // Code

            // question and decision
            Action<IDecision, IDecision> q = (d, a) =>
            {
                var decision = d as SandwichFillDecision;

                if (decision != null)
                {
                    // ask question
                    Console.WriteLine("{0}", decision.Question);
                    var ans = Console.ReadLine() ?? string.Empty;

                    // branch choice ...
                    var branchChoice = Convert.ToInt32(ans);
                    branchChoice = (int)BranchChoiceEnum.BranchA;

                    // assign/calculate properties of the decision
                    decision.SandwichFillType = (SandwichFillTypeEnum)Convert.ToInt32(ans);
                    decision.Amount = 3.2f;

                    // assign branch choice given users answers
                    decision.Result = branchChoice;
                }
            };
            var sandwichDecision = new SandwichFillDecision
            {
                Question = string.Format("[/1] {0} ?", Enum<SandwichFillTypeEnum>.EnumsStringSummary()),
                Mutator = q,
                Branches = branches
            };

            // Return
            return sandwichDecision;
        }

        public static Decision GetFatSpreadTypeDecision(Dictionary<int, IDecision> branches = null)
        {
            // default param
            branches = branches ?? new Dictionary<int, IDecision> { };

            // question and decision
            Action<IDecision, IDecision> question = (d, a) =>
            {
                var decision = d as FatSpreadDecision;

                if (decision != null)
                {
                    // ask question
                    Console.WriteLine("{0}", decision.Question);
                    var ans = Console.ReadLine() ?? string.Empty;

                    // branch choice ...
                    //var branchChoice = Convert.ToInt32(ans);
                    var branchChoice = (int)BranchChoiceEnum.BranchA;

                    // assign/calculate properties of the decision
                    decision.FatSpread = (FatSpreadEnum)Convert.ToInt32(ans);
                    //decision.Amount = 5.3f * (int)decision.FatSpread;
                    decision.Amount = 5.3f;

                    // assign branch choice given users answers
                    decision.Result = branchChoice;
                }
            };
            var fatSpreadDecision = new FatSpreadDecision
            {
                Question = string.Format("[/1] {0} ?", Enum<FatSpreadEnum>.EnumsStringSummary()),
                Mutator = question,
                Branches = branches
            };

            //
            return fatSpreadDecision;
        }

        public static Decision GetBreadTypeDecision(Dictionary<int, IDecision> branches = null)
        {
            // default param
            branches = branches ?? new Dictionary<int, IDecision> { };

            // Code

            // question and decision
            Action<IDecision, IDecision> question = (d, a) =>
            {
                var decision = d as BreadTypeDecision;

                if (decision != null)
                {
                    // ask question
                    Console.WriteLine("{0}", decision.Question);
                    var ans = Console.ReadLine() ?? string.Empty;

                    //var branchChoice = Convert.ToInt32(ans);
                    var branchChoice = (int)BranchChoiceEnum.BranchA;

                    // assign/calculate properties of the decision
                    decision.BreadType = (BreadTypeEnum)Convert.ToInt32(ans);
                    decision.Amount = 7.4f;

                    // assign branch choice given users answers
                    decision.Result = branchChoice;
                }
            };
            var breadTypeDecision = new BreadTypeDecision
            {
                Question = string.Format("[/1] {0} ?", Enum<BreadTypeEnum>.EnumsStringSummary()),
                Mutator = question,
                Branches = branches
            };

            // Return
            return breadTypeDecision;
        }
    }
}