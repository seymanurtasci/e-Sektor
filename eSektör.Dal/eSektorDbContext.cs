using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSektorEntities;
using eSektör.Entites.Mappings;

namespace eSektör.Dal
{
    class eSektorDbContext :DbContext
    {
        public eSektorDbContext():base("Server=esektor.database.windows.net;Database=eSektor;User Id=eSektor;Password = Alaf9090;")
        {

        }

        public DbSet<Authorize> Authorizes { get; set; }
        public DbSet<Members> Members { get; set; }
        public DbSet<MemberSpeciality> MemberSpecialities { get; set; }
        public DbSet<OfferDetail> OfferDetails { get; set; }
        public DbSet<Offers> Offers { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<eSektorEntities.Task> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MemberMapping());
            modelBuilder.Configurations.Add(new OffresMapping());
            modelBuilder.Configurations.Add(new TaskMapping());
            modelBuilder.Configurations.Add(new AuthorizeMapping());
            modelBuilder.Configurations.Add(new MemberSpecialityMapping());
            modelBuilder.Configurations.Add(new PaymentMethodMapping());
            modelBuilder.Configurations.Add(new SpecialityMapping());
            modelBuilder.Configurations.Add(new OfferDetailMapping());
            base.OnModelCreating(modelBuilder);
        }

    }
}
