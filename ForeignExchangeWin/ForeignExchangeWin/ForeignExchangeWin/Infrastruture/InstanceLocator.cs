﻿namespace ForeignExchangeWin.Infrastruture
{
    using ForeignExchangeWin.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class InstanceLocator
    {
        public MainViewModel Main {
            get;
            set;
        }

        public InstanceLocator()
        {
            Main = new MainViewModel();
        }
    }
}
