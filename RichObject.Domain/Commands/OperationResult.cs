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
    public class OperationResult<T>
    {
        public OperationStatus Status { get;  }
        public IEnumerable<string> ErrorMessages { get; }
        public T Value { get; }

        private OperationResult(OperationStatus operationStatus, 
            IEnumerable<string> errorMessages, 
            T value)
        {
            Status = operationStatus;
            ErrorMessages = errorMessages;
            Value = value;
        }


        public static OperationResult<T> ValidationFailure(IEnumerable<string> errorMessages)
        {
            return new OperationResult<T>(OperationStatus.ValidationFailure,
                errorMessages,
                default(T));
            
        }

        public static OperationResult<T> NotFound()
        {
            return new OperationResult<T>(OperationStatus.NotFound,
                new List<string>(),
                default(T));
            
        }

        public static OperationResult<T> Success(T value)
        {
            return new OperationResult<T>(OperationStatus.Success,
                new List<string>(), 
                value);
        }

        public static OperationResult<T> Conflict()
        {
            return new OperationResult<T>(OperationStatus.Conflict,
                new [] { "The given resource already exists"},
                default(T));
        }
    }
}