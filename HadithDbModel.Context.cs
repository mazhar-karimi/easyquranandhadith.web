﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eqwh.web
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EQ_Hadith_6Entities : DbContext
    {
        public EQ_Hadith_6Entities()
            : base("name=EQ_Hadith_6Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<ACDR> ACDRs { get; set; }
        public virtual DbSet<Ahadith> Ahadiths { get; set; }
        public virtual DbSet<AhadithLayoutDetail> AhadithLayoutDetails { get; set; }
        public virtual DbSet<AhadithLayout> AhadithLayouts { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<HadithKindsACD> HadithKindsACDs { get; set; }
        public virtual DbSet<Intro> Introes { get; set; }
        public virtual DbSet<Kind> Kinds { get; set; }
        public virtual DbSet<Part> Parts { get; set; }
        public virtual DbSet<Ravi> Ravis { get; set; }
        public virtual DbSet<RaviAhadithACD> RaviAhadithACDs { get; set; }
        public virtual DbSet<Repetition> Repetitions { get; set; }
        public virtual DbSet<Tabqa> Tabqas { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<TagType> TagTypes { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<TopicsACD> TopicsACDs { get; set; }
        public virtual DbSet<TopicsAhadithACD> TopicsAhadithACDs { get; set; }
        public virtual DbSet<UnrepeatedAhadithAcd> UnrepeatedAhadithAcds { get; set; }
    }
}
