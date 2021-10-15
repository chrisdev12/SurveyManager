using Survey.WebService.Models;
using System.Collections.Generic;

namespace Survey.WebService.UnitTests.DataGenerators
{
    public class SurveyModelData
    {
        public static IEnumerable<object[]> GetEqualSurveys()
        {
            yield return new object[]
            {
                new SurveyModel()
                {
                    Id = "TestId",
                    Description = "Testing survey model"
                },
                new SurveyModel()
                {
                    Id = "TestId",
                    Description = "Testing survey model"
                }
            };
            yield return new object[]
            {
                new SurveyModel()
                {
                    Id = "TestId2",
                    Description = "Another Testing survey model"
                },
                new SurveyModel()
                {
                    Id = "TestId2",
                    Description = "Another Testing survey model"
                }
            };
        }

        public static IEnumerable<object[]> GetDifferentSurveys()
        {
            yield return new object[]
            {
                new SurveyModel()
                {
                    Id = "TestId",
                    Description = "Testing survey model"
                },
                new SurveyModel()
                {
                    Id = "TestId",
                    Description = "Testing survey model!"
                }
            };
            yield return new object[]
            {
                new SurveyModel()
                {
                    Id = "Test Id",
                    Description = "Testing survey model"
                },
                new SurveyModel()
                {
                    Id = "TestId",
                    Description = "Testing survey model!"
                }
            };
        }

        public static IEnumerable<object[]> SurveysWithIdLongerThan10Characters()
        {
            yield return new object[]
            {
                new SurveyModel()
                {
                    Id = "Testing is longer",
                    Description = "Testing survey model!"
                }
            };
            yield return new object[]
            {
                new SurveyModel()
                {
                    Id = "11Character",
                    Description = "Testing survey model!"
                }
            };
        }

        public static IEnumerable<object[]> SurveysWithIdLowerThan10Characters()
        {
            yield return new object[]
            {
                new SurveyModel()
                {
                    Id = "idValid",
                    Description = "Testing survey model"
                }
            };
            yield return new object[]
            {
                new SurveyModel()
                {
                    Id = "9character",
                    Description = "Testing survey model!"
                }
            };
        }
    }
}
