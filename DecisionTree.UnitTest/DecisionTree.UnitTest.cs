using DeeTree;

namespace DeeTreeSpec
{
    using Xunit;

    [Trait("given CTB Assessment when Nationality <- UK", "")]
    public class given_CTB_Assessment_when_Nationality_eq_UK
    {
        private IDecision _q;

        //private NationalityDecision _d;

        private IDecision nxt;

        public given_CTB_Assessment_when_Nationality_eq_UK()
        {
            // get a decisionTree with lambdas...
            _q = QuestionnaireFactory.GetCtbQuestionnaire();

            // get the next question, which is the first question
            var d1 = _q.GetNext(_q) as NationalityDecision;

            // poke answer on the mutator
            d1.Mutator(d1, new NationalityDecision { NationalityEnum = NationalityEnum.UK, Amount = 0.0f, Result = 1 });

            // get next question given the current state the assessment
            nxt = _q.GetFollowOnDecisionBranch(_q.Result);
        }

        [Fact(DisplayName = "then next question should be UkPart Decision")]
        public void then_next_question_should_be_UkPart()
        {
            // Assert
            Assert.IsType<UkPartDecision>(nxt);
        }
    }
}

namespace DeeTreeSpec
{
    using Xunit;

    [Trait("given CTB Assessment when Nationality <- UK and UkPart <- England", "")]
    public class given_CTB_Assessment_when_Nationality_eq_UK_and_UkPart_eq_England
    {
        private IDecision _q;

        private IDecision nxt;

        public given_CTB_Assessment_when_Nationality_eq_UK_and_UkPart_eq_England()
        {
            // get a decisionTree with lambdas...
            _q = QuestionnaireFactory.GetCtbQuestionnaire();

            // get the next question, which is the first question
            var d1 = _q.GetNext(_q) as NationalityDecision;

            // poke UK answer on the mutator
            d1.Mutator(d1, new NationalityDecision { NationalityEnum = NationalityEnum.UK, Amount = 0.0f, Result = 1 });

            // get next question given the current state the assessment
            var d2 = _q.GetFollowOnDecisionBranch(_q.Result);

            // poke UK answer on the mutator
            d2.Mutator(d2, new UkPartDecision { UkPartEnum = UkPartEnum.England, Amount = 0.0f, Result = 1 });

            // get next question given the current state the assessment
            nxt = d2.GetFollowOnDecisionBranch(_q.Result);

            /////////////////////////////////
            // REFACTOR  : asserting on d2 here but should be asserting on 1 ?....
        }

        [Fact(DisplayName = "then next question should be Income Decision")]
        public void then_next_question_should_be_UkPart()
        {
            // Assert
            Assert.IsType<CtbIncomeDecision>(nxt);
        }
    }
}