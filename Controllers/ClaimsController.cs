using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        private DataManager _dataManager;

        public ClaimsController(DataManager dataMgr)
        {
            this._dataManager = dataMgr;

        }
        
        [HttpGet]
        [Route("GetClaims/{someDate}")]
        // Example:
        //https://localhost:44337/api/Claims/GetMembers/10-06-2022
        public List<Claim>GetClaims(DateTime someDate)
        {
            return  _dataManager.GetClaims().Where( x=>x.ClaimDate==someDate).ToList();         
        }
    }
}
