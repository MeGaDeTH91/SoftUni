using System;
using FastFood.Data;
using Newtonsoft.Json;
using FastFood.DataProcessor.Dto.Import;
using System.Text;
using System.Collections.Generic;
using FastFood.Models;
using System.Linq;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using System.IO;
using System.Globalization;
using FastFood.Models.Enums;

namespace FastFood.DataProcessor
{
	public static class Deserializer
	{
		private const string FailureMessage = "Invalid data format.";
		private const string SuccessMessage = "Record {0} successfully imported.";

		public static string ImportEmployees(FastFoodDbContext context, string jsonString)
		{
            var deserializedEmps = JsonConvert.DeserializeObject<ImpEmployeesDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            var validEmps = new List<Employee>();

            foreach (var empDto in deserializedEmps)
            {
                if (!IsValid(empDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                bool positionExists = context.Positions
                    .Any(x => x.Name == empDto.Position);

                if (!positionExists)
                {
                    var positionToAdd = new Position()
                    {
                        Name = empDto.Position
                    };

                    context.Positions.Add(positionToAdd);
                    context.SaveChanges();
                }
                var position = context.Positions
                    .FirstOrDefault(x => x.Name == empDto.Position);

                var employee = new Employee()
                {
                    Name = empDto.Name,
                    Age = empDto.Age,
                    PositionId = position.Id
                };

                validEmps.Add(employee);
                sb.AppendLine(string.Format(SuccessMessage, empDto.Name));
            }

            context.Employees.AddRange(validEmps);
            context.SaveChanges();

            string result = sb.ToString().Trim();
            return result;
		}

		public static string ImportItems(FastFoodDbContext context, string jsonString)
		{
            var deserializedItems = JsonConvert.DeserializeObject<ImpItemDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            var validItems = new List<Item>();

            foreach (var itemDto in deserializedItems)
            {
                if (!IsValid(itemDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                bool itemAlreadyExists = validItems.Any(x => x.Name == itemDto.Name) ||
                    context.Items.Any(x => x.Name == itemDto.Name);

                if (itemAlreadyExists)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                bool categoryExists = context.Categories
                    .Any(x => x.Name == itemDto.Category);

                if (!categoryExists)
                {
                    var categoryToAdd = new Category()
                    {
                        Name = itemDto.Category
                    };
                    context.Categories.Add(categoryToAdd);
                    context.SaveChanges();
                }
                var category = context.Categories
                    .FirstOrDefault(x => x.Name == itemDto.Category);

                var item = new Item()
                {
                    Name = itemDto.Name,
                    Price = itemDto.Price,
                    CategoryId = category.Id
                };
                validItems.Add(item);
                sb.AppendLine(string.Format(SuccessMessage, itemDto.Name));
            }
            context.Items.AddRange(validItems);
            context.SaveChanges();

            string result = sb.ToString().Trim();
            return result;
        }

		public static string ImportOrders(FastFoodDbContext context, string xmlString)
		{
            var serializer = new XmlSerializer(typeof(ImpOrderDto[]), new XmlRootAttribute("Orders"));
            var deserializedOrders = (ImpOrderDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            StringBuilder sb = new StringBuilder();

            foreach (var orderDto in deserializedOrders)
            {
                if (!IsValid(orderDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                OrderType orderType = Enum.TryParse<OrderType>(orderDto.Type, out var ord) ? ord : OrderType.ForHere;

                var employee = context.Employees
                    .FirstOrDefault(x => x.Name == orderDto.Employee);

                if (employee == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                bool itemsExist = true;

                foreach (var ordItem in orderDto.Items)
                {
                    var presentItem = context.Items
                        .FirstOrDefault(x => x.Name == ordItem.Name);

                    if(presentItem == null)
                    {
                        itemsExist = false;
                        break;
                    }
                }
                if (!itemsExist)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                DateTime date;
                bool isValidTime = DateTime.TryParseExact(orderDto.DateTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);

                if (!isValidTime)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var order = new Order()
                {
                    Customer = orderDto.Customer,
                    EmployeeId = employee.Id,
                    DateTime = date,
                    Type = orderType
                };

                context.Orders.Add(order);
                context.SaveChanges();

                var takeOrder = context.Orders
                    .FirstOrDefault(x => x.EmployeeId == employee.Id &&
                    x.DateTime == date &&
                    x.Customer == orderDto.Customer);

                var itemsOrders = new List<OrderItem>();

                foreach (var orderItem in orderDto.Items)
                {
                    var item = context.Items
                        .FirstOrDefault(x => x.Name == orderItem.Name);

                    OrderItem od = new OrderItem()
                    {
                        ItemId = item.Id,
                        OrderId = takeOrder.Id,
                        Quantity = orderItem.Quantity
                    };
                    itemsOrders.Add(od);
                }
                context.OrderItems.AddRange(itemsOrders);
                context.SaveChanges();

                sb.AppendLine($"Order for {orderDto.Customer} on {date.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)} added");
            }


            string result = sb.ToString().Trim();
            return result;

        }
        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);

            return isValid;
        }
    }
}