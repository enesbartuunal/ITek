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

        public Exam Exam { get; set; }

        public List<Answer> Answers { get; set; }

        public int CategoryID { get; set; }

        public Category Category { get; set; }

    }
}
