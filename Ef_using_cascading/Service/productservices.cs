using Ef_using_cascading.context;
using Ef_using_cascading.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ef_using_cascading.Service
{
    public class productservices: Iproductservic
    {
        private readonly ProdContext _cxt;
        public productservices(ProdContext vh)
        {
            _cxt = vh;
        }
        public async Task<List<Product3>> GetAllproduct()
        {

            var prodlist = from p in _cxt.Product3
                           join c in _cxt.Category3
                           on p.catid equals c.catid
                           join s in _cxt.SubCategory3
                           on p.subcatid equals s.subcatid
                            select new Product3
                           {
                               pid = p.pid,
                               catname = c.catname,
                               subcatname = s.subcatname,
                               pname = p.pname,
                               price = p.price,

                               pqty = p.pqty
                           };
            return prodlist.ToList();
        }
        public async Task<List<Category3>> GetAllCategory()
        {
            return _cxt.Category3.ToList();
        }

        public async Task<List<SubCategory3>> GetAllSubCategory(int id)
        {
            List<SubCategory3> lst = (from s in _cxt.SubCategory3
                                      where s.catid == id
                                      select s).ToList();
            lst.Insert(0, new SubCategory3 { subcatid = 0, subcatname = "plz select one" });
            return lst;

        }
        public async Task<List<SubCategory3>> GetAllSubCategory()
        {
            List<SubCategory3> lst = _cxt.SubCategory3.ToList();
                                     
                                      
            lst.Insert(0, new SubCategory3 { subcatid = 0, subcatname = "plz select one" });
            return lst;

        }

        public async Task<Product3> GetProductByid(int pid)
        {
            var prodlist =(from p in _cxt.Product3
                           join c in _cxt.Category3
                           on p.catid equals c.catid
                           join s in _cxt.SubCategory3
                           on p.subcatid equals s.subcatid
                           where p.pid==pid
                           select new Product3
                           {
                               pid = p.pid,
                               catid=c.catid,
                               catname = c.catname,
                               subcatid=s.subcatid,
                               subcatname = s.subcatname,
                               pname = p.pname,
                               price = p.price,

                               pqty = p.pqty
                           }).FirstOrDefault();
            return prodlist;
        }

        public async Task<int> Create(Product3 p)
        {
            _cxt.Product3.Add(p);
          int x= _cxt.SaveChanges();
            return x;
        }
        public async Task<int> Delete(int id)
        {
            Product3 pr = _cxt.Product3.Find(id);
            _cxt.Product3.Remove(pr);
           int x= _cxt.SaveChanges();
            return x;
        }
        public async Task<int> Update(Product3 p)
        {
            _cxt.Product3.Update(p);
            int x= _cxt.SaveChanges();
            return x;

        }

    }
}
