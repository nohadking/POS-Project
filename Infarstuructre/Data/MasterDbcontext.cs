using Domin.Entity;

using Infarstuructre.ViewModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;


namespace Infarstuructre.Data
{
	public class MasterDbcontext : IdentityDbContext<ApplicationUser>
	{
		public MasterDbcontext(DbContextOptions<MasterDbcontext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

            //***********************************************************


			builder.Entity<VwUser>(entity =>
			{
				entity.HasNoKey();
				entity.ToView("VwUsers");
			});


			//*********************************************************  


			builder.Entity<TBViewProduct>(entity =>
			{
				entity.HasNoKey();
				entity.ToView("ViewProduct");
			});


			//*********************************************************  
			

			builder.Entity<TBViewInvoseHeder>(entity =>
			{
				entity.HasNoKey();
				entity.ToView("ViewInvoseHeder");
			});


			//*********************************************************  

			//---------------------------------
			builder.Entity<TBEmailAlartSetting>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBEmailAlartSetting>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");  
            builder.Entity<TBEmailAlartSetting>()
           .Property(b => b.Active)
           .HasDefaultValueSql("((1))");

            //---------------------------------   

            //---------------------------------
            builder.Entity<TBCategory>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBCategory>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");
            builder.Entity<TBCategory>()
           .Property(b => b.Active)
           .HasDefaultValueSql("((1))");

			//---------------------------------   
			//---------------------------------
			builder.Entity<TBProduct>()
		   .Property(b => b.DateTimeEntry)
		   .HasDefaultValueSql("getdate()");
			builder.Entity<TBProduct>()
		   .Property(b => b.CurrentState)
		   .HasDefaultValueSql("((1))");
			builder.Entity<TBProduct>()
		   .Property(b => b.Active)
		   .HasDefaultValueSql("((1))");

			//---------------------------------  
			//---------------------------------
			builder.Entity<TBCustomerCategorie>()
		   .Property(b => b.DateTimeEntry)
		   .HasDefaultValueSql("getdate()");
			builder.Entity<TBCustomerCategorie>()
		   .Property(b => b.CurrentState)
		   .HasDefaultValueSql("((1))");
			builder.Entity<TBCustomerCategorie>()
		   .Property(b => b.Active)
		   .HasDefaultValueSql("((1))");

			//---------------------------------  
			//---------------------------------
			builder.Entity<TBInvoseHeder>()
		   .Property(b => b.DateTimeEntry)
		   .HasDefaultValueSql("getdate()");
			builder.Entity<TBInvoseHeder>()
		   .Property(b => b.CurrentState)
		   .HasDefaultValueSql("((1))");
			builder.Entity<TBInvoseHeder>()
		   .Property(b => b.OutstandingBill)
		   .HasDefaultValueSql("((0))");

			//---------------------------------  
			//---------------------------------
			builder.Entity<TBPaymentMethod>()
		   .Property(b => b.DateTimeEntry)
		   .HasDefaultValueSql("getdate()");
			builder.Entity<TBPaymentMethod>()
		   .Property(b => b.CurrentState)
		   .HasDefaultValueSql("((1))");
			builder.Entity<TBPaymentMethod>()
		   .Property(b => b.Active)
		   .HasDefaultValueSql("((1))");

			//---------------------------------  
		}
		//***********************************
		public DbSet<VwUser> VwUsers { get; set; }
       
        public DbSet<TBEmailAlartSetting> TBEmailAlartSettings { get; set; } 
        public DbSet<TBCategory> TBCategorys { get; set; } 
        public DbSet<TBProduct> TBProducts { get; set; } 
        public DbSet<TBViewProduct> ViewProduct { get; set; } 
        public DbSet<TBCustomerCategorie> TBCustomerCategories { get; set; } 
        public DbSet<TBInvoseHeder> TBInvoseHeders { get; set; } 
        public DbSet<TBViewInvoseHeder> ViewInvoseHeder { get; set; } 
        public DbSet<TBPaymentMethod> TBPaymentMethods { get; set; } 
       
    }
}
