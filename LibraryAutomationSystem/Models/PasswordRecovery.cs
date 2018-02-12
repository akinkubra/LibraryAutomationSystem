using System;
using System.Collections.Generic;

namespace LibraryAutomationSystem.Models
{
    public partial class PasswordRecovery
    {
        public int RecoveryId { get; set; }
        public Nullable<int> UserId { get; set; }
        public bool RecoStatus { get; set; }
        public int RecoCount { get; set; }
        public Nullable<System.DateTime> RecoDate { get; set; }
        public virtual User User { get; set; }
    }
}
