using Abp.UI;
using Master.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Master
{
    public class SeatManager:DomainServiceBase<Seat,int>
    {
        public override async Task ValidateEntity(Seat entity)
        {
            if (entity.SeatNumber <= 0)
            {
                throw new UserFriendlyException(L("座位号必须大于0"));
            }
            if (entity.Id > 0 && await Repository.GetAll().CountAsync(o => o.SeatNumber == entity.SeatNumber && o.TenantId == entity.TenantId && o.Id != entity.Id) > 0)
            {
                throw new UserFriendlyException(L("座位号已存在"));
            }

            if (entity.Id == 0 && await Repository.GetAll().CountAsync(o => o.SeatNumber == entity.SeatNumber) > 0)
            {
                throw new UserFriendlyException(L("座位号已存在"));
            }
        }
    }
}
