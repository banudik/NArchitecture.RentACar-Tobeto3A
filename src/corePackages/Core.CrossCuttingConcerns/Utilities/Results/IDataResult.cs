using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Utilities.Results;

public interface IDataResult<T> : IResult
{
    T Data { get; }
}
