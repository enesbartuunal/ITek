using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityTeknoloji.DataAccess.Entities
{
    public class Question
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionID { get; set; }

        public string QuestionBody { get; set; }

        public int ExamID { get; set; }

        public virtual Exam Exam { get; set; }

        public virtual List<Answer> Answers { get; set; }

      

    }
}
