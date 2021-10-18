using Survey.WebService.Models;
using System.Collections.Generic;

namespace Survey.WebService.UnitTests.DataGenerators
{
    public class GeneralQuestionServiceData
    {
        public static readonly List<QuestionModel> repositoryMockData = new List<QuestionModel>
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
            new QuestionModel
            {
                Id = "4",
                Description = "Fourth question",
                SurveyId = "surveyOne"
            }
        };

        public static readonly SurveyModel questionSurveyModel = new SurveyModel()
        {
            Id = "surveyOne",
            Description = "Testing survey",
        };

        public static IEnumerable<object[]> GetOnlyNewQuestions()
        {
            yield return new object[]
            {
                new List<QuestionModel>
                {
                    new QuestionModel
                    {
                         Id = "5",
                         Description = "First question",
                         SurveyId = "surveyOne"
                    },
                    new QuestionModel
                    {
                        Id = "6",
                        Description = "Second question",
                        SurveyId = "surveyOne"
                    },
                    new QuestionModel
                    {
                        Id = "7",
                        Description = "Third question",
                        SurveyId = "surveyOne"
                    },
                    new QuestionModel
                    {
                        Id = "8",
                        Description = "Fourth question",
                        SurveyId = "surveyOne"
                    }
                },
                questionSurveyModel
            };
            yield return new object[]
            {
                new List<QuestionModel>
                {
                    new QuestionModel
                    {
                         Id = "9",
                         Description = "First question",
                         SurveyId = "surveyOne"
                    },
                    new QuestionModel
                    {
                        Id = "10",
                        Description = "Second question",
                        SurveyId = "surveyOne"
                    },
                    new QuestionModel
                    {
                        Id = "11",
                        Description = "Third question",
                        SurveyId = "surveyOne"
                    },
                    new QuestionModel
                    {
                        Id = "12",
                        Description = "Fourth question",
                        SurveyId = "surveyOne"
                    }
                },
                questionSurveyModel
            };;
        }

        public static IEnumerable<object[]> GetAllTypesOfQuestions()
        {
            yield return new object[]
            {
                new List<QuestionModel>
                {
                    //UNCHAGED
                    new QuestionModel
                    {
                         Id = "1",
                         Description = "First question",
                         SurveyId = "surveyOne"
                    },
                    //NEW QUESTION
                    new QuestionModel
                    {
                        Id = "6",
                        Description = "Second question",
                        SurveyId = "surveyOne"
                    },
                    //UPDATED
                    new QuestionModel
                    {
                        Id = "3",
                        //UPDATED DESCRIPTION
                        Description = "FIELD WAS UPDATED",
                        SurveyId = "surveyOne"
                    },
                    //NEW QUESTION
                    new QuestionModel
                    {
                        Id = "8",
                        Description = "Fourth question",
                        SurveyId = "surveyOne"
                    }
                },
                questionSurveyModel
            };
            yield return new object[]
            {
                new List<QuestionModel>
                {
                    //NEW QUESTION
                    new QuestionModel
                    {
                         Id = "9",
                         Description = "First question",
                         SurveyId = "surveyOne"
                    },
                    //UPDATED
                    new QuestionModel
                    {
                        Id = "2",
                        Description = "FIELD WAS UPDATED",
                        SurveyId = "surveyOne"
                    },
                    //NEW QUESTION
                    new QuestionModel
                    {
                        Id = "10",
                        Description = "Another new question",
                        SurveyId = "surveyOne"
                    },
                    //UNCHANGED
                    new QuestionModel
                    {
                        Id = "4",
                        Description = "Fourth question",
                        SurveyId = "surveyOne"
                    }
                },
                questionSurveyModel
            }; ;
        }

        public static IEnumerable<object[]> GetOnlyQuestionsAlreadyRegisteredBThatShouldBeUpdated()
        {
            yield return new object[]
            {
                //All list Already registered: same as repository, only change description (should be updated)
                new List<QuestionModel>
                {
                    new QuestionModel
                    {
                         Id = "1",
                         Description = "First question change",
                         SurveyId = "surveyOne"
                    },
                    new QuestionModel
                    {
                        Id = "2",
                        Description = "Second question change",
                        SurveyId = "surveyOne"
                    },
                    new QuestionModel
                    {
                        Id = "3",
                        Description = "Third question change",
                        SurveyId = "surveyOne"
                    },
                    new QuestionModel
                    {
                        Id = "4",
                        Description = "Fourth question change",
                        SurveyId = "surveyOne"
                    }
                },
                questionSurveyModel
            };
            yield return new object[]
            {
                 new List<QuestionModel>
                {
                    new QuestionModel
                    {
                         Id = "1",
                         Description = "First question updated",
                         SurveyId = "surveyOne"
                    },
                    new QuestionModel
                    {
                        Id = "2",
                        Description = "Second question updated",
                        SurveyId = "surveyOne"
                    },
                    new QuestionModel
                    {
                        Id = "3",
                        Description = "Third question updated",
                        SurveyId = "surveyOne"
                    },
                    new QuestionModel
                    {
                        Id = "4",
                        Description = "Fourth question updated",
                        SurveyId = "surveyOne"
                    }
                },
                questionSurveyModel
            };
        }

        public static IEnumerable<object[]> GetOnlyUnchagedQuestions()
        {
            yield return new object[]
            {
                repositoryMockData,
                questionSurveyModel
            };
            yield return new object[]
            {
                repositoryMockData,
                questionSurveyModel
            }; ;
        }
    }
}
