using Domain;
using MediatR;
using Persistence;
using SQLitePCL;

namespace Application.FeatureFlagsTracker
{
    public class Details
    {
        public class Query: IRequest<ProjectFeatureFlag>
        {
            public int ProjectFeatureFlagId { get; set; }            
        }


        public class Handler : IRequestHandler<Query, ProjectFeatureFlag>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<ProjectFeatureFlag> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.ProjectFeatureFlags.FindAsync(request.ProjectFeatureFlagId);
            }
        }
    }
}