using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xFNet.Context
{
    public class Current
    {
        public static DateTime GetNowUTC
        {
            get
            {
                return DateTime.UtcNow;
            }
        }

    }
}
