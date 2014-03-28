using System;

namespace DeeTree
{
    public static class DecisionExtension
    {
        public static IDecision GetFollowOnDecisionBranch(this IDecision decision, int key)
        {
            // the following decision-node to exec if any ...
            IDecision followOn = null;

            // which branch to go down ? Note : user choices on on [1,2,3...] but the index is zero based, therefore take away 1
            var index = key;

            if (decision.Branches.ContainsKey(index))
            {
                followOn = decision.Branches[index];
            }

            // Return
            return followOn;
        }
    }

    public static class BranchChoiceEnumExtension
    {
        public static int ToNodeChoiceEnum(this string ans)
        {
            // Code

            // default value is NotKnown-0
            var ret = (int)DeeTree.BranchChoiceEnum.NotKnown;

            // e.g. convert text "1" to an int32 1
            if (!String.IsNullOrWhiteSpace(ans))
            {
                // REFACTOR : assume ans can be turned into a int32 !
                ret = Convert.ToInt32(ans.Trim());
            }

            // Return
            return ret;
        }
    }
}