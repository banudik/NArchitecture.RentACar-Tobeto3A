using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Exceptions.Types;

public class BusinessException:Exception
{
    public BusinessException() { }

    protected BusinessException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }

    public BusinessException(string? message)
        : base(message) { }
    public BusinessException(string? message, Exception? exception)
        : base(message, exception) { }
}
