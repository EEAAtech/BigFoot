﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BigFoot
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BigFootEntities : DbContext
    {
        public BigFootEntities()
            : base("name=BigFootEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<UserData> UserDatas { get; set; }
        public virtual DbSet<ContentTypes> ContentTypes { get; set; }
        public virtual DbSet<Pages> Pages { get; set; }
        public virtual DbSet<Menus> Menus { get; set; }
        public virtual DbSet<SubMenus> SubMenus { get; set; }
    }
}
