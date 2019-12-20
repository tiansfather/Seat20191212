using Abp.Domain.Repositories;
using Abp.UI;
using Master.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            if (entity.Id > 0 && await Repository.GetAll().CountAsync(o => o.SeatNumber == entity.SeatNumber && o.Id != entity.Id) > 0)
            {
                throw new UserFriendlyException(L("座位号已存在"));
            }

            if (entity.Id == 0 && await Repository.GetAll().CountAsync(o => o.SeatNumber == entity.SeatNumber) > 0)
            {
                throw new UserFriendlyException(L("座位号已存在"));
            }
        }

        public virtual async Task<bool> IsNowAvailable(int seatNumber)
        {
            var seat = await GetAll().Where(o => o.SeatNumber == seatNumber && o.IsActive).FirstOrDefaultAsync();
            if (seat == null)
            {
                return false;
            }
            if(await Resolve<IRepository<SeatOrder,int>>().CountAsync(o=>o.SeatNumber==seatNumber && o.Year==DateTime.Now.Year && o.Month==DateTime.Now.Month && o.Day == DateTime.Now.Day) > 0)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 获取所有有效座位
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IEnumerable<Seat>> GetAvailableSeats()
        {
            return await GetAll().Where(o => o.IsActive).OrderBy(o=>o.SeatNumber).ToListAsync();
        }
    }
}
