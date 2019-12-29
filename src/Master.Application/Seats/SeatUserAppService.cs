using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Seats
{
    public class SeatUserAppService:MasterAppServiceBase<SeatUser,int>
    {
        protected override  object PageResultConverter(SeatUser entity)
        {
            var orderNumber = Resolve<IRepository<SeatOrder, int>>().GetAll().Where(o => o.OrderOpenId == entity.OpenId).Count();
            return new
            {
                entity.OpenId,
                entity.Name,
                entity.NickName,
                entity.Avata,
                orderNumber
            };
        }

        protected override async Task<IQueryable<SeatUser>> BuildKeywordQueryAsync(string keyword, IQueryable<SeatUser> query)
        {
            return (await base.BuildKeywordQueryAsync(keyword, query))
                .Where(o => o.Name.Contains(keyword));
        }
    }
}
