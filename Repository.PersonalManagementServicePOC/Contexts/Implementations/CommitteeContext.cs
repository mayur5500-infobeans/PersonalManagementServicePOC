using Microsoft.EntityFrameworkCore;
using Repository.PersonalManagementServicePOC.Contexts.Configurations;
using Repository.PersonalManagementServicePOC.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.PersonalManagementServicePOC.Context.Implementation
{
    public class CommitteeContext : DbContext
    {
        public CommitteeContext(DbContextOptions<CommitteeContext> options) : base(options)
        {   
        }
        public DbSet<CommitteeDto> Committees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration<CommitteeDto>(new CommitteeConfiguration());           
        }
    }
}
