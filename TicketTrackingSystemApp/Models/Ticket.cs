using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketTrackingSystemApp.Models
{
    public enum TicketStates
    {
        Opened = 1,
        ReadyForAssignment = 2,
        Assigned = 3,
        Closed = 4,
        Review = 5,
        Completed = 6
    }
    public enum TicketDifficultyLevels
    {
        Simple = 1,
        Easy = 2,
        Medium = 3,
        Hard = 4,
        Extreme = 5
    }

    public enum TicketPriorityLevels
    {
        Low = 1,
        Normal = 2,
        Important = 3,
        Critical = 4
    }
    /// <summary>
    /// Ticketın validation işlemleri
    /// </summary>
    public class Ticket
    {
        public string  Id { get; set; }

        [Required(ErrorMessage = "Subject kısmını boş geçmeyiniz")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Description kısmını boş geçmeyiniz")]
        public string Description { get; set; }

        public Customer Customer { get; set; }

        public string CustomerId { get; set; }
        public Employee Employee { get; set; }
        public string EmployeeId { get; set; }
        public Manager Manager { get; set; }
        public string ManagerId { get; set; }
        public string LevelOfDifficulty { get; set; }

        public string Priority { get; set; }


        public DateTime CreateDate { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public DateTime ReviewDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public string TicketStatus { get; set; }

    }
}
