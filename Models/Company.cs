using System.ComponentModel;

#nullable disable

namespace BugTracker.Models
{
    public class Company
    {
        // Primary key
        public int Id { get; set; }

        [DisplayName("Company Name")]
        public string CompanyName { get; set; }

        [DisplayName("Company Description")]
        public string Description { get; set; }


        // Navigation Properties
        public virtual ICollection<BTUser> Members { get; set; } = new HashSet<BTUser>();
        public virtual ICollection<Project> Projects { get; set; } = new HashSet<Project>();

        // Create relationship to Invites
        public virtual ICollection<Invite> Invites { get; set; } = new HashSet<Invite>();
    }
}
