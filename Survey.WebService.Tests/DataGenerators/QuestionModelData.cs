using Survey.WebService.Models;
using System.Collections.Generic;

namespace Survey.WebService.Tests.UnitTest.DataGenerators
{
    public class QuestionModelData
    {
        public static IEnumerable<object[]> GetEqualQuestions()
        {
            yield return new object[]
            {
                new QuestionModel()
                {
                    Id = "TestId",
                    Description = "Testing survey model",
                    SurveyId = "surveyIdEqual"
                },
                new QuestionModel()
                {
                    Id = "TestId",
                    Description = "Testing survey model",
                    SurveyId = "surveyIdEqual"
                }
            };
            yield return new object[]
            {
                new QuestionModel()
                {
                    Id = "TestId2",
                    Description = "Another Testing survey model",
                    SurveyId = "surveyIdEqual2"
                },
                new QuestionModel()
                {
                    Id = "TestId2",
                    Description = "Another Testing survey model",
                    SurveyId = "surveyIdEqual2"
                }
            };
        }

        public static IEnumerable<object[]> GetDifferentQuestions()
        {
            yield return new object[]
            {
                new QuestionModel()
                {
                    Id = "TestId",
                    Description = "Testing survey model",
                    SurveyId = "surveyIdEqual"
                },
                new QuestionModel()
                {
                    Id = "TestId",
                    Description = "Testing survey model!",
                    SurveyId = "surveyIdEqual"
                }
            };
            yield return new object[]
            {
                new QuestionModel()
                {
                    Id = "Test Id",
                    Description = "Testing survey model",
                    SurveyId = "surveyIdEqual"
                },
                new QuestionModel()
                {
                    Id = "TestId",
                    Description = "Testing survey model!",
                    SurveyId = "surveyIdEqual"
                }
            };
            yield return new object[]
            {
                new QuestionModel()
                {
                    Id = "TestId",
                    Description = "Testing survey model",
                    SurveyId = "surveyIdEqual"
                },
                new QuestionModel()
                {
                    Id = "TestId",
                    Description = "Testing survey model",
                    SurveyId = "surveyIdNotEqual"
                }
            };
        }
    }
}
