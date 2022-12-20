using BugTracker.Models;

namespace BugTracker.Services.Interfaces
{
    public interface IBTLookupService
    {
        public Task<List<TicketPriority>> GetTicketPrioritiesAsync();

        public Task<List<TicketStatus>> GetTicketStatusesAsync();

        public Task<List<TicketType>> GetTicketTypeAsync();

        public Task<List<ProjectPriority>> GetProjectPrioritiesAsync();
    }
}
