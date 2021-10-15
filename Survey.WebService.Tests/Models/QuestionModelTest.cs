using Survey.WebService.Models;
using Survey.WebService.UnitTests.DataGenerators;
using Xunit;

namespace Survey.WebService.UnitTests.Models
{
    public class QuestionModelTest
    {
        [Theory]
        //Arrange
        [MemberData(nameof(QuestionModelData.GetEqualQuestions), MemberType = typeof(QuestionModelData))]
        public void QuestionModels_AreEqual(QuestionModel originalObj, QuestionModel objToCompare)
        {
            //Act
            bool areSurveyEquals = originalObj.Equals(objToCompare);

            //Assertion
            Assert.True(areSurveyEquals);
        }

        [Theory]
        //Arrange
        [MemberData(nameof(QuestionModelData.GetDifferentQuestions), MemberType = typeof(QuestionModelData))]
        public void QuestionModels_AreDifferent(QuestionModel originalObj, QuestionModel objToCompare)
        {
            //Act
            bool areSurveyEquals = originalObj.Equals(objToCompare);

            //Assertion
            Assert.False(areSurveyEquals);
        }
    }
}
