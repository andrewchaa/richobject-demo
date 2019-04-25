using System;
using System.Collections.Generic;
using System.Linq;
using RichObject.Domain.Commands;

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

        public static OperationResponse<IdDocument> Create(string idDocumentType, 
            string idDocumentNumber)
        {
            var errorMessages = new List<string>();
            
            if (!Enum.IsDefined(typeof(IdDocumentType), idDocumentType))
                errorMessages.Add($"{idDocumentType} is not a recognised ID Document Type");   
            
            if (string.IsNullOrEmpty(idDocumentNumber))
                errorMessages.Add("ID Document Number is empty");

            if (errorMessages.Any())
            {
                return OperationResponse<IdDocument>.ValidationFailure(errorMessages);
            }


            Enum.TryParse(idDocumentType, out IdDocumentType docType);

            return OperationResponse<IdDocument>.Success(new IdDocument(docType, 
                idDocumentNumber));
        }
    }
}