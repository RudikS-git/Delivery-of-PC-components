using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseWorkDataBase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using CourseWorkDataBase.Models.Accessory;

namespace CourseWorkDataBase.Pages
{
    public class CreateAccessoriesModel : PageModel
    {
        private readonly ApplicationContext _context;
        public List<Belong> belongs;
        public List<FeatureGroup> featureGroups;
        public List<Feature> features;

        public int TypeCreate { get; set; }
        public int TypeAccessoriesId { get; set; }

        public Belong Belong { get; set; }

        public List<Accessory> Accessories { get; set; }
        public List<AccessoryType> AccessoriesType { get; set; }
        /*public List<CaptureBoard> CaptureBoards { get; set; }
        public List<Case> Cases { get; set; }
        public List<CPU> CPUs { get; set; }
        public List<GraphicsCard> GraphicsCards { get; set; }
        public List<HDD> HDDs { get; set; }
        public List<Motherboard> Motherboards { get; set; }
        public List<OpticalDrive> OpticalDrives { get; set; }
        public List<PowerSupply> PowerSupplies { get; set; }
        public List<RAM> RAMs { get; set; }
        public List<SoundCard> SoundCards { get; set; }

        public List<Fan> Fans { get; set; }
        public List<Cooler> Coolers { get; set; }
        public List<Liquid> Liquids { get; set; }

        public List<SsdM2> ssdM2s { get; set; }
        public List<SsdSata> ssdSatas { get; set; }*/

        public CreateAccessoriesModel(ApplicationContext db)
        {
            _context = db;
        }

        public void OnGet()
        {
            featureGroups = _context.FeatureGroups.AsNoTracking().ToList();
            features= _context.Features.Include(it=>it.FeatureGroup).AsNoTracking().ToList();

            Accessories = _context.Accessories.AsNoTracking().ToList();
            AccessoriesType = _context.AccessoriesType.AsNoTracking().ToList();
            /*CaptureBoards = _context.CaptureBoards.AsNoTracking().ToList();
            Cases = _context.Cases.AsNoTracking().ToList();
            CPUs = _context.CPUs.AsNoTracking().ToList();
            GraphicsCards = _context.GraphicsCards.AsNoTracking().ToList();
            HDDs = _context.HDDs.AsNoTracking().ToList();
            Motherboards = _context.Motherboards.AsNoTracking().ToList();
            OpticalDrives = _context.OpticalDrives.AsNoTracking().ToList();
            PowerSupplies = _context.PowerSupplies.AsNoTracking().ToList();
            RAMs = _context.RAMs.AsNoTracking().ToList();
            SoundCards = _context.SoundCards.AsNoTracking().ToList();

            Fans = _context.Fans.AsNoTracking().ToList();
            Coolers = _context.Coolers.AsNoTracking().ToList();
            Liquids = _context.Liquids.AsNoTracking().ToList();

            ssdM2s = _context.ssdM2s.AsNoTracking().ToList();
            ssdSatas = _context.ssdSatas.AsNoTracking().ToList();*/
        }

        public IActionResult OnPostAddFeature(Belong belong)
        {
            _context.Belongs.Add(belong);
            _context.SaveChanges();

            return RedirectToPage();
        }

        public IActionResult OnPostDeleteFeature(Belong belong)
        {
            var accessory = _context.Accessories.Find(belong.AccessoryId);
            _context.Accessories.Remove(accessory);
            _context.SaveChanges();

            return RedirectToPage();
        }

        public IActionResult OnPostAddAccessories(int TypeAccessoriesId)
        {
            switch (TypeAccessoriesId)
            {
                case 0:
                    _context.Accessories.Add(new Accessory() { AccessoryTypeId = 1 });
                    break;

                case 1:
                    _context.Accessories.Add(new Accessory() { AccessoryTypeId = 2 });
                    break;
                case 2:
                    _context.Accessories.Add(new Accessory() { AccessoryTypeId = 3 });
                    break;

                case 3:
                    _context.Accessories.Add(new Accessory() { AccessoryTypeId = 4 });
                    break;

                case 4:
                    _context.Accessories.Add(new Accessory() { AccessoryTypeId = 5 });
                    break;

                case 5:
                    _context.Accessories.Add(new Accessory() { AccessoryTypeId = 6 });
                    break;

                case 6:
                    _context.Accessories.Add(new Accessory() { AccessoryTypeId = 7 });
                    break;

                case 7:
                    _context.Accessories.Add(new Accessory() { AccessoryTypeId = 8 });
                    break;

                case 8:
                    _context.Accessories.Add(new Accessory() { AccessoryTypeId = 9 });
                    break;

                case 9:
                    _context.Accessories.Add(new Accessory() { AccessoryTypeId = 10 });
                    break;

                case 10:
                    _context.Accessories.Add(new Accessory() { AccessoryTypeId = 11 });
                    break;

                case 11:
                    _context.Accessories.Add(new Accessory() { AccessoryTypeId = 12 });
                    break;

                case 12:
                    _context.Accessories.Add(new Accessory() { AccessoryTypeId = 13 });
                    break;

                case 13:
                    _context.Accessories.Add(new Accessory() { AccessoryTypeId = 14 });
                    break;

                case 14:
                    _context.Accessories.Add(new Accessory() { AccessoryTypeId = 15 });
                    break;
            }

            _context.SaveChanges();

            return RedirectToPage();
        }
    }
}
