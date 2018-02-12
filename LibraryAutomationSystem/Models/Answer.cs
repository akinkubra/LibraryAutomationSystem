using System;
using System.Collections.Generic;

namespace LibraryAutomationSystem.Models
{
    public partial class Answer
    {
        public Answer()
        {
            this.Questions = new List<Question>();
        }

        public int AnswerId { get; set; }
        public string Answer1 { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
