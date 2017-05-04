using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaciDolci.Data
{
    public class Data
    {
        private static BaciDolciContext context;

        public static BaciDolciContext Context
            => context ?? (context = new BaciDolciContext());
    }
}
