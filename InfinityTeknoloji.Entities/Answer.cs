using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityTeknoloji.Entities
{
    internal class Answer
    {
        public int AnswerID { get; set; }

        public string AnswerBody { get; set; }

        public bool IsTrue { get; set; }

        public int QuestionID { get; set; }

        public Question Question { get; set; }

    }
}
