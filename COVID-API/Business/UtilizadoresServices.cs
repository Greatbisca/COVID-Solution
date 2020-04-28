using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business
{
    public class UtilizadoresServices : IUtilizadoresServices
    {
        public Task<string> ValidateLoginAsync(string username, string password, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
