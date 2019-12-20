using Abp.Domain.Entities.Auditing;
using Master.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Master
{
    public class SeatOrder: CreationAuditedEntity<int>
    {
        public int SeatNumber { get; set; }
        public string OrderOpenId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
    }
}
