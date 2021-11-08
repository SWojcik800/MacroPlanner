using MacroPlanner.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MacroPlanner.Entity
{
    public class Board
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(70)]
        [Required]
        public string Name { get; set; }


        public int OwnerId { get; set; }
        public virtual ApplicationUser Owner { get; set; }
        public virtual List<Task> Tasks { get; set; }

    }
}
