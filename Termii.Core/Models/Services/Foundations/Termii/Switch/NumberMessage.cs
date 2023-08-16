using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Termii.Core.Models.Services.Foundations.Termii.Insights;

namespace Termii.Core.Models.Services.Foundations.Termii.Switch
{
    public class NumberMessage
    {
        public NumberMessageResponse Response { get; set; }

        public NumberMessageRequest Request { get; set; }
    }
}
