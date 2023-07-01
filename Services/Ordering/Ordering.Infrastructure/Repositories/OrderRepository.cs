using Microsoft.EntityFrameworkCore;
using Ordering.Core.Entities;
using Ordering.Core.Repositories;
using Ordering.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(OrderContext dbContext) : base(dbContext)
        {

        }

        /// <summary>
        /// Retrieves a list of orders by user name.
        /// </summary>
        /// <param name="userName">The user name to filter orders by.</param>
        /// <returns>An enumerable collection of orders.</returns>
        public async Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
        {

            var orderList = await _dbContext.Orders
                .Where(o => o.UserName == userName)
                .ToListAsync();
            return orderList;
            
        }
    }
}
