using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using RichObject.Domain.Models;

namespace RichObject.Domain.Commands
{
    public class OperationResponse<T>
    {
        public OperationResult Result { get;  }
        public IEnumerable<string> ErrorMessages { get; }
        public T Value { get; }

        private OperationResponse(OperationResult operationResult, 
            IEnumerable<string> errorMessages, 
            T value)
        {
            Result = operationResult;
            ErrorMessages = errorMessages;
            Value = value;
        }


        public static OperationResponse<T> ValidationFailure(IEnumerable<string> errorMessages)
        {
            return new OperationResponse<T>(OperationResult.ValidationFailure,
                errorMessages,
                default(T));
            
        }

        public static OperationResponse<T> Success(T value)
        {
            return new OperationResponse<T>(OperationResult.Success,
                new List<string>(), 
                value);
        }

        public static OperationResponse<T> Conflict()
        {
            return new OperationResponse<T>(OperationResult.Conflict,
                new [] { "The given resource already exists"},
                default(T));
        }
    }
}