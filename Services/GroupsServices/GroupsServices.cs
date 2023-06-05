using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using LimousineApi.Data;
using LimousineApi.Models;

using X.PagedList;
using LimousineApi.Models.BaseEntity;
using LimousineApi.ViewModels;
using WajedApi.Helpers;

namespace LimousineApi.Services.GroupsServices
{
    public class GroupsServices : IGroupsServices
    {
        private readonly IMapper _mapper;


        private readonly AppDBcontext _context;

        public GroupsServices(IMapper mapper, AppDBcontext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<dynamic> AcceptGroup(int driverId, int status, int groupId)
        {
            Driver? driver = await _context.Drivers!.FirstOrDefaultAsync(t => t.Id == driverId);
            Group? group = await _context.Groups!.FirstOrDefaultAsync(t => t.id == groupId);
            if (group != null)
            {

                group.status = status;
                List<GroupLocation> groupLocations = await _context.GroupLocations!.Where(t => t.groupId == groupId).ToListAsync();
                foreach (var item in groupLocations)
                {

                    item.driverId = driverId;
                  User? user=await _context.Users.FirstOrDefaultAsync(t => t.Id==item.userId);
                  if(user!=null){
                     await Functions.SendNotificationAsync(_context, user.Id!,"رحلاتى الخارجية", "تم قبول رحلتك من السائق", "");
                  }
                }
                await _context.SaveChangesAsync();
            }

            return group!;

        }

        public async Task<dynamic> AddAsync(dynamic type)
        {
            await _context.Groups!.AddAsync(type);

            await _context.SaveChangesAsync();

            return type;
        }

        public async Task<dynamic> DeleteAsync(int typeId)
        {
            Group? group = await _context.Groups!.FirstOrDefaultAsync(x => x.id == typeId);

            if (group != null)
            {
                _context.Groups!.Remove(group);

                await _context.SaveChangesAsync();
            }

            return group!;
        }

        public async Task<dynamic> GetGroupByDriverId(int driverId)
        {
               List<Group> currentGroups = await _context.Groups!.OrderByDescending(t=> t.CreatedAt).Where(t => t.status == 0).ToListAsync();

               List<Group> finishedGroups = await _context.Groups!.OrderByDescending(t=> t.CreatedAt).Where(t =>t.driverId==driverId&& t.status != 0).ToListAsync();

               return new {
                currentGroups =currentGroups,
                finishedGroups =finishedGroups
               };
        }

        public async Task<dynamic> GetGroupDetails(int groupId)
        {
            List<GroupLocationResponse> groupLocationResponses = new List<GroupLocationResponse>();
            Group? group = await _context.Groups!.FirstOrDefaultAsync(x => x.id == groupId);
            List<GroupLocation> groupLocations = await _context.GroupLocations!.Where(t => t.groupId == group!.id).ToListAsync();

            foreach (var item in groupLocations)
            {
                User? user = await _context.Users.FirstOrDefaultAsync(t => t.Id == item.userId);
                UserDetailResponse userDetail = _mapper.Map<UserDetailResponse>(user);

                groupLocationResponses.Add(new GroupLocationResponse
                {
                    groupLocation = item,
                    userDetail = userDetail
                });

            }

            return new
            {
                group = group,
                groupLocationResponses = groupLocationResponses
            };

        }

        public async Task<dynamic> GetItems(string UserId)
        {
            List<Group> groups = await _context.Groups!.OrderByDescending(t=> t.CreatedAt).Where(t => t.status == 0).ToListAsync();


            return groups;
        }



        public Task<dynamic> GetItemsPage(string UserId, int page)
        {
            throw new NotImplementedException();
        }

        public async Task<dynamic> GitById(int typeId)
        {
            Group? Group = await _context.Groups!.FirstOrDefaultAsync(x => x.id == typeId);
            return Group!;
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