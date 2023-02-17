using Ef_using_cascading.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ef_using_cascading.Service
{
  public  interface Iproductservic
    {
        Task<List<Product3>> GetAllproduct();
        Task<List<Category3>> GetAllCategory();
        Task<List<SubCategory3>> GetAllSubCategory(int id);
        Task<List<SubCategory3>> GetAllSubCategory();

        Task<Product3> GetProductByid(int pid);

        Task<int> Create(Product3 p);
        Task<int> Delete(int id);
        Task<int> Update(Product3 p);
    }
}
