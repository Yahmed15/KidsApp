using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KidsApp.Models;
using KidsApp.Data;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace KidsApp.Pages.Inquiry
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ApplicationDbContext context, ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public List<InquiryInfo> ListInquiry { get; set; }

        [BindProperty]
        public InquiryInfo NewInquiry { get; set; }

        public void OnGet()
        {
            LoadInquiries();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                LoadInquiries(); // Ensure the inquiries are loaded even if the form submission fails
                return Page();
            }

            try
            {
                _logger.LogInformation("OnPost method called");

                NewInquiry.InquiryDate = DateTime.Now;
                _context.Inquiries.Add(NewInquiry);
                await _context.SaveChangesAsync();

                TempData["Message"] = "Your message has been sent.";
                _logger.LogInformation("Message successfully sent");
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception: " + ex.ToString());
                TempData["Message"] = "An error occurred while sending your message.";
            }

            return RedirectToPage();
        }

        private void LoadInquiries()
        {
            ListInquiry = new List<InquiryInfo>();

            try
            {
                ListInquiry = _context.Inquiries.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception: " + ex.ToString());
            }
        }
    }
}
