using MacroPlanner.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;



namespace MacroPlanner.Entity
{
    public enum TaskState {
        ToDo,
        InProgress,
        Done
        };

    public class Task
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }

        [Required]
        [MaxLength(60)]
        public string Tag { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        public TaskState State { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
        
        [Required]
        public DateTime Started { get; set; }

        [Required]
        public DateTime DeadLine { get; set; }

        [Required]
        public int AssigneeId { get; set; }

        public ApplicationUser Assignee { get; set; }

        [Required]
        public int AssignerId { get; set; }

        public ApplicationUser Assigner { get; set; }


        public int BoardId { get; set; }
        public Board Board { get; set; }

    }
}
