using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaciDolci.Data;
using BaciDolci.Data.Interfaces;

namespace BaciDolci.App.Services
{
    public abstract class Service
    {
        public Service()
        {
            this.Context = BaciDolci.Data.Data.Context;
        }

        //public Service(IBaciDolciContext context)  //??????
        //{
        //   this.Contex = context;
        //}

        protected BaciDolciContext Context { get; }

        //protected IBaciDolciContext Contex { get; }
    }
}