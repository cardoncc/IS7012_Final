using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dibs.Data;
using Dibs.Models;

namespace Dibs.Pages.MeetingUsers
{
    public class DeleteModel : PageModel
    {
        private readonly Dibs.Data.DibsContext _context;

        public DeleteModel(Dibs.Data.DibsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MeetingUser MeetingUser { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MeetingUser = await _context.MeetingUser.FirstOrDefaultAsync(m => m.Id == id);

            if (MeetingUser == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MeetingUser = await _context.MeetingUser.FindAsync(id);

            if (MeetingUser != null)
            {
                _context.MeetingUser.Remove(MeetingUser);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
