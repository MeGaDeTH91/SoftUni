namespace ProductShop.App
{
    using ProductShop.Data;
    using System;
    using System.IO;
    using Newtonsoft.Json;
    using System.Linq;
    using System.Xml.Linq;
    using ProductShop.Models;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            ResetDatabase();

            //ImportJsons();
            //ExportJsons();

            //ImportXmls();
            //ExportXmls();

        }        

        static void ImportJsons()
        {
            //JsonImports
            //1.ImportUsers
            Console.WriteLine(ImportUsersFromJson());
            //2.ImportProducts
            Console.WriteLine(ImportProductsFromJson());
            //3.ImportCategories
            Console.WriteLine(ImportCategoriesFromJson());

            SetCategories();
        }

        static void ExportJsons()
        {
            //JsonExports
            //1.Products In Range JSON
            GetProductsInRangeJson();
            //2.Successfully Sold Products JSON
            GetUserWithOneOrMoreSoldItemsJson();
            //3.Categories By Product Count JSON
            GetCategoriesJson();
            //4.Users and Products JSON
            GetUsersWithSoldItemsJson();
        }

        static void ImportXmls()
        {
            //XML Imports
            //1.ImportUsers
            Console.WriteLine(ImportUsersFromXml());
            //2.ImportProducts
            Console.WriteLine(ImportProductsFromXml());
            //3.ImportCategories
            Console.WriteLine(ImportCategoriesFromXml());

            SetCategories();
        }

        static void ExportXmls()
        {
            GetProductsInRangeXml();
            GetUserWithOneOrMoreSoldItemsXml();
            GetCategoriesXml();
            GetUsersWithSoldItemsXml();
        }

        //4.Export Users and Products JSON
        static void GetUsersWithSoldItemsJson()
        {
            using (var db = new ProductShopDbContext())
            {
                var users = db.Users
                    .Include(x => x.SoldProducts)
                    .ThenInclude(y => y.Buyer)
                    .Where(x => x.SoldProducts.Any(y => y.BuyerId != null))                   
                    .ToList();

                var jsonData = new
                {
                    userCount = users.Count(),
                    users = users.Select(x => new
                    {
                        firstName = x.FirstName,
                        lastName = x.LastName,
                        age = x.Age == null ? 0 : x.Age,
                        soldProducts =  new
                        {
                            count = x.SoldProducts.Count(p => p.BuyerId != null),
                            products = x.SoldProducts.Where(p => p.BuyerId != null).Select(z => new
                            {
                                name = z.Name,
                                price = z.Price
                            }).ToList()
                        }                        
                    }).ToList()
                    .OrderByDescending(u => u.soldProducts.count)
                    .ThenBy(t => t.lastName)
                };

                string jsonString = JsonConvert.SerializeObject(jsonData, Formatting.Indented);

                File.WriteAllText("FilesExported/Json/4.Users-and-products.json", jsonString);
            }
        }

        //3.Export Categories By Product Count JSON
        static void GetCategoriesJson()
        {
            using(var db = new ProductShopDbContext())
            {
                var categories = db.Categories
                    .Include(x => x.CategoriesProducts)
                    .ThenInclude(y => y.Product)
                    .OrderBy(x => x.Name)
                    .Select(x => new
                    { category = x.Name,
                        productsCount = x.CategoriesProducts.Count(),
                        averagePrice = x.CategoriesProducts.Average(y => y.Product.Price), totalRevenue = x.CategoriesProducts.Sum(y => y.Product.Price)
                    })
                    .ToList();

                string jsonString = JsonConvert.SerializeObject(categories, Formatting.Indented, new JsonSerializerSettings()
                {
                    DefaultValueHandling = DefaultValueHandling.Ignore
                });

                File.WriteAllText("FilesExported/Json/3.Categories-by-products.json", jsonString);
                    
            }
        }

        //2.Export Successfully Sold Products JSON
        static void GetUserWithOneOrMoreSoldItemsJson()
        {
            using(var db = new ProductShopDbContext())
            {
                var users = db.Users
                    .Where(x => x.SoldProducts.Any(y => y.BuyerId != null))
                    .OrderBy(x => x.LastName)
                    .ThenBy(x => x.FirstName)
                    .Select(x => new
                    {
                        firstName = x.FirstName,
                        lastName = x.LastName,
                        soldProducts = x.SoldProducts.Select(y => new
                        {
                            name = y.Name,
                            price = y.Price,
                            buyerFirstName = y.Buyer.FirstName,
                            buyerLastName = y.Buyer.LastName
                        }).ToList()
                    }).ToList();

                string jsonString = JsonConvert.SerializeObject(users, Formatting.Indented, new JsonSerializerSettings()
                {
                    DefaultValueHandling = DefaultValueHandling.Ignore
                });

                File.WriteAllText("FilesExported/Json/2.Users-sold-products.json", jsonString);
            }
        }

        //1.Export Products In Range JSON
        static void GetProductsInRangeJson()
        {
            using(var db = new ProductShopDbContext())
            {
                var products = db.Products
                    .OrderBy(x => x.Price)
                    .Where(x => x.Price >= 500 && x.Price <= 1000)
                    .Select(x => new
                    {
                        name = x.Name,
                        price = x.Price,
                        seller = $"{x.Seller.FirstName} {x.Seller.LastName}"
                    }).ToList();

                var jsonString = JsonConvert.SerializeObject(products, Formatting.Indented);

                File.WriteAllText("FilesExported/Json/1.Products-in-range.json", jsonString);
            }
        }

        static void SetCategories()
        {
            using(var db = new ProductShopDbContext())
            {
                var products = db.Products.Select(x => x.ProductId).ToList();
                var categories = db.Categories.Select(x => x.CategoryId).ToList();

                Random rnd = new Random();
                var catProducts = new List<CategoryProduct>();

                foreach (var prod in products)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        int index = rnd.Next(0, categories.Count());

                        CategoryProduct cp = new CategoryProduct()
                        {
                            CategoryId = categories[index],
                            ProductId = prod
                        };
                        if(catProducts.Any(x => x.ProductId == prod && x.CategoryId == categories[index]))
                        {
                            index = rnd.Next(0, categories.Count());
                            i--;
                        }
                        else
                        {
                            catProducts.Add(cp);
                        }                                             
                    }
                }
                db.CategoriesProducts.AddRange(catProducts);
                db.SaveChanges();
            }
        }

        static string ImportProductsFromJson()
        {
            string path = "Files/products.json";
            Product[] products = ImportJson<Product>(path);
            Random rnd = new Random();

            using (var db = new ProductShopDbContext())
            {
                int[] userIds = db.Users.Select(x => x.UserId).ToArray();


                foreach (var p in products)
                {
                    int index = rnd.Next(0, userIds.Length);

                    int sellerId = userIds[index];

                    int? buyerId = sellerId;

                    while (buyerId == sellerId)
                    {
                        int buyerIndex = rnd.Next(0, userIds.Length);
                        buyerId = userIds[buyerIndex];
                    }

                    if (buyerId - sellerId < 5 && buyerId - sellerId > 0)
                    {
                        buyerId = null;
                    }

                    p.SellerId = sellerId;
                    p.BuyerId = buyerId;
                }

                db.Products.AddRange(products);
                db.SaveChanges();
            }

            return $"{products.Length} were imported successfully from file: {path}";
        }

        static string ImportCategoriesFromJson()
        {
            string path = "Files/categories.json";
            Category[] categories = ImportJson<Category>(path);

            using (var db = new ProductShopDbContext())
            {
                db.Categories.AddRange(categories);
                db.SaveChanges();
            }

            return $"{categories.Length} were imported successfully from file: {path}";
        }

        static string ImportUsersFromJson()
        {
            string path = "Files/users.json";
            User[] users = ImportJson<User>(path);

            using(var db = new ProductShopDbContext())
            {
                db.Users.AddRange(users);
                db.SaveChanges();
            }

            return $"{users.Length} were imported successfully from file: {path}";
        }

        static T[] ImportJson<T>(string path)
        {
            string jsonString = File.ReadAllText(path);

            T[] objects = JsonConvert.DeserializeObject<T[]>(jsonString);

            return objects;
        }

        static string ImportUsersFromXml()
        {
            string path = "Files/users.xml";
            string xmlStr = File.ReadAllText(path);

            var xml = XDocument.Parse(xmlStr);

            var elements = xml.Root.Elements();
            var users = new List<User>();

            foreach (var e in elements)
            {
                string firstName = e.Attribute("firstName")?.Value;
                string lastName = e.Attribute("lastName").Value;

                int? age = null;
                if (e.Attribute("age") != null)
                {
                    age = int.Parse(e.Attribute("age").Value);
                }

                User user = new User()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age
                };
                users.Add(user);

            }
            using(var db = new ProductShopDbContext())
            {
                db.Users.AddRange(users);
                db.SaveChanges();
            }
            return $"{users.Count()} users were imported successfully from file: {path}";
        }

        static string ImportProductsFromXml()
        {
            Random rnd = new Random();
            
            string path = "Files/products.xml";
            string xmlStr = File.ReadAllText(path);
            var xml = XDocument.Parse(xmlStr);
            var elements = xml.Root.Elements();
            var products = new List<Product>();

            using(var db = new ProductShopDbContext())
            {
                var userIds = db.Users.Select(x => x.UserId).ToList();

                foreach (var e in elements)
                {
                    int index = rnd.Next(0, userIds.Count());
                    int sellerId = userIds[index];

                    int? buyerId = sellerId;

                    while (buyerId == sellerId)
                    {
                        int buyerIndex = rnd.Next(0, userIds.Count());

                        buyerId = userIds[buyerIndex];
                    }

                    if(buyerId - sellerId < 5)
                    {
                        buyerId = null;
                    }

                    string name = e.Element("name").Value;
                    decimal price = decimal.Parse(e.Element("price").Value);

                    Product product = new Product()
                    {
                        Name = name,
                        Price = price,
                        SellerId = sellerId,
                        BuyerId = buyerId
                    };
                    products.Add(product);
                }

                db.Products.AddRange(products);
                db.SaveChanges();
            }
            return $"{products.Count()} products were imported successfully from file: {path}";

        }

        static string ImportCategoriesFromXml()
        {
            string path = "Files/categories.xml";

            var xmlStr = File.ReadAllText(path);

            var xmlDoc = XDocument.Parse(xmlStr);

            var elements = xmlDoc.Root.Elements();

            var categories = new List<Category>();

            foreach (var e in elements)
            {
                string catName = e.Element("name").Value;

                Category cat = new Category()
                {
                    Name = catName
                };
                categories.Add(cat);
            }
            using(var db = new ProductShopDbContext())
            {
                db.Categories.AddRange(categories);
                db.SaveChanges();
            }
            return $"{categories.Count()} categories were imported successfully from {path}!";
        }

        static void GetProductsInRangeXml()
        {
            using(var db = new ProductShopDbContext())
            {
                var products = db.Products
                    .Where(x => x.BuyerId != null && x.Price >= 1000 & x.Price <= 2000)
                    .Select(x => new
                    {
                        name = x.Name,
                        price = x.Price,
                        buyer = string.Join(" ", x.Buyer.FirstName, x.Buyer.LastName)
                    })
                    .ToList()
                    .OrderBy(x => x.price);

                var xDoc = new XDocument();

                xDoc.Add(new XElement("products"));

                foreach (var p in products)
                {
                    xDoc.Root.Add(new XElement("product", new XAttribute("name", p.name), new XAttribute("price", p.price), new XAttribute("buyer", p.buyer)));
                }
                xDoc.Save("FilesExported/Xml/1.Products-in-range.xml");
            }
        }

        static void GetUserWithOneOrMoreSoldItemsXml()
        {
            using(var db = new ProductShopDbContext())
            {
                var users = db.Users
                    .Where(x => x.SoldProducts.Any())
                    .Select(x => new
                    {
                        firstName = x.FirstName,
                        lastName = x.LastName,
                        soldProducts = x.SoldProducts.Select(y => new
                        {
                            name = y.Name,
                            price = y.Price
                        }).ToList()
                    }).ToList()
                    .OrderBy(x => x.lastName)
                    .ThenBy(x => x.firstName);

                var xmlDoc = new XDocument(new XElement("users"));
                
                foreach (var us in users)
                {
                    xmlDoc.Root.Add(new XElement("user", 
                            new XAttribute("first-name", us.firstName != null?us.firstName:string.Empty), 
                            new XAttribute("last-name", us.lastName),
                            new XElement("sold-products")));

                    var productElements = xmlDoc.Root.Elements()
                        .SingleOrDefault(x => x.Name == "user"
                        && x.Attribute("first-name")?.Value == $"{us.firstName}"
                        && x.Attribute("last-name").Value == $"{us.lastName}")
                        .Element("sold-products");

                    foreach (var sp in us.soldProducts)
                    {
                        productElements.Add(new XElement("product",
                             new XElement("name", sp.name),
                             new XElement("price", sp.price)));
                    }                    
                }
                xmlDoc.Save("FilesExported/Xml/2.Users-sold-products.xml");
            }
        }

        static void GetCategoriesXml()
        {
            using(var db = new ProductShopDbContext())
            {
                var categories = db.Categories
                    .Include(x => x.CategoriesProducts)
                    .ThenInclude(x => x.Product)
                    .Select(x => new
                    {
                        name = x.Name,
                        productCount = x.CategoriesProducts.Count(),
                        averagePrice = x.CategoriesProducts.Average(y => y.Product.Price),
                        totalRevenue = x.CategoriesProducts.Sum(z => z.Product.Price)
                    }).ToList()
                    .OrderByDescending(x => x.productCount);

                var xmlDoc = new XDocument(new XElement("categories"));

                foreach (var cat in categories)
                {
                    xmlDoc.Root.Add(new XElement("category",
                        new XAttribute("name", cat.name),
                        new XElement("products-count", cat.productCount),
                        new XElement("average-price", cat.averagePrice),
                        new XElement("total-revenue", cat.totalRevenue)));
                }

                xmlDoc.Save("FilesExported/Xml/3.Categories-by-products.xml");
            }
        }

        static void GetUsersWithSoldItemsXml()
        {
            using (var db = new ProductShopDbContext())
            {
                var users = db.Users
                    .Where(x => x.SoldProducts.Any())
                    .Select(x => new
                    {
                        firstName = x.FirstName,
                        lastName = x.LastName,
                        age = x.Age,
                        soldProducts = x.SoldProducts.Select(y => new
                        {
                            name = y.Name,
                            price = y.Price
                        }).ToList()
                    }).ToList()
                    .OrderByDescending(x => x.soldProducts.Count())
                    .ThenBy(x => x.lastName);

                var xmlDoc = new XDocument(new XElement("users",
                    new XAttribute("count", users.Count())));

                foreach (var us in users)
                {
                    if(us.firstName == null && us.age == null)
                    {
                        xmlDoc.Root.Add(new XElement("user",
                            new XAttribute("last-name", us.lastName),
                            new XElement("sold-products",
                            new XAttribute("count", us.soldProducts.Count()))));

                        var productElements = xmlDoc.Root.Elements()
                        .FirstOrDefault(x => x.Name == "user"
                        && x.Attribute("last-name").Value == $"{us.lastName}")
                        .Element("sold-products");

                        foreach (var sp in us.soldProducts)
                        {
                            productElements.Add(new XElement("product",
                                 new XAttribute("name", sp.name),
                                 new XAttribute("price", sp.price)));
                        }
                    }
                    else if(us.firstName == null)
                    {
                        xmlDoc.Root.Add(new XElement("user",
                            new XAttribute("last-name", us.lastName),
                            new XAttribute("age", us.age),
                            new XElement("sold-products",
                            new XAttribute("count", us.soldProducts.Count()))));

                        var productElements = xmlDoc.Root.Elements()
                        .FirstOrDefault(x => x.Name == "user"
                        && x.Attribute("last-name").Value == $"{us.lastName}")
                        .Element("sold-products");

                        foreach (var sp in us.soldProducts)
                        {
                            productElements.Add(new XElement("product",
                                 new XAttribute("name", sp.name),
                                 new XAttribute("price", sp.price)));
                        }
                    }
                    else if(us.age == null)
                    {
                        xmlDoc.Root.Add(new XElement("user",
                            new XAttribute("first-name", us.firstName),
                            new XAttribute("last-name", us.lastName),
                            new XElement("sold-products",
                            new XAttribute("count", us.soldProducts.Count()))));

                        var productElements = xmlDoc.Root.Elements()
                        .FirstOrDefault(x => x.Name == "user"
                        && x.Attribute("first-name")?.Value == $"{us.firstName}"
                        && x.Attribute("last-name").Value == $"{us.lastName}")
                        .Element("sold-products");

                        foreach (var sp in us.soldProducts)
                        {
                            productElements.Add(new XElement("product",
                                 new XAttribute("name", sp.name),
                                 new XAttribute("price", sp.price)));
                        }
                    }
                    else
                    {
                        xmlDoc.Root.Add(new XElement("user",
                            new XAttribute("first-name", us.firstName),
                            new XAttribute("last-name", us.lastName),
                            new XAttribute("age", us.age),
                            new XElement("sold-products",
                            new XAttribute("count", us.soldProducts.Count()))));

                        var productElements = xmlDoc.Root.Elements()
                        .FirstOrDefault(x => x.Name == "user"
                        && x.Attribute("first-name")?.Value == $"{us.firstName}"
                        && x.Attribute("last-name").Value == $"{us.lastName}")
                        .Element("sold-products");

                        foreach (var sp in us.soldProducts)
                        {
                            productElements.Add(new XElement("product",
                                 new XAttribute("name", sp.name),
                                 new XAttribute("price", sp.price)));
                        }
                    }
                }
                xmlDoc.Save("FilesExported/Xml/4.Users-and-products.xml");
            }
        }

        private static void ResetDatabase()
        {
            using(var db = new ProductShopDbContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
        }
    }
}
