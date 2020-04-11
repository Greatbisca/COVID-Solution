using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IDoenteServices
    {
        Task<Doente> Create(Doente doente, CancellationToken ct);
    }
}
