using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityTeknoloji.DataAccess.Entities
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public List<Exam> Categories { get; set; }

        public List<Question> Questions { get; set; }
    }
}
