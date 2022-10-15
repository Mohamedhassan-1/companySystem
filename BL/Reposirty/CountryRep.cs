using AutoMapper;
using Pratical.BL.interfaces;
using Pratical.DAL;
using Pratical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.DAL.Entities;

namespace Pratical.BL.Reposirty
{
    public class CountryRep : ICountryRep
    {
        private DBContainer dBContainer;
        private readonly IMapper mapper;

        public CountryRep(DBContainer dBContainer, IMapper mapper)
        {
            this.dBContainer = dBContainer;
            this.mapper = mapper;
        }
       
        public IQueryable<CounteryVM> Get()
        {
            return dBContainer.Country.Select(a => new CounteryVM
            {
               CountryName=a.CountryName
            });
        }

        public CounteryVM GetbyId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
