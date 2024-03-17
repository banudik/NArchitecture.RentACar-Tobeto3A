using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Requests;

public class PageRequest
{
    public int Page { get; set; } //5
    public int PageSize { get; set; } //10
}
