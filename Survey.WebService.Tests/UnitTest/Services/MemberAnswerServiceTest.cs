using Moq;
using Survey.WebService.Models;
using Survey.WebService.Models.DTOs;
using Survey.WebService.Repository;
using Survey.WebService.Services;
using Survey.WebService.Tests.DataGenerators;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Survey.WebService.Tests.UnitTest.Services
{
    public class MemberAnswerServiceTest
    {
        //
        // Summary:
        //     A valid answer is considered to be one whose ID is equal to the id in the list of questions.
        //     The reason for this lies in the business logic, the AnswerId of each answer in the request
        //     identifies which question it refers to, and in the database, the primary key of the table where the answer
        //     will be inserted, is a composite key between the question id and answer id, so if there is no match,
        //     the insertion would generate an error: however the service already does the validation.

        [Theory]
        [MemberData(nameof(MemberAnswerServiceData.GetAllInvalidAnswers), MemberType = typeof(MemberAnswerServiceData))]
        public async Task AllAnswersAreInvalid_DontRegisterAnyone(GeneralSurveyRequestDTO surveyRequestDTO)
        {
            //Arrange
            var questionMockRepository = new Mock<IMemberRepository>();
            questionMockRepository
                .Setup(service => service.Register(It.IsAny<MemberResultDTO>()))
                .Returns(Task.FromResult("registerd"));
            MemberAnswerService _memberAnswerService = new MemberAnswerService(questionMockRepository.Object);

            //Act
            await _memberAnswerService.UpdateOrCreate(surveyRequestDTO);

            //Assert
            questionMockRepository.Verify(service => service.Register(It.IsAny<MemberResultDTO>()), Times.Never());
        }

        [Theory]
        [MemberData(nameof(MemberAnswerServiceData.GetAllValidAnswers), MemberType = typeof(MemberAnswerServiceData))]
        public async Task AllAnswersAreValid_RegisterAll(GeneralSurveyRequestDTO surveyRequestDTO)
        {
            //Arrange
            var questionMockRepository = new Mock<IMemberRepository>();
            questionMockRepository
                .Setup(service => service.Register(It.IsAny<MemberResultDTO>()))
                .Returns(Task.FromResult("registerd"));
            MemberAnswerService _memberAnswerService = new MemberAnswerService(questionMockRepository.Object);

            //Act
            await _memberAnswerService.UpdateOrCreate(surveyRequestDTO);

            //Assert
            questionMockRepository.Verify(service => service.Register(It.IsAny<MemberResultDTO>()), Times.Exactly(surveyRequestDTO.Answers.Count));
        }


        // Summary: Remember that valid are the answers that match with a Id of a questionModel
        // QuestionModel list is mocket on MemberAnswerServiceData class
        [Fact]
        public async Task SomeAnswersAreValid_OnlyRegisterThose()
        {
            //Arrange
            var questionMockRepository = new Mock<IMemberRepository>();
            questionMockRepository
                .Setup(service => service.Register(It.IsAny<MemberResultDTO>()))
                .Returns(Task.FromResult("registerd"));
            MemberAnswerService _memberAnswerService = new MemberAnswerService(questionMockRepository.Object);
            var surveyRequest = new GeneralSurveyRequestDTO
            {
                Survey = new SurveyModel(),
                Questions = MemberAnswerServiceData.answersMockData,
                Answers = new List<AnswerModel>
                    {
                        //Valid
                        new AnswerModel
                        {
                            AnswerId = "1",
                            Description = "Lorem opisum",
                            PhoneDigit = "1"
                        },
                        //Invalid
                        new AnswerModel
                        {
                            AnswerId = "4",
                            Description = "Lorem five ipsum",
                            PhoneDigit = "2"
                        },
                        //Valid
                        new AnswerModel
                        {
                            AnswerId = "3",
                            Description = "Lorem five ipsum",
                            PhoneDigit = "2"
                        },
                        //Invalid
                        new AnswerModel
                        {
                            AnswerId = "5",
                            Description = "Lorem five ipsum",
                            PhoneDigit = "2"
                        },

                    },
                MemberInfo = new MemberModel(),
            };

            //Act
            await _memberAnswerService.UpdateOrCreate(surveyRequest);

            //Assert = Expted two times because only two items are valid.
            questionMockRepository.Verify(service => service.Register(It.IsAny<MemberResultDTO>()), Times.Exactly(2));
        }
    }
}
