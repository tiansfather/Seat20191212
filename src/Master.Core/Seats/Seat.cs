using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Master.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Master
{
    public class Seat: CreationAuditedEntity<int>,IPassivable
    {
        public int SeatNumber { get; set; }
        public bool IsActive { get; set; }
        public string Remarks { get; set; }
    }

}
