﻿using BackendApi.Database.Entities;
using Microsoft.EntityFrameworkCore;


namespace BackendApi.Database.Context
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
            // modelbuilder.HasDefaultSchema("Database/Migration");
        }

        public virtual DbSet<E090REP> E090rep { get; set; }
        public virtual DbSet<E085CLI> E085cli { get; set; }
        public virtual DbSet<T009PPD> Usu_t009ppd { get; set; }
        public virtual DbSet<T009PPI> Usu_t009ppi { get; set; }
        public virtual DbSet<E085HCL> E085hcls { get; set; }
        public virtual DbSet<E075PRO> E075pros { get; set; }
        public virtual DbSet<E075PRO1> E075pros1 { get; set; }
        public virtual DbSet<E120IPD> E120ipds { get; set; }
        public virtual DbSet<E120IPD1> E120ipds1 { get; set; }
        public virtual DbSet<E120RAT> E120rats { get; set; }
        public virtual DbSet<E120RAT1> E120rats1 { get; set; }
    }
}
