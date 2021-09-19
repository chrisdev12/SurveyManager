﻿using System.Collections.Generic;

namespace Survey.WebService.Models.Aspect
{
    public class AspectRequestDTO
    {
        public SurveyModel Survey { get; set; }
        public IEnumerable<QuestionModel> Questions { get; set; }
        public AnswerModel Answer { get; set; }
    }
}