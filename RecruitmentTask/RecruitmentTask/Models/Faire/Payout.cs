using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentTask.Models.Faire
{
    public class Payout
    {
        public decimal Payout_fee_cents { get; set; }
        public decimal Payout_fee_bps { get; set; }
        public decimal Commission_cents { get; set; }
        public decimal Commission_bps { get; set; }
    }
}
