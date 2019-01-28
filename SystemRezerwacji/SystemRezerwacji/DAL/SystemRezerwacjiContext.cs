using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SystemRezerwacji.Models;

namespace SystemRezerwacji.DAL
{
    public class SystemRezerwacjiContext : DbContext
    {
        public SystemRezerwacjiContext() : base("DefaultConnection")
        { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //zignoruj schemat tworzenia liczby mnogiej (zastosujemy własne nazwy)
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //poprawna obsługa typu DateTime
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));

            base.OnModelCreating(modelBuilder);
        }

        //customowe nazwy tabel w liczbie mnogiej
        public DbSet<Relacja> Relacje { get; set; }
        public DbSet<Polaczenie> Polaczenia { get; set; }
        public DbSet<Podrozny> Podrozni { get; set; }
        public DbSet<Rezerwacja> Rezerwacje { get; set; }
        public DbSet<StatusRezerwacji> StatusyRezerwacji { get; set; }
    }
}