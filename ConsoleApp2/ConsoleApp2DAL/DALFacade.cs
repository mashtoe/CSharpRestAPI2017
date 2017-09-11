using ConsoleApp2DAL.Repositories;
using ConsoleApp2DAL.UOW;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2DAL
{
    public class DALFacade
    {
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return new UnitOfWork();
            }

        }
    }
}
