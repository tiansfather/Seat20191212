using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Master
{
    public class SeatUser : CreationAuditedEntity<int>
    {
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Avata { get; set; }
        public string OpenId { get; set; }
    }
}
