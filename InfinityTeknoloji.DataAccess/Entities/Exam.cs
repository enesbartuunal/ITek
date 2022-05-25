using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityTeknoloji.DataAccess.Entities
{
    public class Exam
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExamID { get; set; }

        public string ExamName { get; set; }

        public decimal? ExamOverTime { get; set; }

        public string ExamDesc { get; set; }

        public decimal? PassingScore { get; set; }

        public List<Question> Questions { get; set; }

        public List<User> Users { get; set; }

        public List<Category> Categories { get; set; }
    }
}
