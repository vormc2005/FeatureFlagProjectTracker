using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ProjectFeatureFlag
    {
        [Key]
        public int ProjectFeatureFlagId { get; set; }

        public string FlagName { get; set; }

        public string TaskNumber { get; set; }

        public string PRLinks { get; set; }

        public string WorkedOnBy { get; set; }

        public bool IsUiChanged { get; set; }

        public bool IsApiChanged { get; set; }

        public bool IsFredChanged { get; set; }

        public bool IsIvanChanged { get; set; } 

        public bool IsOtherChanged { get; set; }

        public string OtherChangedApps { get; set; }

        public DateTime DateCreated { get; set; }

    }
}