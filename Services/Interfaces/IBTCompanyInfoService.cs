using BugTracker.Models;

namespace BugTracker.Services.Interfaces
{
    public interface IBTCompanyInfoService
    {
        public Task<Company> AddCompanyAsync(Company company);

        public Task<Company> AddUserAsync(string CompanyName, string Description);
        public Task<Company> GetCompanyInfoByIdAsync(int? companyId);

        public Task<List<BTUser>> GetAllMembersAsync(int companyId);

        public Task<List<Project>> GetAllProjectsAsync(int companyId);

        public Task<List<Ticket>> GetAllTicketsAsync(int companyId);

        public Task<Company> AddCompanyAsync(Company company);

        public Task<Company> AddUserAsync(string Name, string Description);

    }
}
