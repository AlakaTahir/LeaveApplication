using LeaveApplication.Model.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveApplication.Migrations
{
    public class LeaveApplicationDataBaseContext : DbContext
    {
        
        public LeaveApplicationDataBaseContext(DbContextOptions<LeaveApplicationDataBaseContext> options) : base(options)
        {
        }

        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<LeaveTypeInfo> LeaveTypeInfos { get; set; }
        public DbSet<LeaveApplicationInfo> LeaveApplicationInfos { get; set; }
        public DbSet<RecallInformation> RecallInformations { get; set; }
        public DbSet<AccessTypeInfo> AccessTypeInfos { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>().ToTable("UserInfos");
            modelBuilder.Entity<LeaveTypeInfo>().ToTable("LeaveTypeInfos");
            modelBuilder.Entity<LeaveApplicationInfo>().ToTable("LeaveApplicationInfos");
            modelBuilder.Entity<RecallInformation>().ToTable("RecallInformations");
            modelBuilder.Entity<AccessTypeInfo>().ToTable("AccessTypeInfos");
        }
    }

}

   



    
   



