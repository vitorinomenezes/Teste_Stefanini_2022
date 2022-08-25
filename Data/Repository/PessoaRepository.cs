using Data.Repository.Generic;
using Domain.Interfaces;
using Entities;

namespace Data.Repository
{
    public class PessoaRepository : RepositoryGenerics<Pessoa>, IPessoa
    {
    }
}
