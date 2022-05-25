using AutoMapper;
using InfinityTeknoloji.Business.Base;
using InfinityTeknoloji.DataAccess.Context;
using InfinityTeknoloji.DataAccess.Entities;
using InfinityTeknoloji.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfintyTeknoloji.Business.Implementation
{
    public class ExamsManager : ServiceAbstractBase<Exam, ExamDto>
    {
        public ExamsManager(InfinityTeknolojiDbContext db, IMapper mapper) : base(db, mapper)
        {
        }
    }
}
