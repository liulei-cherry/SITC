using System;
using System.Collections.Generic;
using System.Text;

namespace CommonOperation.Functions
{
    public class TransactionClass : IDisposable
    {
        public TransactionClass()
        {
            InterfaceInstantiation.NewADbAccess().BeginTransaction();
        }

        public void CommitTransaction()
        {
            InterfaceInstantiation.NewADbAccess().CommitTransaction();
        }

        void IDisposable.Dispose()
        {
            InterfaceInstantiation.NewADbAccess().EndTransaction();
        }

    }
}
