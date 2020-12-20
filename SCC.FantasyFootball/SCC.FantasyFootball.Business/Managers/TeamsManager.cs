using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SCC.FantasyFootball.Common.Utilities;
using SCC.FantasyFootball.DataAccess;
using SCC.FantasyFootball.DTO;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SCC.FantasyFootball.Business.Managers
{
    public interface ITeamsManager
    {
        Task<TeamDto> AddAsync(TeamDto teamDto);
        Task<PagedList<TeamDto>> GetPageAsync(IPage pageInformation);
        Task<TeamDto> GetOrDefaultAsync(int id);

        Task<TeamDto> UpdateAsync(TeamDto teamDto);

        Task<int> DeleteAsync(int id);
    }

    public class TeamsManager : ITeamsManager
    {
        private readonly FootballContext _context;
        private readonly IMapper _mapper;
        public TeamsManager(FootballContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        
        public async Task<TeamDto> AddAsync(TeamDto teamDto)
        {
            var teamEntity = _mapper.Map<Team>(teamDto);
            teamEntity.Createddate = DateTime.Now;
            _context.Teams.Add(teamEntity);
            teamDto.Teamid = await _context.SaveChangesAsync();
            return teamDto;
        }

        public async Task<PagedList<TeamDto>> GetPageAsync(IPage pageInformation)
        {
            pageInformation.TotalRecords = await _context.Teams.CountAsync();
            var pagedInforationSanitized = new PagedList<TeamDto>(pageInformation);
            var totalToSkip = (pagedInforationSanitized.CurrentPage - 1) * pagedInforationSanitized.PageSize;
            var recordsQ = _context.Teams.Skip(totalToSkip)
                .Take(pagedInforationSanitized.PageSize).IgnoreAutoIncludes();
            var records = recordsQ.Select(x => _mapper.Map<TeamDto>(x));
            pagedInforationSanitized.Items = await records.ToListAsync();
            return pagedInforationSanitized;
        }

        public async Task<TeamDto> GetOrDefaultAsync(int id)
        {
            var record = await _context.Teams.FindAsync(id);
            if (record == null)
                return null;
            return _mapper.Map<TeamDto>(record);
        }

        public async Task<TeamDto> UpdateAsync(TeamDto updatedDto)
        {
           var currentEntity = await _context.Teams.FindAsync(updatedDto.Teamid);

            if (currentEntity == null)
                return null;
            var currentDto = _mapper.Map<TeamDto>(currentEntity);
            
            if (updatedDto.IsDirty(currentDto))
            {
                var updateEntity = _mapper.Map<Team>(updatedDto);
                currentEntity.Conference = updateEntity.Conference;
                currentEntity.Division = updateEntity.Division;
                currentEntity.Location = updateEntity.Location;
                currentEntity.Name = updateEntity.Name;
                currentEntity.Modifieddate = updatedDto.Modifieddate = DateTime.Now;
                _context.Attach(currentEntity).State = EntityState.Modified;
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //Do some logging here potentially
                throw;
            }
            return updatedDto;
        }
    
        public async Task<int> DeleteAsync(int id)
        {
            var team = await _context.Teams.FindAsync(id);

            if (team != null)
            {
                _context.Teams.Remove(team);
                await _context.SaveChangesAsync();
            }
            return id;
        }
    }
}
