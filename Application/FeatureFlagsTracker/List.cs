using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.FeatureFlagsTracker
{
    public class List
    {
        public class Query: IRequest<List<ProjectFeatureFlag>>{}

        public class Handler : IRequestHandler<Query, List<ProjectFeatureFlag>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;                
            }
            public async Task<List<ProjectFeatureFlag>> Handle(Query request, CancellationToken cancellationToken)
            {                
                return await _context.ProjectFeatureFlags.ToListAsync();
            }
        }
    }
}