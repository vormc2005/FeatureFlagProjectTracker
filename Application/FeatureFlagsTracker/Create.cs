using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.FeatureFlagsTracker
{
    public class Create
    {
        public class Command : IRequest
        {
           public ProjectFeatureFlag projectFeatureFlag { get; set; } = new ProjectFeatureFlag();
        }

        public class Handler : IRequestHandler<Command>
        {
            public readonly DataContext _context;
            public Handler(DataContext context)
            {
            _context = context;                
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                _context.ProjectFeatureFlags.Add(request.projectFeatureFlag);
                await _context.SaveChangesAsync();                
            }
        }
    }
}