using Domin.Entity;

using Infarstuructre.ViewModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph.Models;
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

            builder.Entity<TBViewInvose>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("ViewInvose");
            });


            //*********************************************************  



            //*********************************************************
            builder.Entity<TBViewPhotoHomeSliderContent>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("ViewPhotoHomeSliderContent");
            });


            //*********************************************************

               
            builder.Entity<TBViewExpense>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("ViewExpense");
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
            builder.Entity<TBInvose>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBInvose>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");

            //--------------------------------- 
            //*********************************************************
            //---------------------------------
            builder.Entity<TBHomeSliderContent>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBHomeSliderContent>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");
            //---------------------------------  
            //---------------------------------
            builder.Entity<TBPhotoHomeSliderContent>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBPhotoHomeSliderContent>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");
            //---------------------------------  
            //---------------------------------
            builder.Entity<TBServiceSectionStartHomeContent>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBServiceSectionStartHomeContent>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");
            //---------------------------------  
            //---------------------------------
            builder.Entity<TBAboutSectionStartHomeContent>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBAboutSectionStartHomeContent>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");
            //--------------------------------- 
            //---------------------------------
            builder.Entity<TBCategoryServic>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBCategoryServic>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");
            builder.Entity<TBCategoryServic>()
           .Property(b => b.Active)
           .HasDefaultValueSql("((1))");
            //---------------------------------
            //---------------------------------
            builder.Entity<TBCompanyInformation>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBCompanyInformation>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");

            //---------------------------------
            //---------------------------------
            builder.Entity<TBExpenseCategory>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBExpenseCategory>()
           .Property(b => b.CurrentState)
           .HasDefaultValueSql("((1))");
            builder.Entity<TBExpenseCategory>()
           .Property(b => b.Active)
           .HasDefaultValueSql("((1))");
            //--------------------------------- 
            //---------------------------------
            builder.Entity<TBExpense>()
           .Property(b => b.DateTimeEntry)
           .HasDefaultValueSql("getdate()");
            builder.Entity<TBExpense>()
           .Property(b => b.CurrentState)
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
        public DbSet<TBInvose> TBInvoses { get; set; }
        public DbSet<TBViewInvose> ViewInvose { get; set; }
        public DbSet<TBHomeSliderContent> TBHomeSliderContents { get; set; }
        public DbSet<TBPhotoHomeSliderContent> TBPhotoHomeSliderContents { get; set; }
        public DbSet<TBViewPhotoHomeSliderContent> ViewPhotoHomeSliderContent { get; set; }
        public DbSet<TBServiceSectionStartHomeContent> TBServiceSectionStartHomeContents { get; set; }
        public DbSet<TBAboutSectionStartHomeContent> TBAboutSectionStartHomeContents { get; set; }
        public DbSet<TBCategoryServic> TBCategoryServics { get; set; }
        public DbSet<TBBrandProduct> TBBrandProducts { get; set; }
        public DbSet<TBCompanyInformation> TBCompanyInformations { get; set; }
        public DbSet<TBExpenseCategory> TBExpenseCategorys { get; set; }
        public DbSet<TBExpense> TBExpenses { get; set; }
        public DbSet<TBViewExpense> ViewExpense { get; set; }


    }
}
