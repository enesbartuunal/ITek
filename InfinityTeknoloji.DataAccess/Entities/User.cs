﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityTeknoloji.DataAccess.Entities
{
    public class User:IdentityUser
    {
        public virtual List<Exam> Exams { get; set; }

    }
}
