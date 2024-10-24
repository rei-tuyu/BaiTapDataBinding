using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BaiTapDataBinding.Models
{
    public partial class SchoolContexDB : DbContext
    {
        public SchoolContexDB()
            : base("name=SchoolContexDB")
        {
        }

        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
