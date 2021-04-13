using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseWorkDataBase.Models;
using CourseWorkDataBase.Models.Accessory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using CourseWorkDataBase.Models.Accessory;
using System.Collections;

namespace CourseWorkDataBase.Pages
{
    [IgnoreAntiforgeryToken]
    public class AccessoriesModel : PageModel
    {
        private readonly ApplicationContext _context;
        public List<Accessory> asseccories;
        public List<Belong> belongs;

        public AccessoriesModel(ApplicationContext db)
        {
            _context = db;
        }

        public void OnGet(int id)
        {
            /*var product = await _context.People.FindAsync(id);

            if (product != null)
            {
                _context.People.Remove(product);
                await _context.SaveChangesAsync();
            }*/

            asseccories = _context.Accessories.Where(it => it.AccessoryTypeId == id).ToList();

            /*switch(id)
            {
                case 0:
                    asseccories = _context.CPUs.ToList<Accessory>();
                        break;
                case 1:
                    asseccories = _context.Motherboards.ToList<Accessory>();
                    break;

                case 2:
                    asseccories = _context.GraphicsCards.ToList<Accessory>();
                    break;

                case 3:
                    asseccories = _context.RAMs.ToList<Accessory>();
                    break;

                case 4:
                    asseccories = _context.PowerSupplies.ToList<Accessory>();
                    break;

                case 5:
                    asseccories = _context.Cases.ToList<Accessory>();
                    break;

                case 6:
                    asseccories = _context.HDDs.ToList<Accessory>();
                    break;

                case 7:
                    asseccories = _context.ssdM2s.ToList<Accessory>();
                    break;

                case 8:
                    asseccories = _context.ssdSatas.ToList<Accessory>();
                    break;

                case 9:
                    asseccories = _context.Fans.ToList<Accessory>();
                    break;

                case 10:
                    asseccories = _context.Coolers.ToList<Accessory>();
                    break;

                case 11:
                    asseccories = _context.Liquids.ToList<Accessory>();
                    break;

                case 12:
                    asseccories = _context.SoundCards.ToList<Accessory>();
                    break;

                case 13:
                    asseccories = _context.OpticalDrives.ToList<Accessory>();
                    break;

                case 14:
                    asseccories = _context.CaptureBoards.ToList<Accessory>();
                    break;
                default:
                    break;
            }*/

            belongs = _context.Belongs.Include(it => it.Feature).Include(it => it.Accessory).AsNoTracking().ToList();

            belongs = belongs.Where(it =>
            {
                foreach (var item in asseccories)
                {
                    if (it.AccessoryId == item.Id)
                        return true;
                }

                return false;
            }).ToList();

        }
    }
}
