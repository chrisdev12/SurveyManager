using Survey.WebService.Models;
using Survey.WebService.Tests.UnitTest.DataGenerators;
using Xunit;

namespace Survey.WebService.Tests.UnitTest.Models
{
    public class SurveyModelTest
    {
        [Theory]
        [MemberData(nameof(SurveyModelTestData.GetEqualSurveys), MemberType =typeof(SurveyModelTestData))]
        public void SurveyModels_AreEqual(SurveyModel originalObj, SurveyModel objToCompare)
        {
            bool areSurveyEquals = originalObj.Equals(objToCompare);

            Assert.True(areSurveyEquals);
        }

        [Theory]
        [MemberData(nameof(SurveyModelTestData.GetDifferentSurveys), MemberType = typeof(SurveyModelTestData))]
        public void SurveyModels_AreDifferent(SurveyModel originalObj, SurveyModel objToCompare)
        {
            bool areSurveyEquals = originalObj.Equals(objToCompare);

            Assert.False(areSurveyEquals);
        }
    }
}
