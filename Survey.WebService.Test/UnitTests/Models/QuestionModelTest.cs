using Microsoft.VisualStudio.TestTools.UnitTesting;
using Survey.WebService.Models;

namespace Survey.WebService.Test
{
    [TestClass]
    public class QuestionModelTest
    {
        [TestMethod]
        public void Equals_True()
        {
            // Preparaci�n
            var Question = new QuestionModel
            {
                Id = "1",
                Description = "testing equal",
                SurveyId = "1"
            };
            var QuestionCompare = new QuestionModel
            {
                Id = "1",
                Description = "testing equal",
                SurveyId = "1"
            };
            // Ejecuci�n
            var result =  Question.Equals(QuestionCompare);
            // Verificaci�n
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Equals_False()
        {
            // Preparaci�n
            var Question = new QuestionModel
            {
                Id = "1",
                Description = "testing equal",
                SurveyId = "1"
            };
            var QuestionCompare = new QuestionModel
            {
                Id = "1",
                Description = "is not equal",
                SurveyId = "1"
            };
            // Ejecuci�n
            var result = Question.Equals(QuestionCompare);
            // Verificaci�n
            Assert.IsFalse(result);
        }
    }
}
