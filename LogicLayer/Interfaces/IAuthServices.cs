using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.DTO;

namespace LogicLayer.Interfaces
{
    public interface IAuthServices
    {
        Task<string> GenerateToken(TokenUser user);
    }
}
