using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Login.DataLayer
{
    public partial class LoginSignupModel : DbContext
    {
        public LoginSignupModel()
            : base("name=LoginSignupModel")
        {
        }

        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<SignUp> SignUps { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Login>()
                .HasMany(e => e.SignUps)
                .WithRequired(e => e.Login)
                .WillCascadeOnDelete(false);
        }
    }
}
