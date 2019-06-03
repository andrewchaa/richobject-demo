using System;
using System.Collections.Generic;
using System.Linq;
using RichObject.Domain.Commands;
using RichObject.Domain.Infrastructure;

namespace RichObject.Domain.Values
{
    public class IdDocument
    {
        public IdDocumentType DocumentType { get; }
        public string DocumentNumber { get; }
        
        private IdDocument(IdDocumentType documentType, string documentNumber)
        {
            DocumentType = documentType;
            DocumentNumber = documentNumber;
        }

        public static OperationResult<IdDocument> Create(string idDocumentType, 
            string idDocumentNumber)
        {
            var errorMessages = new List<string>();
            
            if (!Enum.IsDefined(typeof(IdDocumentType), idDocumentType))
                errorMessages.Add($"{idDocumentType} is not a recognised ID Document Type");   
            
            if (string.IsNullOrEmpty(idDocumentNumber))
                errorMessages.Add("ID Document Number is empty");

            if (errorMessages.Any())
            {
                return OperationResult<IdDocument>.ValidationFailure(errorMessages);
            }


            Enum.TryParse(idDocumentType, out IdDocumentType docType);

            return OperationResult<IdDocument>.Success(new IdDocument(docType, 
                idDocumentNumber));
        }
    }
}