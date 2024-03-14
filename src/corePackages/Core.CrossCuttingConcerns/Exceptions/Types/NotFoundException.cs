using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Exceptions.Types;

public class NotFoundException:Exception
{
    public NotFoundException() { }

    protected NotFoundException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }

    public NotFoundException(string? message)
        : base(message) { }
    public NotFoundException(string? message, Exception? exception)
        : base(message, exception) { }
}
