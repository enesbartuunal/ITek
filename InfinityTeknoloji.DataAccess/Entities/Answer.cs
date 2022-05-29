using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityTeknoloji.DataAccess.Entities
{
    public class Answer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnswerID { get; set; }

        public string AnswerBody { get; set; }

        public bool IsTrue { get; set; }

        public int QuestionID { get; set; }

        public  virtual Question Question { get; set; }

    }
}
