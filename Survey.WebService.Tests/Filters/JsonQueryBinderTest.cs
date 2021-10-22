using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Moq;
using Survey.WebService.Filters;
using Survey.WebService.UnitTests.DataGenerators;
using System.Threading.Tasks;
using Xunit;

namespace Survey.WebService.UnitTests.Filters
{
    public class JsonQueryBinderTest
    {
        private readonly JsonQueryBinder _jsonQuerybinder;
        private readonly Mock<IObjectModelValidator> _objectValidatorMOcked;

        public JsonQueryBinderTest()
        {
            var objectValidatorMockup = new Mock<IObjectModelValidator>();
            objectValidatorMockup.Setup(o => o.Validate(It.IsAny<ActionContext>(),
                                              It.IsAny<ValidationStateDictionary>(),
                                              It.IsAny<string>(),
                                              It.IsAny<object>()));
            _objectValidatorMOcked = objectValidatorMockup;
            _jsonQuerybinder = new JsonQueryBinder(_objectValidatorMOcked.Object);
        }

        //Summary = For this custom binder the value (that will come in the query params)
        //is inside the ModelBindingContext object that represents the request information
        [Theory]
        [MemberData(nameof(JsonQueryBinderTestData.GetGeneralSurveyRequestDtoAsJsonString), MemberType = typeof(JsonQueryBinderTestData))]
        public async Task IfValueComesAndIsMappeableTotheObject_ShouldPass(string queryJson, object ObjectToMap)
        {
            //Arrange
            var valueProviderMockup = new Mock<IValueProvider>();
            valueProviderMockup
                .Setup(options => options.GetValue(It.IsAny<string>()))
                .Returns(new ValueProviderResult(queryJson));

            var bindingContextMock = new Mock<ModelBindingContext>();
            bindingContextMock.Setup(options => options.ValueProvider)
                .Returns(valueProviderMockup.Object);

            bindingContextMock.Setup(options => options.ModelType)
                .Returns(ObjectToMap.GetType());

            //Act
            await _jsonQuerybinder.BindModelAsync(bindingContextMock.Object);

            //Assert
            _objectValidatorMOcked.Verify(
                model => model.Validate(
                    It.IsAny<ActionContext>(),
                    It.IsAny<ValidationStateDictionary>(),
                    It.IsAny<string>(),
                    It.IsAny<object>()
                ), Times.Once);
        }
    }
}
