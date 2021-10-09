using Business_Objects;
using Business_Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_layer.Repository
{
    public class ReposCaseHeader: IReposCaseHeader
    {
        private readonly DataContext _context;


        public ReposCaseHeader(DataContext context)
        {
            _context = context;
        }

        public void UpdateCase(int id,decimal Price)
        {
                    var NewEntity = new BILHDR { BILCOD= id ,BILPRC= Price  };
                    _context.BILHDRs.Attach(NewEntity);
                    _context.Entry(NewEntity).Property(r => r.BILPRC).IsModified = true;
                    _context.SaveChanges();
               
        }
    }
}

