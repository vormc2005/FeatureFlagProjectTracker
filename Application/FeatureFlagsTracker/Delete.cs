using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Persistence;
using SQLitePCL;

namespace Application.FeatureFlagsTracker
{
    public class Delete
    {
        public class Command : IRequest
        {
            public int ProjectFeatureFlagId {get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var projectFlag = await _context.ProjectFeatureFlags.FindAsync(request.ProjectFeatureFlagId);
                _context.Remove(projectFlag);
                await _context.SaveChangesAsync();
            }
        }
    }
}