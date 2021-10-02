using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dibs
{
    public class InviteFormModel
    {
        public int MeetingId { get; set; }
        public int?[] UserIds { get; set; }
    }
}
