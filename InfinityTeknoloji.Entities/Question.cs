using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityTeknoloji.Entities
{
    internal class Question
    {
        public int QuesID { get; set; }

        public string QuestionBody { get; set; }

        public int ExamID { get; set; }

        public Exam Exam { get; set; }

        public List<Answer> Answers { get; set; }




    }
}
