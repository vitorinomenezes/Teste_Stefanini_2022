using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public sealed class CidadeServices : INterfaceCidade
    {
        private readonly ICidade _IApp;
        public CidadeServices(ICidade iapp)
        {
            _IApp = iapp;
        }
        public Task<int> Add(Cidade model)
        {
            return _IApp.Add(model);
        }

        public Task<int> Delete(Cidade model)
        {
            return _IApp.Delete(model);
        }


        public Task<List<Cidade>> GetAll()
        {
            return _IApp.GetAll();
        }

        public Task<Cidade> GetById(int id)
        {
            return _IApp.GetById(id);
        }


        public Task<int> Save(Cidade model)
        {
            return _IApp.Save(model);
        }

        public Task<int> Update(Cidade model)
        {
            return _IApp.Update(model);
        }
    }
}
