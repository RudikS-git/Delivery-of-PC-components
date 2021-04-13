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
    public class OrderModel : PageModel
    {
        private readonly ApplicationContext _context;
        public int AccessoryId { get; set; }
        public Client Client { get; set; }
        public Order Order { get; set; }

        public OrderModel(ApplicationContext db)
        {
            _context = db;
        }

        public void OnGet(int id)
        {
            AccessoryId = id;
        }

        public IActionResult OnPost(Client client, Order order)
        {
            _context.Client.Add(client);
            _context.SaveChanges();


            order.Date = DateTime.Now;
            order.DateDelivery = DateTime.Now.AddDays(7);
            order.ClientId = _context.Client.Where(it => it.NumberPhone == client.NumberPhone).FirstOrDefault().Id;

            _context.Orders.Add(order);
            _context.SaveChanges();

            return RedirectToPage("OrderAccepted");
        }

    }
}
