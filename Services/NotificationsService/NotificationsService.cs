using AutoMapper;
using LimousineApi.Core;
using LimousineApi.Data;
using LimousineApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LimousineApi.Services.NotificationsService
{
    public class NotificationsService : INotificationsService
    {

          private readonly IMapper _mapper;
        private readonly AppDBcontext _context;

        public NotificationsService(IMapper mapper, AppDBcontext context)
        {
            _mapper = mapper;

            _context = context;
        }

        public async Task<dynamic> AddAsync(dynamic type)
        {
          await _context.Notifications!.AddAsync(type);
          await _context.SaveChangesAsync();
          return type;
        }

        public async Task<dynamic> DeleteAsync(int typeId)
        {
            Notification? notification= await _context.Notifications!.FirstOrDefaultAsync(t => t.Id == typeId);
            _context.Notifications!.Remove(notification!);

            return notification!;
        }

        public async Task<dynamic> GetItems(string UserId)
        {
         var data=   await _context.Notifications!.Where(t => t.UserId == UserId).ToListAsync();

          return data;
        }

        public Task<dynamic> GetItemsPage(string UserId, int page)
        {
            throw new NotImplementedException();
        }

        public Task<dynamic> GitById(int typeId)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateObject(dynamic category)
        {
            throw new NotImplementedException();
        }
    }
}