using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace VVAResto.Models
{
    public class BddContext : DbContext
    {
        public DbSet<Allergie> Allergies { get; set; }
        public DbSet<Annulation> Annulations { get; set; }
        public DbSet<Carte> Cartes { get; set; }
        public DbSet<Composition> Compositions { get; set; }
        public DbSet<Indication> Indications { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Plat> Plats { get; set; }
        public DbSet<Profil> Profils { get; set; }
        public DbSet<Repas> Repas { get; set; }
        public DbSet<TypeMenu> TypeMenu { get; set; }
        public DbSet<TypePlat> TypePlats { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    Database.SetInitializer<BddContext>(null);
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}