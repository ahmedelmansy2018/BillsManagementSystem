using Business_Objects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_layer
{
   public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VNDDTL>().HasData(
                new VNDDTL { VNDCOD = 1  ,VNDNAM="Ahmed"},
                new VNDDTL { VNDCOD = 2, VNDNAM = "ALi" },
                new VNDDTL { VNDCOD = 3, VNDNAM = "Saad" }
                );
            modelBuilder.Entity<ITMDTL>().HasData(
                new ITMDTL { ITMCOD = 1, ITMNAM = "panana" ,ITMPRC =50},
                new ITMDTL { ITMCOD = 2, ITMNAM = "tea", ITMPRC = 30 },
                new ITMDTL { ITMCOD = 3, ITMNAM = "suger", ITMPRC = 40 }
                );
        }
        public DbSet<VNDDTL> VNDDTLs { get; set; }
        public DbSet<ITMDTL> ITMDTLs { get; set; }
        public DbSet<BILHDR> BILHDRs { get; set; }
        public DbSet<BILDTL> BILDTLs { get; set; }
    }
}
