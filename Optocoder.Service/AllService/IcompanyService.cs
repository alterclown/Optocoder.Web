using Optocoder.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Optocoder.Data.Entities;
using System.Linq;

namespace Optocoder.Service.AllService
{
    interface IcompanyService
    {
        ICollection<CompanyAdd> get();
    }
    public class company : IcompanyService
    {
        private readonly OptocoderContext optocoderContext;
        public company(OptocoderContext db)
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
