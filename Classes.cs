using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Tovar> Tovar { get; set; }
        public DbSet<Korzina> Korzina { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Magazin;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public class Tovar
    {
        public int Id { get; set; }

        public string Nazv { get; set; }

        public int Kolvo { get; set; }

        public int Stoimost { get; set; }

        public string Pic { get; set; }
        public string Opis { get; set; }

    }

    public class Korzina
    {
        public int Id { get; set; }
        public int User { get; set; }
        public int TovaraIdishnik { get; set; }

        public string Nazv { get; set; }

        public int Kolvo { get; set; }

        public int Stoimost { get; set; }

        public string Pic { get; set; }
    }
}
