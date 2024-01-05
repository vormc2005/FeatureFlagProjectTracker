using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;
using SQLitePCL;

namespace Application.FeatureFlagsTracker
{
    public class Edit
    {
        public class Command : IRequest
        {
            public ProjectFeatureFlag projectFeatureFlag { get; set; } = new ProjectFeatureFlag();
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
               ProjectFeatureFlag? projectFlag = await _context.ProjectFeatureFlags.FindAsync(request.projectFeatureFlag.ProjectFeatureFlagId);

                _mapper.Map(request.projectFeatureFlag, projectFlag);
                await _context.SaveChangesAsync();
            }
        }
    }
}