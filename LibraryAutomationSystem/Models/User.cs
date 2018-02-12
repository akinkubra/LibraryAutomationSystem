using System;
using System.Collections.Generic;

namespace LibraryAutomationSystem.Models
{
    public partial class User
    {
        public User()
        {
            this.PasswordRecoveries = new List<PasswordRecovery>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public virtual ICollection<PasswordRecovery> PasswordRecoveries { get; set; }
    }
}
