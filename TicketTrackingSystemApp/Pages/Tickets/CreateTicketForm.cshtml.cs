using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketTrackingSystemApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

using TicketTrackingSystemApp.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using TicketTrackingSystemApp.Services;

namespace TicketTrackingSystemApp.Pages.Tickets
{
    public class CreateTicketFormModel : PageModel
    {

        public CustomerRepository cRepo;
        public TicketCreateService TicketCreateService;
        public SmtpMailService SmtpMailService;


        public List<SelectListItem> options { get; set; }
        public CreateTicketFormModel(CustomerRepository customerRepository, TicketCreateService ticketCreateService,SmtpMailService smtpMailService)
        {
            cRepo = customerRepository;
            TicketCreateService=ticketCreateService;
            SmtpMailService = smtpMailService;
      
            //newList = (string)cRepo.List();
         

           
        }

        [BindProperty]
        public Ticket TicketInput { get; set; }

        [BindProperty]
        public string selectedCustomerId { get; set; }

        [BindProperty]
        public IEnumerable<Customer> newList { get; set; }

        public  void  OnGet()
        {
            newList = cRepo.List();


            options = newList.Select(a =>
             new SelectListItem
             {
                 Value = a.Id.ToString(),
                 Text = a.Name
             }).ToList();
        
        } 


        public void OnPostSave()
        {
            OnGet();
            var email = cRepo.Find(selectedCustomerId);

          //  newList =(from x in _db.Customers where (x.Name ==newList ) select x).
            if (ModelState.IsValid)
            {
         
                
               TicketCreateService.CreateTicket(TicketInput,selectedCustomerId);
               SmtpMailService.SendEmail("bitirmeprojesi55@gmail.com", email.Email, $"Ticketin takip numarasý : {TicketInput.Id} Baþarýlý bir þekilde olusturuldu","Yeni bir ticket oluþturuldu");
           }
           

        }

   

     
    }
}
