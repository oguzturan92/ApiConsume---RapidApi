using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapidApiConsume.Web.Models
{
    public class ImdbModel
    {
        public int rank { get; set; }
        public string title { get; set; }
        public string rating { get; set; }
        public string trailer { get; set; }
    }
}