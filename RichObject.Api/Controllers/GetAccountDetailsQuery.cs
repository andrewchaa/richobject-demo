using System;
using MediatR;

namespace RichObject.Api.Controllers
{
    public class GetAccountDetailsQuery : IRequest<GetAccountDetailsQueryResponse>
    {
        public Guid AccountId { get; }

        public GetAccountDetailsQuery(Guid accountId)
        {
            AccountId = accountId;
        }
    }
}