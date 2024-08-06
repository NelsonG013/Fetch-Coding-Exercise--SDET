using Fetch_Coding_Exercise__SDET.Source.Drivers;
using Fetch_Coding_Exercise__SDET.Source.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fetch_Coding_Exercise__SDET.Tests
{
    public class PageInitializer : Driver
    {
        public HomePage home;

        public PageInitializer() 
        {
            home = new HomePage();
        }
    }
}
