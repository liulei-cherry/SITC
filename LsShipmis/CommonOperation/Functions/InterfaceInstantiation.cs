using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.Interfaces;

namespace CommonOperation.Functions
{
    public static class InterfaceInstantiation
    {
        private static Dictionary<string, IDBAccess> dicThis = new Dictionary<string, IDBAccess>();

        private static IDBAccess transaction = NewADbAccess();

        public static IDBAccess NewADbAccess(bool IsLob)
        {
            if (IsLob)
            {
                return new SqlServerAccess(ConstParameter.LobDBConnectString);
            }
            return new SqlServerAccess(ConstParameter.DBConnectString);
        }
        public static IDBAccess NewADbAccess()
        {
            return getDbAcceess(ConstParameter.DBConnectString);
        }
        public static IDBAccess NewASingleAccess()
        {
            return new SqlServerAccess(ConstParameter.DBConnectString);
        }
        public static IDBAccess NewASingleLobAccess()
        {
            return new SqlServerAccess(ConstParameter.LobDBConnectString);
        }
        public static IDBAccess NewADbAccess(string connectString)
        {
            return getDbAcceess(connectString);
        }

        private static IDBAccess getDbAcceess(string connectString)
        {
            if (!dicThis.ContainsKey(connectString))
            {
                IDBAccess re = new SqlServerAccess(connectString);
                dicThis.Add(connectString, re);
            }
            return dicThis[connectString];
        }
        public static IDBOperation NewADBOperation()
        {
            //将来支持多种数据库的时候,在此加入其它数据库的分支即可.
            return new SqlServerOperation();
        }
    }
}
