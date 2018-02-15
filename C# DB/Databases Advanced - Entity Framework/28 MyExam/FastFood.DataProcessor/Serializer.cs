using System;
using System.IO;
using FastFood.Data;
using System.Linq;
using FastFood.Models.Enums;
using Newtonsoft.Json;
using FastFood.DataProcessor.Dto.Export;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using FastFood.Models;

namespace FastFood.DataProcessor
{
	public class Serializer
	{
		public static string ExportOrdersByEmployee(FastFoodDbContext context, string employeeName, string orderType)
		{
            var employee = context.Employees
                .FirstOrDefault(x => x.Name == employeeName);

            var parsedOrderType = Enum.Parse<OrderType>(orderType);

            var rawOrders = context.Orders
                .Include(x => x.OrderItems)
                .ThenInclude(y => y.Item)
                .Where(x => x.EmployeeId == employee.Id && x.Type == parsedOrderType)
                .ToList()
                .OrderByDescending(x => x.TotalPrice)
                .ThenByDescending(x => x.OrderItems.Count());

            decimal totalMade = rawOrders.Sum(x => x.TotalPrice);

            var exportDto = new ExportOrdersDto();

            foreach (var order in rawOrders)
            {
                var expItemsDto = new List<ExpInnerItemDto>();

                foreach (var orItems in order.OrderItems)
                {
                    var innerItem = new ExpInnerItemDto()
                    {
                        Name = orItems.Item.Name,
                        Price = decimal.Parse($"{orItems.Item.Price:F2}"),
                        Quantity = orItems.Quantity
                    };

                    expItemsDto.Add(innerItem);
                }

                var expInnerOrder = new ExpInnerOrdDto()
                {
                    Customer = order.Customer,
                    Items = new List<ExpInnerItemDto>(expItemsDto),
                    TotalPrice = decimal.Parse($"{order.TotalPrice:F2}")
                };

                
                exportDto.Name = employeeName;
                exportDto.Orders.Add(expInnerOrder);
                exportDto.TotalMade = exportDto.Orders.Sum(x => x.TotalPrice);
            }
            
            var jsonString = JsonConvert.SerializeObject(exportDto, Newtonsoft.Json.Formatting.Indented);

            return jsonString;
		}

		public static string ExportCategoryStatistics(FastFoodDbContext context, string categoriesString)
		{
            var categoryArgs = categoriesString.Split(',', StringSplitOptions.RemoveEmptyEntries).ToArray();

            var categories = context.Categories
                .Where(c => categoryArgs.Any(cs => cs == c.Name))
                .Select(c => new
                {
                    Name = c.Name,
                    MostPopularItem = c.Items.OrderByDescending(x => x.OrderItems.Sum(y => y.Quantity * y.Item.Price))
                    .First()
                })
                .Select(c => new xmlCategoryDto
                {
                    Name = c.Name,
                    MostPopularItem = new MostPopularItemDto()
                    {
                        Name = c.MostPopularItem.Name,
                        TotalMade = c.MostPopularItem.OrderItems.Sum(x => x.Quantity * x.Item.Price),
                        TimesSold = c.MostPopularItem.OrderItems.Sum(x => x.Quantity)
                    }
                })
                .OrderByDescending(x => x.MostPopularItem.TotalMade)
                .ThenByDescending(x => x.MostPopularItem.TimesSold)
                .ToArray();

            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(xmlCategoryDto[]), new XmlRootAttribute("Categories"));
            serializer.Serialize(new StringWriter(sb), categories, new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));

            var result = sb.ToString();
            return result;
        }
	}
}