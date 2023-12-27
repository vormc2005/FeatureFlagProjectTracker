using Domain;

namespace Persistence
{
    public class Seed
    {
         public static async Task SeedData(DataContext context)
        {
            if (context.ProjectFeatureFlags.Any()) return;
            
            var projects = new List<ProjectFeatureFlag>
            {
                new ProjectFeatureFlag
                {
                    FlagName = "Flag 1",
                    TaskNumber = "1",
                    PRLinks = "Link 1",
                    WorkedOnBy = "Dmitry",
                    IsUiChanged = false,
                    IsApiChanged = true,
                    IsFredChanged = false,
                    IsIvanChanged = false,
                    IsOtherChanged = false,
                    OtherChangedApps = null,
                    DateCreated = DateTime.Now

                },
               new ProjectFeatureFlag
                {
                    FlagName = "Flag 2",
                    TaskNumber = "2",
                    PRLinks = "Link 2",
                    WorkedOnBy = "Md",
                    IsUiChanged = true,
                    IsApiChanged = true,
                    IsFredChanged = false,
                    IsIvanChanged = false,
                    IsOtherChanged = false,
                    OtherChangedApps = null,
                    DateCreated = DateTime.Now

                },
                new ProjectFeatureFlag
                {
                    FlagName = "Flag 3",
                    TaskNumber = "3",
                    PRLinks = "Link 3",
                    WorkedOnBy = "Jimmy",
                    IsUiChanged = false,
                    IsApiChanged = true,
                    IsFredChanged = true,
                    IsIvanChanged = false,
                    IsOtherChanged = false,
                    OtherChangedApps = null,
                    DateCreated = DateTime.Now

                },              
            };

            await context.ProjectFeatureFlags.AddRangeAsync(projects);
            await context.SaveChangesAsync();
        }
    }
}