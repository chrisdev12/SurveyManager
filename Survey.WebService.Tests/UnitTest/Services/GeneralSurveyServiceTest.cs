using Moq;
using Survey.WebService.Models;
using Survey.WebService.Repository;
using Survey.WebService.Services;
using System.Threading.Tasks;
using Xunit;

namespace Survey.WebService.Tests.UnitTest.Services
{
    public class GeneralSurveyServiceTest
    {
        private readonly IRepository<SurveyModel> _surveyMockRepository;
        private readonly SurveyModel initialSurvey = new SurveyModel
        {
            Id = "mockSurvey",
            Description = "this is a mock survey description"
        };

        public GeneralSurveyServiceTest()
        {
            var surveyMockRepository = new Mock<IRepository<SurveyModel>>();
            surveyMockRepository
                .Setup(service => service.Get(It.IsAny<string>()))
                .Returns(Task.FromResult(initialSurvey));
            surveyMockRepository
                .Setup(service => service.Get("nulled"))
                .Returns(Task.FromResult((SurveyModel) null));            

            _surveyMockRepository = surveyMockRepository.Object;
        }

        [Fact]
        public async Task IfSurveyIsNew_OperationStatusIsCreated()
        {
            //Arrange
            var surveyService = new GeneralSurveyService(_surveyMockRepository);
            var surveyIncomingRequest = new SurveyModel
            {
                Id = "nulled",
                Description = initialSurvey.Description
            };

            //Act
            var operationStatus = await surveyService.UpdateOrCreate(surveyIncomingRequest);

            //Assertion
            Assert.Equal(OperationStatusEnum.Created.ToString(), operationStatus.ToString());
        }

        [Fact]
        public async Task IfSurveyIsRegistered_OperationStatusIsUpdated()
        {
            //Arrange
            var surveyService = new GeneralSurveyService(_surveyMockRepository);
            var surveyIncomingRequest = new SurveyModel
            {
                Id = initialSurvey.Id,
                Description = $"{initialSurvey.Description} different"
            };

            //Act
            var operationStatus = await surveyService.UpdateOrCreate(surveyIncomingRequest);
            
            //Assertion
            Assert.Equal(OperationStatusEnum.Updated.ToString(), operationStatus.ToString());
        }

        [Fact]
        public async Task IfSurveyRemainsUnchange_OperationStatusIsUnchaged()
        {
            //Arrange
            var surveyService = new GeneralSurveyService(_surveyMockRepository);
            var surveyIncomingRequest = new SurveyModel
            {
                Id = initialSurvey.Id,
                Description = initialSurvey.Description
            };

            //Act
            var operationStatus = await surveyService.UpdateOrCreate(surveyIncomingRequest);

            //Assertion
            Assert.Equal(OperationStatusEnum.Unchanged.ToString(), operationStatus.ToString());
        }
    }
}
