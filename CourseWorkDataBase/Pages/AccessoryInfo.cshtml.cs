using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseWorkDataBase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CourseWorkDataBase.Pages
{
    public class AccessoryInfoModel : PageModel
    {
        private readonly ApplicationContext _context;
        public List<Belong> belongs;

        public AccessoryInfoModel(ApplicationContext db)
        {
            _context = db;
        }

        public void OnGet(int id)
        {
            belongs = _context.Belongs.Include(it => it.Feature)
                                      .ThenInclude(it=> it.FeatureGroup)
                                      .AsNoTracking()
                                      .Where(it => it.AccessoryId == id)?
                                      .OrderBy(it => it.Feature.FeatureGroup.Id)
                                      .ToList();

            /*var lol = _context.Belongs.Include(it => it.Feature)
                .ThenInclude(it => it.FeatureGroup)
                .AsNoTracking()
                .Where(it => it.AccessoryId == id)?
                .OrderBy(it => it.Feature.FeatureGroup.Id)
                .ToQueryString();*/
        }
    }
}
