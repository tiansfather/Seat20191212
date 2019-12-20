using Abp.Authorization;
using Abp.UI;
using Master.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Seats
{
    [AbpAuthorize]
    public class SeatAppService:MasterAppServiceBase<Seat,int>
    {
        protected override async Task<IQueryable<Seat>> GetQueryable(RequestPageDto request)
        {
            return (await base.GetQueryable(request))
                .OrderBy(o=>o.Id);
        }
        protected override object PageResultConverter(Seat entity)
        {
            return new
            {
                entity.Id,
                entity.IsActive,
                entity.SeatNumber,
                entity.Remarks
            };
        }
        public virtual async Task Add(int seatNumber)
        {
            var seat = new Seat()
            {
                SeatNumber=seatNumber,
                IsActive=true
            };

            await Manager.InsertAsync(seat);
        }

        public virtual async Task SetActive(int seatId,bool isActive)
        {
            var seat = await Manager.GetByIdAsync(seatId);
            seat.IsActive = isActive;
        }

        public virtual async Task SetRemarks(int seatId,string remarks)
        {
            var seat = await Manager.GetByIdAsync(seatId);
            seat.Remarks = remarks;
        }
    }
}
