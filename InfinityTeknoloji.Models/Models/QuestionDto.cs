using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityTeknoloji.Models.Models
{
    public class QuestionDto
    {
        public int QuestionID { get; set; }

        public string QuestionBody { get; set; }

        public int ExamID { get; set; }
             
        public int CategoryID { get; set; }

   

    }
}
