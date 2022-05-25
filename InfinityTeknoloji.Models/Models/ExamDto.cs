using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityTeknoloji.Models.Models
{
    public class ExamDto
    {
     
        public int ExamID { get; set; }

        public string ExamName { get; set; }

        public decimal? ExamOverTime { get; set; }

        public string ExamDesc { get; set; }

        public decimal? PassingScore { get; set; }

     
    }
}
