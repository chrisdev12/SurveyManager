using Survey.WebService.Models;
using Survey.WebService.Models.DTOs;
using System.Collections.Generic;

namespace Survey.WebService.UnitTests.DataGenerators
{
    public class MemberAnswerServiceData
    {
        public static readonly List<QuestionModel> answersMockData = new List<QuestionModel>
        {
            new QuestionModel
            {
                 Id = "1",
                 Description = "First question",
                 SurveyId = "surveyOne"
            },
            new QuestionModel
            {
                Id = "2",
                Description = "Second question",
                SurveyId = "surveyOne"
            },
            new QuestionModel
            {
                Id = "3",
                Description = "Third question",
                SurveyId = "surveyOne"
            },
        };

        public static IEnumerable<object[]> GetAllInvalidAnswers()
        {
            yield return new object[]
            {
                new GeneralSurveyRequestDTO
                {
                    Survey = new SurveyModel(),
                    Questions = answersMockData,
                    Answers = new List<AnswerModel>
                    {
                        new AnswerModel
                        {
                            AnswerId = "4",
                            Description = "Lorem opisum",
                            PhoneDigit = "1"
                        },
                        new AnswerModel
                        {
                            AnswerId = "5",
                            Description = "Lorem five ipsum",
                            PhoneDigit = "2"
                        },

                    },
                    MemberInfo = new MemberModel(),
                },
            };
            yield return new object[]
            {
                new GeneralSurveyRequestDTO
                {
                    Survey = new SurveyModel(),
                    Questions = answersMockData,
                    Answers = new List<AnswerModel>
                    {
                        new AnswerModel
                        {
                            AnswerId = "10",
                            Description = "Lorem sad opisum",
                            PhoneDigit = "3"
                        },
                        new AnswerModel
                        {
                            AnswerId = "7",
                            Description = "Lorem opisum",
                            PhoneDigit = "1"
                        },

                    },
                    MemberInfo = new MemberModel(),
                },
            };
        }

        //Valid answer means: AnswerId match with a question ID that exist.
        public static IEnumerable<object[]> GetAllValidAnswers()
        {
            yield return new object[]
            {
                new GeneralSurveyRequestDTO
                {
                    Survey = new SurveyModel(),
                    Questions = answersMockData,
                    Answers = new List<AnswerModel>
                    {
                        new AnswerModel
                        {
                            AnswerId = "1",
                            Description = "Lorem opisum",
                            PhoneDigit = "1"
                        },
                        new AnswerModel
                        {
                            AnswerId = "3",
                            Description = "Lorem five ipsum",
                            PhoneDigit = "2"
                        },

                    },
                    MemberInfo = new MemberModel(),
                },
            };
            yield return new object[]
            {
                new GeneralSurveyRequestDTO
                {
                    Survey = new SurveyModel(),
                    Questions = answersMockData,
                    Answers = new List<AnswerModel>
                    {
                        new AnswerModel
                        {
                            AnswerId = "2",
                            Description = "Lorem sad opisum",
                            PhoneDigit = "3"
                        },
                        new AnswerModel
                        {
                            AnswerId = "3",
                            Description = "Lorem opisum",
                            PhoneDigit = "1"
                        },
                        new AnswerModel
                        {
                            AnswerId = "1",
                            Description = "Lorem opisum",
                            PhoneDigit = "1"
                        },

                    },
                    MemberInfo = new MemberModel(),
                },
            };
        }
    }
}
