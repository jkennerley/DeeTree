using System.Linq;
using DeeTree;
using System;
using DeeTreeFactory;

namespace DeeTreeTasks
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ////////////////////////////////////
            // Decision tree with mutating lambda methods. could have multiple 2 or more branches for the follow-on branches.
            // The TemplateMethod pattern, ... {TemplateMethod is called the Evaluate() function of Decision class}
            // The TemplateMethod pattern, ... {PrimitiveOperation is the property called Decision.Mutator and of type Action<IDecision> }
            // The PrimitiveOperation is Action<IDecision> not Func<Client,bool> because it's responsibility is not just to choose {Positive|Negative}, it also may calculate state changes as well, hence Decisions will are carrying and mutating state

            ////////////////////////////////////
            // branches as Dictionary<int-enum, IDecision>
            //Console.WriteLine("ctb  ...");
            //doCtbQuestionnaireDemo();

            ////////////////////////////////////
            Console.WriteLine("corner shop purchase ...");
            doCornerShopQuestionnaireDemo();
        }

        private static void doCtbQuestionnaireDemo()
        {
            // get a decisionTree with lambdas...
            var questionnaire = QuestionnaireFactory.GetCtbQuestionnaire();

            if (questionnaire != null)
            {
                questionnaire.Evaluate();
            }

            var explanation = questionnaire.Explantion();
            Console.WriteLine("{0}", explanation);

            Console.ReadLine();
        }

        private static void doCornerShopQuestionnaireDemo()
        {
            // get a decisionTree with lambdas...
            var questionnaire = CornerShopQuestionnaireFactory.GetCornerShopQuestionnaire();

            #region Commented : setting a 'canned' answer on the root of the questionnaire

            //var startDecision = questionnaire.GetNext(questionnaire) as CornerShopStartDecision;
            //if (startDecision != null)
            //{
            //    startDecision.Result = 1;
            //}

            #endregion Commented : setting a 'canned' answer on the root of the questionnaire

            Console.ReadLine();

            #region Evaluation at the console

            // 1. Evaluate all at the console ...
            //questionnaire.Evaluate();

            #endregion Evaluation at the console

            #region Evaluation at the console 1-by-1

            // 2. Evaluate current and then next one until no more next ones ...
            //IDecision q = questionnaire;
            //while ( q != null)
            //{
            //    q = q.EvaluateNextOneGetFollowOnBranch(q);
            //}

            #endregion Evaluation at the console 1-by-1

            #region Evaluation at the console

            // 3. Evaluating one at a time, with access to the mutator
            IDecision q = questionnaire;
            while (q != null)
            {
                if (q.Result == 0)
                {
                    q.Mutator(q, null);
                }

                var nxt = q.GetFollowOnDecisionBranch(q.Result);
                q = nxt;
            }

            #endregion Evaluation at the console

            #region Explanation of the choices

            // cw summary of the users answers to the questions
            var explanation = questionnaire.Explantion();
            Console.WriteLine("{0}", explanation);

            #endregion Explanation of the choices

            #region Cost associated with the questionnaire user choices

            // cw the cost associated with answers to the questions
            var chosenOnes = questionnaire.ChosenOnes(null);
            var cost = chosenOnes.Aggregate(0.0f, (current, chosenOne) => current + chosenOne.Amount);
            Console.WriteLine("cost: {0}", cost);

            #endregion Cost associated with the questionnaire user choices

            // press a key to continue
            Console.ReadLine();
        }
    }
}