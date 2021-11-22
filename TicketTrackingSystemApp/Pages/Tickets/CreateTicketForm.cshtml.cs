using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketTrackingSystemApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

using TicketTrackingSystemApp.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TicketTrackingSystemApp.Pages.Tickets
{
    public class CreateTicketFormModel : PageModel
    {

        public   CustomerRepository cRepo;

        public CreateTicketFormModel(CustomerRepository customerRepository)
        {
            cRepo = customerRepository;
   
           
        }
 

        

 
             
        [BindProperty]
        public Ticket TicketInput { get; set; }

        public void OnGet()
        {
        
        }
        public void OnPostSave()
        {
            

        }

   

     
    }
}
