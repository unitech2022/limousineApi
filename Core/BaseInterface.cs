using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LimousineApi.Core
{
    public interface BaseInterface
    {

        Task<dynamic> GetItemsPage(string UserId, int page);

        Task<dynamic> GetItems(string UserId);

              
        Task<dynamic> AddAsync(dynamic type);

        Task<dynamic> GitById(int typeId);


        Task<dynamic> DeleteAsync(int typeId);

        void UpdateObject(dynamic category);


        bool SaveChanges();
    }
}