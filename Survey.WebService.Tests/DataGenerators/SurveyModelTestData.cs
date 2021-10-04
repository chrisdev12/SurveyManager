using Survey.WebService.Models;
using System.Collections.Generic;

namespace Survey.WebService.Tests.UnitTest.DataGenerators
{
    public class SurveyModelTestData
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
    }
}
