
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using LimousineApi.Data;
using LimousineApi.Models;

using X.PagedList;


namespace LimousineApi.Services.GroupLocationsServices
{
    public class GroupLocationsServices : IGroupsLocationServices
    {
        private readonly IMapper _mapper;


        private readonly AppDBcontext _context;

        public GroupLocationsServices(IMapper mapper, AppDBcontext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<dynamic> AddAsync(dynamic type)
        {


            await _context.GroupLocations!.AddAsync(type);

            await _context.SaveChangesAsync();

            return type;
        }

        public async Task<dynamic> AddGroupLocation(GroupLocation groupLocation)
        {

            Group? group = await _context.Groups!.FirstOrDefaultAsync(t => t.startCity == groupLocation.startLocation && t.endCity == groupLocation.endLocation && t.status == 0);
            if (group == null || group.peoples == 4)
            {
                Group group1 = new Group
                {
                    startCity = groupLocation.startLocation,
                    endCity = groupLocation.endLocation,
                    price = 200,
                    peoples=1
                };
                await _context.Groups!.AddAsync(group1);
                await _context.SaveChangesAsync();
                groupLocation.groupId = group1.id;
            }
            else
            {
                
               groupLocation.groupId=group.id;
               group.peoples=group.peoples + 1 ;
               
            }
            await _context.GroupLocations!.AddAsync(groupLocation);

            await _context.SaveChangesAsync();

            return groupLocation;
        }

        public async Task<dynamic> DeleteAsync(int typeId)
        {
            GroupLocation? groupLocation = await _context.GroupLocations!.FirstOrDefaultAsync(x => x.id == typeId);

            if (groupLocation != null)
            {
                _context.GroupLocations!.Remove(groupLocation);

                await _context.SaveChangesAsync();
            }

            return groupLocation!;
        }

        public Task<dynamic> GetGroupLocations(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<dynamic> GetGroupLocationsByDriverId(int driverId)
        {
            List<GroupLocation> GroupLocations = await _context.GroupLocations!.Where(t => t.driverId == driverId).ToListAsync();

            return GroupLocations;
        }

        public async Task<dynamic> GetGroupLocationsByUserId(string userId)
        {
            List<GroupLocation> GroupLocations = await _context.GroupLocations!.Where(t => t.userId == userId).ToListAsync();

            return GroupLocations;
        }

        public async Task<dynamic> GetItems(string UserId)
        {
            List<GroupLocation> GroupLocations = await _context.GroupLocations!.ToListAsync();

            return GroupLocations;
        }


        public Task<dynamic> GetItemsPage(string UserId, int page)
        {
            throw new NotImplementedException();
        }

        public async Task<dynamic> GitById(int typeId)
        {
            GroupLocation? groupLocation = await _context.GroupLocations!.FirstOrDefaultAsync(x => x.id == typeId);
            return groupLocation!;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateObject(dynamic category)
        {
            // 
        }
    }
}