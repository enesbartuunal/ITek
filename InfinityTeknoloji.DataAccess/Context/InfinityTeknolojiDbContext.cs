using InfinityTeknoloji.DataAccess.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityTeknoloji.DataAccess.Context
{
    public class InfinityTeknolojiDbContext : IdentityDbContext<User>
    {
        public InfinityTeknolojiDbContext(DbContextOptions<InfinityTeknolojiDbContext> options):base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Exam> Exams { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Answer> Answers { get; set; }
                
    }
}
