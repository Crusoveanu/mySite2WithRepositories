using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using mySite2.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mySite2.Data
{
    public class DBInitialize
    {
        public static void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
            var context = serviceScope.ServiceProvider.GetService<LibraryDbContext>();

            var Mihai = new Customer { Name = "Crusoveanu Mihai" };
            var Andrei = new Customer { Name = "Bulacu Andrei" };
            var David = new Customer { Name = "David Mihai" };
            context.Customers.Add(Mihai);
            context.Customers.Add(Andrei);
            context.Customers.Add(David);

            var authorIon = new Author
            {
                Name = "Ion Barbu",
                Books = new List<Book>()
                {
                    new Book {Title = "Joc secund"},
                    new Book {Title = "Cartea alba"}
                }
            };

            var authorLiviu = new Author
            {
                Name = "Liviu Rebreanu",
                Books = new List<Book>()
                {
                    new Book {Title = "Ion"},
                    new Book {Title = "Padurea spanzuratilor"},
                    new Book {Title = "Adam si Eva"}
                }
            };

            context.Authors.Add(authorIon);
            context.Authors.Add(authorLiviu);

            context.SaveChanges();
            }
        }
    }
}
