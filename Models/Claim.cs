using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Models
{
    public class Claim
    {
        public int MemberId { get; set; }
        public DateTime ClaimDate { get; set; }
        public float ClaimAmount { get; set; }
    }
}
