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
            // Preparación
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
            // Ejecución
            var result =  Question.Equals(QuestionCompare);
            // Verificación
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Equals_False()
        {
            // Preparación
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
            // Ejecución
            var result = Question.Equals(QuestionCompare);
            // Verificación
            Assert.IsFalse(result);
        }
    }
}
