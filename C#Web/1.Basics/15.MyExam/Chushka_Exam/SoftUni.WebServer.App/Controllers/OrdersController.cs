namespace SoftUni.WebServer.App.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using SoftUni.WebServer.App.ViewModels;
    using SoftUni.WebServer.Models;
    using SoftUni.WebServer.Mvc.Attributes.HttpMethods;
    using SoftUni.WebServer.Mvc.Interfaces;


    public class OrdersController : BaseController
    {
        private const string OrdersKey = "orders";

        [HttpGet]
        public IActionResult Create(int id)
        {
            using (this.Context)
            {
                Product product = this.Context.Products.Include(x => x.ProductType)
                    .FirstOrDefault(x => x.Id == id);

                if(product == default(Product) || !this.User.IsAuthenticated)
                {
                    return RedirectToHome;
                }

                User user = this.Context.Users
                    .Include(x => x.Role)
                    .FirstOrDefault(x => x.Username == this.User.Name);

                Order order = new Order()
                {
                    ClientId = user.Id,
                    Client = user,
                    ProductId = product.Id,
                    Product = product,
                    OrderedOn = DateTime.UtcNow
                };

                this.Context.Orders.Add(order);
                this.Context.SaveChanges();
            }
            return RedirectToHome;
        }
        
        [HttpGet]
        public IActionResult All()
        {
            bool userIsAdmin = this.User.IsAuthenticated && this.User.IsInRole(AdminRoleString);

            if (!userIsAdmin)
            {
                return RedirectToHome;
            }

            List<AllOrdersViewModel> allOrders = new List<AllOrdersViewModel>();

            using (this.Context)
            {
                allOrders = this.Context.Orders
                    .Include(x => x.Product)
                    .Include(x => x.Client)
                    .Select(x => new AllOrdersViewModel
                    {
                        Id = x.Id,
                        ClientId = x.ClientId,
                        Client = x.Client,
                        ProductId = x.ProductId,
                        Product = x.Product,
                        OrderedOn = x.OrderedOn
                    })
                    .ToList();
            }

            StringBuilder orders = new StringBuilder();

            for (int i = 0; i < allOrders.Count; i++)
            {
                AllOrdersViewModel current = allOrders[i];
                int rowNumber = i + 1;

                string orderedOn = current.OrderedOn.ToString("HH:mm dd/MM/yyyy", CultureInfo.InvariantCulture);

                if(rowNumber % 2 != 0)
                {
                    orders.AppendLine($@"
                    <tr class=""chushka-bg-color"">
                        <th scope=""row"">{rowNumber}</th>
                        <td>{current.Id}</td>
                        <td>{current.Client.Username}</td>
                        <td>{current.Product.Name}</td>
                        <td>{orderedOn}</td>
                    </tr>");
                }
                else
                {
                    orders.AppendLine($@"
                    <tr>
                        <th scope=""row"">{rowNumber}</th>
                        <td>{current.Id}</td>
                        <td>{current.Client.Username}</td>
                        <td>{current.Product.Name}</td>
                        <td>{orderedOn}</td>
                    </tr>");
                }
               
            }

            this.ViewData[OrdersKey] = orders.ToString();

            return this.View();
        }
    }
}
