using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KabiLottery2.Models
{
    public class GameApp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Myname { get; set; }
        public string Comment { get; set; }
        public Nullable<System.DateTime> Datetime { get; set; }
        public Nullable<bool> LotteryName { get; set; }
        public Nullable<bool> LotteryMyName { get; set; }
        public Nullable<bool> LotteryComment { get; set; }
    }
}