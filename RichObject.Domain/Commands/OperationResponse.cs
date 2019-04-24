using System.Collections;
using System.Collections.Generic;

namespace RichObject.Domain.Commands
{
    public class OperationResponse<T>
    {
        public OperationResult Result { get;  }
        public IEnumerable<string> ErrorMessages { get; }
        public T Value { get; }
    }
}