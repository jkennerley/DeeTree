using System;
using System.Collections.Generic;

namespace DeeTree
{
    public interface IDecision
    {
        int Result { get; set; }

        float Amount { get; set; }

        string Question { get; set; }

        Action<IDecision, IDecision> Mutator { get; set; }

        Dictionary<int, IDecision> Branches { get; set; }

        IDecision Evaluate();

        string GetDecisionSummary();

        List<IDecision> ChosenOnes(List<IDecision> branches);

        IDecision GetNext(IDecision d);

        IDecision EvaluateNextOneGetFollowOnBranch(IDecision questionnaire);

        string Explantion();
    }
}

namespace DeeTree
{
    // Utility enum for when the branches are just {L|R} or {No|Yes}
    // makes code slightly clearer for a questionnaire when simply {Positive, Negative} or {Left, Right} or { False,True} choices
    public enum BranchChoiceEnum
    {
        NotKnown = 0,
        BranchA = 1,
        BranchB = 2,
    }
}