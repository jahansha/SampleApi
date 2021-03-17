using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Models
{
    public interface IDataManager
    {
         List<Claim> GetClaims();
         List<Member>GetMembers();
       
    }
}
