﻿using BugTracker.Data;
using BugTracker.Models;
using BugTracker.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BugTracker.Services
{
    public class BTCompanyInfoService : IBTCompanyInfoService
    {
        private readonly ApplicationDbContext _context;
        public BTCompanyInfoService(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Add Company
        public async Task<Company> AddCompanyAsync(Company company)
        {
            try
            {
                await _context.AddAsync(company);
                await _context.SaveChangesAsync();
                return company;
            }
            catch (Exception)
            {

                throw;
            }
        } 
        #endregion

        #region Add User

        public async Task<Company> AddUserAsync(string CompanyName, string Description)
        {
            Company newCompany = new()
            {
                CompanyName = CompanyName,
                Description = Description
            };


            CompanyName = CompanyName.ToLower();
            Description = Description.ToLower();

            List<Company> companies = await _context.Companies!.ToListAsync();

            foreach (Company company in companies)
            {
                if (company.CompanyName == CompanyName && company.Description == Description)
                {
                    return company;
                }
            }

            await AddCompanyAsync(newCompany);


            return newCompany;

        }
        #endregion

        #region Get All Members
        public async Task<List<BTUser>> GetAllMembersAsync(int companyId)
        {
            List<BTUser> result = new();
            result = await _context.Users.Where(u => u.CompanyId == companyId).ToListAsync();
            return result;
        }

        #endregion

        #region Get All Projects
        public async Task<List<Project>> GetAllProjectsAsync(int companyId)
        {
            List<Project> result = new();

            result = await _context.Projects.Where(p => p.CompanyId == companyId)
                                            .Include(p => p.Members)
                                            .Include(p => p.Tickets)
                                                .ThenInclude(t => t.Comments)
                                            .Include(p => p.Tickets)
                                                .ThenInclude(t => t.Attachments)
                                            .Include(p => p.Tickets)
                                                .ThenInclude(t => t.History)
                                            .Include(p => p.Tickets)
                                                .ThenInclude(t => t.Notifications)
                                            .Include(p => p.Tickets)
                                                .ThenInclude(t => t.DeveloperUser)
                                            .Include(p => p.Tickets)
                                                .ThenInclude(t => t.OwnerUser)
                                            .Include(p => p.Tickets)
                                                .ThenInclude(t => t.TicketStatus)
                                            .Include(p => p.Tickets)
                                                .ThenInclude(t => t.TicketPriority)
                                            .Include(p => p.Tickets)
                                                .ThenInclude(t => t.TicketType)
                                            .Include(p => p.ProjectPriority)
                                            .ToListAsync();

            return result;
        }

        #endregion

        #region Get All Tickets
        public async Task<List<Ticket>> GetAllTicketsAsync(int companyId)
        {
            List<Ticket> result = new();
            List<Project> projects = new();

            projects = await GetAllProjectsAsync(companyId);

            result = projects.SelectMany(p => p.Tickets).ToList();

            return result;
        }

        #endregion

        #region Get Company Info By Id
        public async Task<Company> GetCompanyInfoByIdAsync(int? companyId)
        {
            Company result = new();
            if (companyId != null)
            {
                result = await _context.Companies
                                       .Include(c => c.Members)
                                       .Include(c => c.Projects)
                                       .Include(c => c.Invites)
                                       .FirstOrDefaultAsync(c => c.Id == companyId);
            }

            return result;
        }

        #endregion    }
    }
}
