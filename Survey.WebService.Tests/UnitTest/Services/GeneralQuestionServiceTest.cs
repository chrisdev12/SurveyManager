using Moq;
using Survey.WebService.Models;
using Survey.WebService.Repository;
using Survey.WebService.Services;
using Survey.WebService.Tests.DataGenerators;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Survey.WebService.Tests.UnitTest.Services
{
    public class GeneralQuestionServiceTest
    {
        private readonly IRepository<QuestionModel> _questionRepository;

        public GeneralQuestionServiceTest()
        {
            var questionRepository = new Mock<IRepository<QuestionModel>>();
            questionRepository
                .Setup(service => service.GetAll(It.IsAny<string>()))
                .Returns(Task.FromResult(GeneralQuestionServiceData.repositoryMockData));

            _questionRepository = questionRepository.Object;
        }

        [Theory]
        [MemberData(nameof(GeneralQuestionServiceData.GetOnlyNewQuestions), MemberType = typeof(GeneralQuestionServiceData))]
        public async Task IfAllQuestionsAreNew_AllQuestionListAreInCreatedStatus(List<QuestionModel> questionListRequest, SurveyModel survey)
        {
            //Arrange
            var questionService = new GeneralQuestionService(_questionRepository);

            //Act
            var questionStatusList = await questionService.UpdateOrCreate(questionListRequest, survey);

            //Assertion
            var allItemsAreCreated = questionStatusList.All(question => question.Status == OperationStatusEnum.Created.ToString());
            var noItemsAreInAnotherStatus = questionStatusList
                .Any(question => question.Status == OperationStatusEnum.Updated.ToString() 
                              || question.Status == OperationStatusEnum.Unchanged.ToString());

            Assert.True(allItemsAreCreated);
            Assert.False(noItemsAreInAnotherStatus);
        }

        [Theory]
        [MemberData(nameof(GeneralQuestionServiceData.GetAllTypesOfQuestions), MemberType = typeof(GeneralQuestionServiceData))]
        public async Task IfAnyQuestionIsNew_QuestionListContainsACreatedStatus(List<QuestionModel> questionListRequest, SurveyModel survey)
        {
            //Arrange
            var questionService = new GeneralQuestionService(_questionRepository);

            //Act
            var questionStatusList = await questionService.UpdateOrCreate(questionListRequest, survey);

            //Assertion
            var someItemsAreCreated = questionStatusList.Any(question => question.Status == OperationStatusEnum.Created.ToString());

            Assert.True(someItemsAreCreated);
        }

        [Theory]
        [MemberData(nameof(GeneralQuestionServiceData.GetOnlyQuestionsAlreadyRegisteredBThatShouldBeUpdated), MemberType = typeof(GeneralQuestionServiceData))]
        public async Task IfAllQuestionsAreRegisteredAndShouldBeUpdated_AllQuestionListAreInUpdatedStatus(List<QuestionModel> questionListRequest, SurveyModel survey)
        {
            //Arrange
            var questionService = new GeneralQuestionService(_questionRepository);

            //Act
            var questionStatusList = await questionService.UpdateOrCreate(questionListRequest, survey);

            //Assertion
            var allItemsAreUpdated = questionStatusList.All(question => question.Status == OperationStatusEnum.Updated.ToString());
            var noItemsAreInAnotherStatus = questionStatusList
                .Any(question => question.Status == OperationStatusEnum.Created.ToString()
                              || question.Status == OperationStatusEnum.Unchanged.ToString());

            Assert.True(allItemsAreUpdated);
            Assert.False(noItemsAreInAnotherStatus);
        }

        [Theory]
        [MemberData(nameof(GeneralQuestionServiceData.GetAllTypesOfQuestions), MemberType = typeof(GeneralQuestionServiceData))]
        public async Task IfAnyQuestionisRegisteredAndShouldBeUpdated_QuestionListContainsAUpdatedStatus(List<QuestionModel> questionListRequest, SurveyModel survey)
        {
            //Arrange
            var questionService = new GeneralQuestionService(_questionRepository);

            //Act
            var questionStatusList = await questionService.UpdateOrCreate(questionListRequest, survey);

            //Assertion
            var someItemsAreUpdated = questionStatusList.Any(question => question.Status == OperationStatusEnum.Updated.ToString());

            Assert.True(someItemsAreUpdated);
        }


        [Theory]
        [MemberData(nameof(GeneralQuestionServiceData.GetOnlyUnchagedQuestions), MemberType = typeof(GeneralQuestionServiceData))]
        public async Task IfAllQuestionsRemainsUnchanged_AllQuestionListAreInUnchagedStatus(List<QuestionModel> questionListRequest, SurveyModel survey)
        {
            //Arrange
            var questionService = new GeneralQuestionService(_questionRepository);

            //Act
            var questionStatusList = await questionService.UpdateOrCreate(questionListRequest, survey);

            //Assertion
            var someItemsAreUnchanged = questionStatusList.All(question => question.Status == OperationStatusEnum.Unchanged.ToString());
            var noItemsAreInAnotherStatus = questionStatusList
                .Any(question => question.Status == OperationStatusEnum.Created.ToString()
                              || question.Status == OperationStatusEnum.Updated.ToString());

            Assert.True(someItemsAreUnchanged);
            Assert.False(noItemsAreInAnotherStatus);
        }

        [Theory]
        [MemberData(nameof(GeneralQuestionServiceData.GetAllTypesOfQuestions), MemberType = typeof(GeneralQuestionServiceData))]
        public async Task IfAnyQuestionsRemainsUnchanged_QuestionListContainsUnchagedStatus(List<QuestionModel> questionListRequest, SurveyModel survey)
        {
            //Arrange
            var questionService = new GeneralQuestionService(_questionRepository);

            //Act
            var questionStatusList = await questionService.UpdateOrCreate(questionListRequest, survey);

            //Assertion
            var someItemsAreUnchanged = questionStatusList.Any(question => question.Status == OperationStatusEnum.Unchanged.ToString());

            Assert.True(someItemsAreUnchanged);
        }
    }
}
