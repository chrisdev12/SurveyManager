using System;
using System.Diagnostics.CodeAnalysis;

namespace Survey.WebService.Models
{
    public class QuestionModel : IEquatable<QuestionModel>
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string SurveyId { get; set; }

        public bool Equals([AllowNull] QuestionModel obj)
        {
            if (!(obj is QuestionModel))
                return false;

            QuestionModel other = obj;

            if (Id != other.Id || Description != other.Description || SurveyId != other.SurveyId)
                return false;

            return true;
        }
    }
}
