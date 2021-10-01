using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Dibs.Data;
using Dibs.Models;

namespace Dibs.Pages.Attendees
{
    public class CreateModel : PageModel
    {
        private readonly Dibs.Data.DibsContext _context;

        public CreateModel(Dibs.Data.DibsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["MeetingId"] = new SelectList(_context.Meeting, "Id", "Title");
        ViewData["MeetingUserId"] = new SelectList(_context.MeetingUser, "Id", "Email");
            return Page();
        }

        [BindProperty]
        public Attendee Attendee { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attendee.Add(Attendee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
