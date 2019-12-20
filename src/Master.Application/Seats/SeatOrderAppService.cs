using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Seats
{
    public class SeatOrderAppService:MasterAppServiceBase<SeatOrder,int>
    {
        /// <summary>
        /// 订座
        /// </summary>
        /// <param name="seatNumber"></param>
        /// <param name="openId"></param>
        /// <returns></returns>
        public virtual async Task Order(int seatNumber,string openId)
        {
            if(!await Resolve<SeatManager>().IsNowAvailable(seatNumber))
            {
                throw new UserFriendlyException("此座位已被占走");
            }
            var seatOrder = new SeatOrder()
            {
                SeatNumber=seatNumber,
                OrderOpenId=openId,
                Year=DateTime.Now.Year,
                Month=DateTime.Now.Month,
                Day=DateTime.Now.Day
            };

            await Resolve<IRepository<SeatOrder, int>>().InsertAsync(seatOrder);
        }
        public virtual async Task Cancel(int seatNumber, string openId)
        {
            var seatOrder = await Resolve<IRepository<SeatOrder, int>>().GetAll().Where(o => o.SeatNumber == seatNumber && o.OrderOpenId == openId && o.Year == DateTime.Now.Year && o.Month == DateTime.Now.Month && o.Day == DateTime.Now.Day).FirstOrDefaultAsync();
            if (seatOrder==null)
            {
                throw new UserFriendlyException("无效参数");
            }            

            await Resolve<IRepository<SeatOrder, int>>().DeleteAsync(seatOrder);
        }
        /// <summary>
        /// 获取当前所有座位状态
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public virtual async Task<object> GetSeatsStatus(string openId)
        {
            var result = new List<object>();
            var seats = await Resolve<SeatManager>().GetAvailableSeats();
            foreach(var seat in seats)
            {
                var todayOrder = Repository.GetAll().Where(o => o.SeatNumber == seat.SeatNumber && o.Year == DateTime.Now.Year && o.Month == DateTime.Now.Month && o.Day == DateTime.Now.Day)
                    .FirstOrDefault();
                result.Add(new { seat.SeatNumber,todayOrder?.OrderOpenId});
            }

            return result;
        }
    }
}
