using netMongoCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netMongoCRUD.Repositories
{
    interface IBusinessCollection
    {
        Task InsertBusiness(Business business);
        Task UpdateBusiness(Business business);
        Task DeleteBusiness(string id);

        Task<List<Business>> GetAllBusinesses();
        Task<Business> GetProductById(string id);

    }
}
