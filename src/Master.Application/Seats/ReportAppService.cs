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
            var seatOrders = await Repository.GetAll().Where(o => o.Year == year && o.Month == month).ToListAsync();
            var seats = await Resolve<SeatManager>().GetAllList();

            return seats.Select(o =>
            {
                var occupiedDays = seatOrders.Where(s => o.SeatNumber == s.SeatNumber).Select(s => s.Day);
                return new
                {
                    o.SeatNumber,
                    Days = occupiedDays
                };
            });
        }
    }
}
