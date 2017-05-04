using System.Collections.Generic;
using BaciDolci.Models.EntityModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BaciDolci.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BaciDolciContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BaciDolciContext context)
        {
            if (!context.Roles.Any(role => role.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manage = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("Admin");
                manage.Create(role);
            }

            if (!context.Roles.Any(role => role.Name == "Customer"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manage = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("Customer");
                manage.Create(role);
            }

            context.NewsItems.AddOrUpdate(
                new NewsItem()
                {
                    Id = 1,
                    Name = "Welcome to our new Sweet Shop!",
                    Image = "../../Content/images/cafe.jpg",
                    Content = "Just another sweet shop?\r\n\r\nIt’s much more than that.  We wanted to recreate the feel of an artisan chocolate shop and give you the chance to choose your favourite pralines one by one and fill your box as if you were standing at our shop counter in 24, Rue du Lombard, Brussels.  We have selected SEPTANTE (the Belgian word for seventy) pralines, some with classic flavours and some more exotic.  So, how do you choose from all these delicious flavours?  Well, according to our master chocolatiers, the only way is to try them all!\r\nWe like to think we’ve put our handmade Belgian chocolates in a new box! Welcome to  24 \"Praque\"  blvd and enjoy!"
                },

                new NewsItem()
                {
                    Id = 6,
                    Name = "Special  20% Birthday Discount",
                    Image = "../../Content/images/candles.jpg",
                    Content = "Take advantage of exclusive promotions and receive 20% discount! Within our range, our Gourmet Chocolate Dessersts make the perfect luxury gift for him or for her when looking for something as special as a birthday gift or an anniversary gift,  as well as all other special occasions.  You can also personalise them.  Our Celebration Chocolate Desserts are a perfect premium chocolate gift for all ‘chocoholics’ and gourmet chocolate lovers.  Tailored to all special occasions and events throughout the year including fathers day, mothers day, valentines day, Easter, Christmas, and are designed to offer that special surprise treat for any fine chocolate enthusiast and connoisseur.  \r\n\r\nWelcome from all the team at The Gourmet Chocolate Desserts!   "
                },

                new NewsItem()
                {
                    Id = 8,
                    Name = "Happy Easter Chocolate Celebration ",
                    Image = "../../Content/images/easterbunny.jpg",
                    Content = "Celebrate Easter with a chocolate-filled gift basket that offers something delicious for everyone! Pre-printed with a Happy Easter message on pink ribbon. Our Chocolate Celebrations Gift Basket really gets the Easter party started! Whether you\'re sending to family far away, sharing with friends at an Easter gathering, or opening at home, there\'s plenty to make everyone smile. The sumptuous selection features two Gold Gift Boxes with our famed milk, dark, and white chocolates with classic Belgian fillings like silky ganaches, creamy pralines, rich caramels, fruits, and nuts. Also inside: our Signature Truffles; Individually Wrapped Dark Chocolate Caramels and Milk Chocolate Truffles, plus one small and one large Milk Chocolate Bar. Tied with a festive pink ribbon."
                },

                new NewsItem()
                {
                    Id = 15,
                    Name = "Let's party!",
                    Image = "../../Content/images/kids.jpg",
                    Content = "Celebrate your special kid\'s day with us! Our party professionals will take care of all the planning, including decorations, games and food. So all you have to do is enjoy and have fun. Book your kid\'s party with us now. Be it in-store or at a venue of your choice (with take away party package), get ready for a fun-filled day of excitement. For in-store party package, our party professionals will take care of all the planning, décor, food and games so you can just kick back, relax and revel in fun\r\n\r\nParty Invitation Cards will be handed to each birthday celebrant to invite friends. All invitees will receive gifts, a Happy Meal® of their choice, as well as prizes to win from games. To top it off, a specially made birthday cake (optional) and an exclusive gift awaits the birthday celebrant. The best parties are all made of these!\r\n"
                },

                new NewsItem()
                {
                    Id = 20,
                    Name = "Happy Birthday Baci Dolci!",
                    Image = "../../Content/images/Sparkler.gif",
                    Content = "We\'re excited to announce that we have now been here for 6 year! In celebration of that, we are offering many gifts for our customers!\r\nLimited time only!!!  You can always visit Baci Dolci Desserts Sweer Shop to see our current prices and enjoy the atmosphere. Stop in and see us soon to experience competitive chocolate prices and superior customer service!"
                });


            context.Categories.AddOrUpdate(

                new Category()
                {
                    Id = 84,
                    Name = "Brownies",
                    Image = "../../Content/images/br7.jpg",

                    Products = new List<Product>()
                    {
                        new Product()
                        {
                            Name = "Snickers Poke Brownie",
                            Image = "../../Content/images/br1.jpg",
                            Price = 3m
                        },

                        new Product()
                        {
                            Name = "Caramel Kisses Brownie",
                            Image = "../../Content/images/caramel1.jpg",
                            Price = 3m
                        },

                        new Product()
                        {
                            Name = "Red Velvet Brownie",
                            Image = "../../Content/images/br3.jpg",
                            Price = 3m
                        },

                        new Product()
                        {
                            Name = "Cherry Mocha Almond Brownie",
                            Image = "../../Content/images/br4.jpg",
                            Price = 3m
                        },

                        new Product()
                        {
                            Name = "Blackberry Brownie",
                            Image = "../../Content/images/br5.png",
                            Price = 3m
                        },

                        new Product()
                        {
                            Name = "Cherry Garcia Brownie",
                            Image = "../../Content/images/br6.jpg",
                            Price = 3m
                        },

                        new Product()
                        {
                            Name = "Raspberry Brownie",
                            Image = "../../Content/images/br7.jpg",
                            Price = 3m
                        },

                        new Product()
                        {
                            Name = "Nutella Brownie",
                            Image = "../../Content/images/br8.jpg",
                            Price = 3m
                        },

                        new Product()
                        {
                            Name = "Peanut Butter Brownie",
                            Image = "../../Content/images/br9.jpg",
                            Price = 3m
                        }

                    }
                },

                new Category()
                {
                    Id = 85,
                    Name = "Cakes",
                    Image = "../../Content/images/cake10.jpg",

                    Products = new List<Product>()
                    {
                        new Product()
                        {
                            Name = "Floral Cake",
                            Image = "../../Content/images/cake10.jpg",
                            Price = 200m
                        },

                         new Product()
                        {
                            Name = "Vintage Cake",
                            Image = "../../Content/images/cake2.jpg",
                            Price = 220m
                        },

                          new Product()
                        {
                            Name = "Red Fruit Cake",
                            Image = "../../Content/images/cake11.jpg",
                            Price = 40m
                        },

                           new Product()
                        {
                            Name = "Nutella Cake",
                            Image = "../../Content/images/cake4.png",
                            Price = 30m
                        },
                            new Product()
                        {
                            Name = "Flower Cake",
                            Image = "../../Content/images/cake9.jpg",
                            Price = 160m
                        },

                             new Product()
                        {
                            Name = "Vanilla Cake",
                            Image = "../../Content/images/cake8.jpg",
                            Price = 25m
                        }
                    }
                },

             

                new Category()
                {
                    Id = 86,
                    Name = "Truffles",
                    Image = "../../Content/images/tr2.jpg",

                    Products = new List<Product>()
                    {
                        new Product()
                        {
                            Name = "Coconut Truffle",
                            Image = "../../Content/images/tr1.jpg",
                            Price = 10m
                        },

                        new Product()
                        {
                            Name = "Orange Cocoa Truffle",
                            Image = "../../Content/images/tr2.jpg",
                            Price = 10m
                        },

                        new Product()
                        {
                            Name = "Classic French Truffle",
                            Image = "../../Content/images/tr3.jpg",
                            Price = 10m
                        },

                        new Product()
                        {
                            Name = "Almond Butter Cocoa Truffle",
                            Image = "../../Content/images/tr4.jpg",
                            Price = 12m
                        },

                        new Product()
                        {
                            Name = "Original Truffle",
                            Image = "../../Content/images/tr5.jpg",
                            Price = 10m
                        }
                    }
                },

                new Category()
                {
                    Id = 87,
                    Name = "Biscuits",
                    Image = "../../Content/images/bisq.jpg",

                    Products = new List<Product>()
                    {
                        new Product()
                        {
                            Name = "Strawberry Biscuits",
                            Image = "../../Content/images/bis2.jpg",
                            Price = 6m
                        },

                        new Product()
                        {
                            Name = "Choco Nuts Biscuits",
                            Image = "../../Content/images/bisq.jpg",
                            Price = 6m
                        },

                        new Product()
                        {
                            Name = "Grandma's Buttermilk Biscuits",
                            Image = "../../Content/images/bis3.jpg",
                            Price = 6m
                        },

                        new Product()
                        {
                            Name = "Star Biscuits",
                            Image = "../../Content/images/bis4.jpg",
                            Price = 4m
                        },

                        new Product()
                        {
                            Name = "Nutella Biscuits",
                            Image = "../../Content/images/bis5.jpg",
                            Price = 6m
                        }

                    }
                },

                new Category()
                {
                    Id = 88,
                    Name = "Patisserie",
                    Image = "../../Content/images/pat4.jpg",

                    Products = new List<Product>()
                    {
                        new Product()
                        {
                            Name = "Nutella Biscuits",
                            Image = "../../Content/images/pat1.jpg",
                            Price = 5m
                        },

                         new Product()
                        {
                            Name = "Modern Patisserie",
                            Image = "../../Content/images/pat2.jpg",
                            Price = 5m
                        },

                          new Product()
                        {
                            Name = "Regal Patisserie",
                            Image = "../../Content/images/pat3.jpg",
                            Price = 5m
                        },

                           new Product()
                        {
                            Name = "Amore Patisserie",
                            Image = "../../Content/images/pat4.jpg",
                            Price = 5m
                        },

                            new Product()
                        {
                            Name = "Le Croissant",
                            Image = "../../Content/images/pat5.jpg",
                            Price = 4m
                        },

                            new Product()
                        {
                            Name = "Fusion Patisserie",
                            Image = "../../Content/images/pat6.jpg",
                            Price = 5m
                        }
                    }
                },

                   new Category()
                   {
                       Id = 89,
                       Name = "Nouvelle",
                       Image = "../../Content/images/n2.jpg",

                       Products = new List<Product>()
                    {
                        new Product()
                        {
                            Name = "Caramel Kiss",
                            Image = "../../Content/images/n2.jpg",
                            Price = 2.5m
                        },

                        new Product()
                        {
                            Name = "Choco Dream",
                            Image = "../../Content/images/n3.jpg",
                            Price = 3m
                        },

                        new Product()
                        {
                            Name = "Icecream Flower",
                            Image = "../../Content/images/n4.jpg",
                            Price = 3m
                        },

                        new Product()
                        {
                            Name = "Rainbow",
                            Image = "../../Content/images/n5.jpg",
                            Price = 2m
                        },

                        new Product()
                        {
                            Name = "Sun Jelly",
                            Image = "../../Content/images/n1.png",
                            Price = 2m
                        },

                        new Product()
                        {
                            Name = "Bouquet",
                            Image = "../../Content/images/n7.jpg",
                            Price = 2m
                        }
                    }

                },

                new Category()
                {
                    Id = 90,
                    Name = "Cupcakes",
                    Image = "../../Content/images/cup13.jpg",

                    Products = new List<Product>()
                    {
                        new Product()
                        {
                            Name = "Strawberry Cupcake",
                            Image = "../../Content/images/cup1.jpg",
                            Price = 2m
                        },

                        new Product()
                        {
                            Name = "Cherry Cupcake",
                            Image = "../../Content/images/cup2.jpg",
                            Price = 2m
                        },

                        new Product()
                        {
                            Name = "Funfetti Angel Cupcake",
                            Image = "../../Content/images/cup3.jpg",
                            Price = 2m
                        },

                        new Product()
                        {
                            Name = "Oreo Cupcake",
                            Image = "../../Content/images/cup4.jpg",
                            Price = 2m
                        },

                        new Product()
                        {
                            Name = "Dark Chocolate Cupcake",
                            Image = "../../Content/images/cup5.jpg",
                            Price = 2m
                        },

                        new Product()
                        {
                            Name = "Andes Mint Cupcake",
                            Image = "../../Content/images/cup6.png",
                            Price = 2m
                        },

                        new Product()
                        {
                            Name = "Black Forest Cupcake",
                            Image = "../../Content/images/cup7.jpg",
                            Price = 2m
                        },

                        new Product()
                        {
                            Name = "Cannoli Cupcake",
                            Image = "../../Content/images/cup8.jpg",
                            Price = 2m
                        },

                        new Product()
                        {
                            Name = "Chocolate Bourbon Cupcake",
                            Image = "../../Content/images/cup9.jpg",
                            Price = 2m
                        },

                        new Product()
                        {
                            Name = "Sangria Cupcake",
                            Image = "../../Content/images/cup10.jpg",
                            Price = 2m
                        },

                        new Product()
                        {
                            Name = "Fruity Pebble Cupcake",
                            Image = "../../Content/images/cup11.png",
                            Price = 2m
                        },

                        new Product()
                        {
                            Name = "Creme Brulee Cupcake",
                            Image = "../../Content/images/cup12.jpg",
                            Price = 2m
                        }
                    }

                },

                new Category()
                {
                    Id = 91,
                    Name = "Macarons",
                    Image = "../../Content/images/mac7.jpg",

                    Products = new List<Product>()
                    {
                        new Product()
                        {
                            Name = "Almond Raspberry Macarons",
                            Image = "../../Content/images/mac2.jpg",
                            Price = 2m
                        },

                        new Product()
                        {
                            Name = "Mint Macarons",
                            Image = "../../Content/images/mac3.jpg",
                            Price = 2m
                        },

                        new Product()
                        {
                            Name = "Lemon Macarons",
                            Image = "../../Content/images/mac4.jpg",
                            Price = 2m
                        },

                        new Product()
                        {
                            Name = "Lavender Honey Macaron",
                            Image = "../../Content/images/mac5.jpeg",
                            Price = 2m
                        },

                        new Product()
                        {
                            Name = "Blueberry Macarons",
                            Image = "../../Content/images/mac6.jpg",
                            Price = 2m
                        },

                        new Product()
                        {
                            Name = "Pineapple Macarons",
                            Image = "../../Content/images/mac1.jpg",
                            Price = 2m
                        }
                    }
                },

                new Category()
                {
                    Id = 92,
                    Name = "Donuts",
                    Image = "../../Content/images/donut.jpg",

                    Products = new List<Product>()
                    {
                        new Product()
                        {
                            Name = "Magnificent Six",
                            Image = "../../Content/images/don8.jpg",
                            Price = 12m
                        },

                         new Product()
                        {
                            Name = "Fantasy",
                            Image = "../../Content/images/don2.jpg",
                            Price = 12m
                        },

                          new Product()
                        {
                            Name = "Fruity",
                            Image = "../../Content/images/don5.jpg",
                            Price = 12m
                        },

                           new Product()
                        {
                            Name = "Selection",
                            Image = "../../Content/images/don7.jpg",
                            Price = 12m
                        },

                            new Product()
                        {
                            Name = "Express",
                            Image = "../../Content/images/don3.jpg",
                            Price = 12m
                        }
                    }
                });
        




        //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
