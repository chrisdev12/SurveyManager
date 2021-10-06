using Survey.WebService.Models;
using Survey.WebService.Tests.UnitTest.DataGenerators;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Survey.WebService.Tests.UnitTest.Models
{
    public class SurveyModelTest
    {
        [Theory]
        //Arrange
        [MemberData(nameof(SurveyModelData.GetEqualSurveys), MemberType =typeof(SurveyModelData))]
        public void ValidateSurveyModels_AreEqual(SurveyModel originalObj, SurveyModel objToCompare)
        {
            //Act
            bool areSurveyEquals = originalObj.Equals(objToCompare);

            //Assert
            Assert.True(areSurveyEquals);
        }

        [Theory]
        //Arrange
        [MemberData(nameof(SurveyModelData.GetDifferentSurveys), MemberType = typeof(SurveyModelData))]
        public void ValidateSurveyModels_AreDifferent(SurveyModel originalObj, SurveyModel objToCompare)
        {
            //Act
            bool areSurveyEquals = originalObj.Equals(objToCompare);

            //Assert
            Assert.False(areSurveyEquals);
        }

        // Summary:
        //     cUrrently the max lenght allowed is 10 characters for the ID.

        [Theory]
        //Arrange
        [MemberData(nameof(SurveyModelData.SurveysWithIdLongerThan10Characters), MemberType = typeof(SurveyModelData))]
        public void IfSurveyIdExceedsTheLimitOfCharacters_RequestIsInvalid(SurveyModel surveyRequest)
        {
            //Act
            var modelErrors = ValidateModel(surveyRequest);

            //Assert
            Assert.True(modelErrors.Count == 1);
        }

        [Theory]
        //Arrange
        [MemberData(nameof(SurveyModelData.SurveysWithIdLowerThan10Characters), MemberType = typeof(SurveyModelData))]
        public void IfSurveyIdDontExceedsTheLimitOfCharacters_RequestIsValid(SurveyModel surveyRequest)
        {
            //Act
            var modelErrors = ValidateModel(surveyRequest);

            //Assert
            Assert.True(modelErrors.Count == 0);
        }

        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);

            return validationResults;
        }
    }
}
