using Microsoft.EntityFrameworkCore;
using Mozer.Models.Accounts.Entities;
using Mozer.Models.Invoices.Entities;
using Mozer.Models.Locations.Entities;
using Mozer.Models.Messages.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mozer.ServiceContext.DatabaseContext
{
    public class MozerContext:DbContext
    {
        public MozerContext(DbContextOptions<MozerContext> options):base(options)
        {

        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<ProfileModel> Profiles { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<InvoiceModel> Invoices { get; set; }
        public DbSet<InvoiceItemModel> InvoiceItems { get; set; }
        public DbSet<AddressModel> Addresses { get; set; }
        public DbSet<CityModel> Cities { get; set; }
        public DbSet<ProvinceModel> Provinces  { get; set; }
        public DbSet<MessageModel> Messages{ get; set; }
        public DbSet<MessageItemModel> MessageItems { get; set; }
        public DbSet<MessageItemActionModel> MessageItemActions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
