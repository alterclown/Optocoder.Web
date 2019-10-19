using Optocoder.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Optocoder.Repository.Repository
{
    interface ICompany
    {

        ICollection<CompanyAdd> get();
    }
    public class Company : ICompany
    {
        private readonly OptocoderContext optocoderContext;
        public Company(OptocoderContext db)
        {
            optocoderContext = db;
        }
        public ICollection<CompanyAdd> get()
        {
            var companies = optocoderContext.CompanyAdd.ToList();
            return companies;
        }
      
    }
}
