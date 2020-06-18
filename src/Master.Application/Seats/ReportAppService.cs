using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Seats
{
    public class ReportAppService:MasterAppServiceBase<SeatOrder,int>
    {
        public virtual async Task<object> GetMonthReport(int year,int month)
        {
            //var seatOrders = await Repository.GetAll().Where(o => o.Year == year && o.Month == month).ToListAsync();

            var query = from seatOrder in Repository.GetAll()
                        join seatUser in Resolve<SeatUserManager>().GetAll() on seatOrder.OrderOpenId equals seatUser.OpenId
                        where seatOrder.Year == year && seatOrder.Month == month
                        select new { seatOrder.SeatNumber, seatOrder.Day, seatUser.Name,seatUser.NickName };

            var seatOrders = await query.ToListAsync();

            var seats = await Resolve<SeatManager>().GetAll().ToListAsync();

            //var seatUsers = await Resolve<SeatUserManager>().GetAll().Where(o => seatOrders.Select(s => s.OrderOpenId).Contains(o.OpenId)).ToListAsync();

            return seats.Select(o =>
            {
                var occupiedDays = seatOrders.Where(s => o.SeatNumber == s.SeatNumber).Select(s => new { s.Day,Name=!string.IsNullOrEmpty(s.Name)?s.Name:s.NickName });
                return new
                {
                    o.SeatNumber,
                    Days = occupiedDays
                };
            });
        }
    }
}
