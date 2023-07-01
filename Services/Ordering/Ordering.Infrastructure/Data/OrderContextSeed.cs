using Microsoft.Extensions.Logging;
using Ordering.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Data
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation($"Ordering Database: {typeof(OrderContext).Name} seeded.");
            }
        }

        private static IEnumerable<Order> GetOrders()
        {
            return new List<Order>
        {
            new()
            {
                UserName = "utpal",
                FirstName = "Utpal",
                LastName = "Maity",
                EmailAddress = "utpal@yopmail.com",
                AddressLine = "Kolkata",
                Country = "India",
                TotalPrice = 350,
                State = "WB",
                ZipCode = "700301",

                CardName = "Visa",
                CardNumber = "1234567890123456",
                CreatedBy = "Utpal",
                Expiration = "08/25",
                Cvv = "123",
                PaymentMethod = 1,
                LastModifiedBy = "Utpal",
                LastModifiedDate = new DateTime(),
            }
        };
        }
    }
}
