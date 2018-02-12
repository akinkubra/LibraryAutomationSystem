using System;
using System.Collections.Generic;

namespace LibraryAutomationSystem.Models
{
    public partial class Penalty
    {
        public int PenaltyId { get; set; }
        public int BookOperationId { get; set; }
        public double PenaltyQuantity { get; set; }
        public virtual BookOperation BookOperation { get; set; }
    }
}
