using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLab1_Levchenko.DAL.Entities;
using WebLab1_Levchenko.Extensions;
using WebLab1_Levchenko.Models;
using WebLab1_Levchenko.DAL.Data;
using Microsoft.Extensions.Logging;

namespace WebLab1_Levchenko.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext _context;

        //public List<Cats> _cats;
        //List<CatsGroup> _catsGroups;

        int _pageSize;
        private ILogger _logger;

        //public ProductController()
        //{
        //    _pageSize = 3;
        //    //SetupData();
        //}

        public ProductController(ApplicationDbContext context, ILogger<ProductController> logger)
        {
            _pageSize = 3;
            _context = context;
            _logger = logger;
            //SetupData();
        }

        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public IActionResult Index(int? group, int pageNo)
        {
//            var groupMame = group.HasValue
//            ? _context.CatsGroups.Find(group.Value)?.GroupName
//:           "all groups";
//            _logger.LogInformation($"info: group={group}, page={pageNo}");
            var catsFiltered = _context.Cats.Where(d => !group.HasValue || d.CatsGroupID == group.Value);
            // Поместить список групп во ViewData
            ViewData["Groups"] = _context.CatsGroups;
            // Получить id текущей группы и поместить в TempData
            ViewData["CurrentGroup"] = group ?? 0;
            //return View(ListViewModel<Cats>.GetModel(catsFiltered, pageNo,_pageSize));

            var model = ListViewModel<Cats>.GetModel(catsFiltered, pageNo,_pageSize);
            //if (Request.Headers["x-requested-with"]
            //.ToString().ToLower().Equals("xmlhttprequest"))
            //    return PartialView("_listpartial", model);
            //else
            //    return View(model);
            if (Request.IsAjaxRequest())
                return PartialView("_listpartial", model);
            else
                return View(model);

        }

        public ViewResult Index(int v)
        {
            throw new NotImplementedException();
        }

        //private void SetupData()
        //{
        //    _catsGroups = new List<CatsGroup>
        //    {
        //        new CatsGroup {CatsGroupID=1, GroupName = "Персидские"},
        //        new CatsGroup {CatsGroupID=2, GroupName = "Британцы"},
        //        new CatsGroup {CatsGroupID=3, GroupName = "Сиамские"},
        //        new CatsGroup {CatsGroupID=4, GroupName = "Шотландцы"},
        //        new CatsGroup {CatsGroupID=5, GroupName = "Ангорские"},
        //        new CatsGroup {CatsGroupID=6, GroupName = "Просто милахи"}
        //    };

        //    _cats = new List<Cats>
        //    {
        //        new Cats {CatsID=1, CatsColor="Красивый", CatsName="Мурка", CatsWeight=200, Image="Котик1.jpg",  CatsGroupID=6},
        //        new Cats {CatsID=2, CatsColor="Очень Красивый", CatsName="Мурчик", CatsWeight=300, Image="Котик2.jpg",  CatsGroupID=6},
        //        new Cats {CatsID=3, CatsColor="Оч-оч Красивый", CatsName="Котенок", CatsWeight=250, Image="Котик3.jpg",  CatsGroupID=6},
        //        new Cats {CatsID=4, CatsColor="Красивенный", CatsName="Котяра", CatsWeight=400, Image="Котик4.jpg",  CatsGroupID=6},
        //        new Cats {CatsID=5, CatsColor="Разноцветный", CatsName="Котище", CatsWeight=150, Image="Котик5.jpg",  CatsGroupID=6},
        //        new Cats {CatsID=6, CatsColor="Красивый тоже", CatsName="Мурлыще", CatsWeight=200, Image="Котик6.jpg",  CatsGroupID=6}
        //    };
        //}
    }
}
