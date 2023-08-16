using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termii.Core.Models.Services.Foundations.Termii.Insights;

namespace Termii.Core.Models.Services.Foundations.Termii.Switch
{
    public class TemplatedMessage
    {
        public TemplatedMessageResponse Response { get; set; }

        public TemplatedMessageRequest Request { get; set; }
    }
}
