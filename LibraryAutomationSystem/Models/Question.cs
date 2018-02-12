using System;
using System.Collections.Generic;

namespace LibraryAutomationSystem.Models
{
    public partial class Question
    {
        public int QuestionId { get; set; }
        public string Question1 { get; set; }
        public int AnswerId { get; set; }
        public virtual Answer Answer { get; set; }
    }
}
