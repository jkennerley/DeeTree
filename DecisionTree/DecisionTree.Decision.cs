using System;
using System.Collections.Generic;
using System.Linq;

namespace DeeTree
{
    public class Decision : IDecision
    {
        public int Result { get; set; }

        public float Amount { get; set; }

        public string Question { get; set; }

        public Action<IDecision, IDecision> Mutator { get; set; }

        public Dictionary<int, IDecision> Branches { get; set; }

        public IDecision EvaluateNextOneGetFollowOnBranch(IDecision questionnaire)
        {
            IDecision q = questionnaire;
            if (q.Result == 0)
            {
                q.Mutator(q, null);
            }
            var nxt = q.GetFollowOnDecisionBranch(q.Result);
            q = nxt;
            return q;
        }

        public IDecision Evaluate()
        {
            // ask the user to make choices
            if (Result == 0)
            {
                Mutator(this, null);
            }

            // given the user choices, get the next question branch to go down
            var followOnBranch = this.GetFollowOnDecisionBranch(Result);

            // Return, by evaluating the next follow-on branch OR null of there is no follow on branch
            return ((followOnBranch != null) ? followOnBranch.Evaluate() : null);
        }

        public virtual string GetDecisionSummary()
        {
            // Code
            var ret = String.Format(
                "Question: {0} ; Result: {1}; Amount:{2};{3}"
                , Question
                , Result
                , Amount
                , Environment.NewLine);

            // Return
            return ret;
        }

        public List<IDecision> ChosenOnes(List<IDecision> chosenBranches)
        {
            // Code

            // default return value of null
            chosenBranches = chosenBranches ?? new List<IDecision>();

            // default the return
            chosenBranches.Add(this);

            // get the summary text for this decision node
            var followOnBranch = this.GetFollowOnDecisionBranch(Result);
            if (followOnBranch != null)
            {
                followOnBranch.ChosenOnes(chosenBranches);
            }

            // Return
            return chosenBranches;
        }

        public string Explantion()
        {
            // Code
            var chosenOnes = ChosenOnes(null);

            // summary of the users answers to the questions
            var explanation = string.Empty;
            explanation = chosenOnes.Aggregate(explanation, (current, chosenOne) => current + chosenOne.GetDecisionSummary());

            // Return
            return explanation;
        }

        public IDecision GetNext(IDecision d)
        {
            // Code
            if (d.Result == (int)DeeTree.BranchChoiceEnum.NotKnown)
            {
                return d;
            }
            else
            {
                return GetNext(this.GetFollowOnDecisionBranch(Result));
            }
        }
    }
}