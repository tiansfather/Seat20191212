using Master.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master
{
    public class SeatUserManager : DomainServiceBase<SeatUser, int>
    {
        public async Task<bool> IsCreated(SeatUser seatuser)
        {
            var oriUser = await GetByOpenId(seatuser.OpenId);
            if (oriUser == null)
            {
                await InsertAsync(seatuser);
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<SeatUser> GetByOpenId(string openId)
        {
            return await GetAll().Where(o => o.OpenId == openId).FirstOrDefaultAsync();
        }
    }
}
