using CSharpFunctionalExtensions;
using Demant_Assignment.Application.Helper;
using Demant_Assignment.Application.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Demant_Assignment.Application.Queries
{
    internal class GetUsersQuery : IRequest<Result<List<Users>>>
    {
        public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, Result<List<Users>>>
        {

            public Task<Result<List<Users>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
            {

                var item = UserGenerator.GenerateFakeUsers();
                return Task.FromResult(Result.Success(item));
            }
        }
    }
}