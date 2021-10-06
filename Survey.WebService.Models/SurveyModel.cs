using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Survey.WebService.Models
{
    public class SurveyModel : IEquatable<SurveyModel>
    {
        [MaxLength(10)]
        public string Id { get; set; }
        public string Description { get; set; }

        public bool Equals([AllowNull] SurveyModel obj)
        {
            if (!(obj is SurveyModel))
                return false;

            SurveyModel other = obj;

            if (Id != other.Id || Description != other.Description)
                return false;

            return true;
        }
    }
}
