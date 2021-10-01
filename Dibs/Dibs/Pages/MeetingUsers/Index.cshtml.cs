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
    public class IndexModel : PageModel
    {
        private readonly Dibs.Data.DibsContext _context;

        public IndexModel(Dibs.Data.DibsContext context)
        {
            _context = context;
        }

        public IList<MeetingUser> MeetingUser { get;set; }

        public async Task OnGetAsync()
        {
            MeetingUser = await _context.MeetingUser.ToListAsync();
        }
    }
}
