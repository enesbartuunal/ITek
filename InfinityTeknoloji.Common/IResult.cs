using System;
using System.Collections.Generic;
using System.Text;

namespace InfinityTeknoloji.Common
{
    public interface IResult
    {
        bool IsSuccess { get; set; }
        string Message { get; set; }
    }
}
