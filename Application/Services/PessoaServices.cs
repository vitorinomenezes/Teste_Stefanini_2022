using Application.Interfaces;
using Domain.Interfaces;
using Entities;
using System;
using System.Reflection;

namespace Application.Services
{
    public sealed class PessoaServices : INterfacePessoa
    {
        private readonly IPessoa _IApp;
        public PessoaServices(IPessoa iapp)
        {
            _IApp = iapp;
        }
        public Task<int> Add(Pessoa Objeto)
        {
           return _IApp.Add(Objeto);  
        }

        public Task<int> Delete(Pessoa Objeto)
        {
            return _IApp.Delete(Objeto);
        }

       
        public Task<List<Pessoa>> GetAll()
        {
            return _IApp.GetAll();
        }

        public Task<Pessoa> GetById(int id)
        {
            return _IApp.GetById(id);
        }

       
        public Task<int> Save(Pessoa model)
        {
            return _IApp.Save(model);
        }

        public Task<int> Update(Pessoa Objeto)
        {
            return _IApp.Update(Objeto);
        }
    }
}
