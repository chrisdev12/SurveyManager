using Survey.WebService.Models;
using Survey.WebService.Tests.UnitTest.DataGenerators;
using Xunit;

namespace Survey.WebService.Tests.UnitTest.Models
{
    public class QuestionModelTest
    {
        [Theory]
        [MemberData(nameof(QuestionModelTestData.GetEqualQuestions), MemberType = typeof(QuestionModelTestData))]
        public void QuestionModels_AreEqual(QuestionModel originalObj, QuestionModel objToCompare)
        {
            bool areSurveyEquals = originalObj.Equals(objToCompare);

            Assert.True(areSurveyEquals);
        }

        [Theory]
        [MemberData(nameof(QuestionModelTestData.GetDifferentQuestions), MemberType = typeof(QuestionModelTestData))]
        public void QuestionModels_AreDifferent(QuestionModel originalObj, QuestionModel objToCompare)
        {
            bool areSurveyEquals = originalObj.Equals(objToCompare);

            Assert.False(areSurveyEquals);
        }
    }
}
