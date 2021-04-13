using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseWorkDataBase.Models.Accessory
{
    public class Accessory
    {
        public int Id { get; set; }

        [Required]
        public int AccessoryTypeId { get; set; }
        public AccessoryType accessoryType { get; set; }
    }
}

