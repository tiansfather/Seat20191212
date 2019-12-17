using Abp.Domain.Entities;
using Master.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Master
{
    public class Seat:BaseFullEntityWithTenant,IPassivable
    {
        public int SeatNumber { get; set; }
        public bool IsActive { get; set; }
    }

}
