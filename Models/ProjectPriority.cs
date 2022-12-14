using System.ComponentModel;

#nullable disable

namespace BugTracker.Models
{
    public class ProjectPriority
    {
        // Primary key
        public int Id { get; set; }

        [DisplayName("Priority Name")]
        public string Name { get; set; }
    }
}
