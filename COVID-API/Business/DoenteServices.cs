using Business.Interfaces;
using DataBase.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Business
{
    public class DoenteServices : IDoenteServices
    {
        public Task<Doente> Create(Doente doente, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
