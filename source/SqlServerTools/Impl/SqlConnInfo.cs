using Microsoft.SqlServer.Management.Common;
using System.Data;

namespace AnfiniL.SqlServerTools.Impl
{
    public class SqlConnInfo
    {
        private SqlConnectionInfo _info;

        public delegate IDbConnection CreateConnectionHandler();

        private readonly CreateConnectionHandler _handler;

        public SqlConnInfo(SqlConnectionInfo info)
        {
            info.ApplicationName = ApplicationName;
            _handler = info.CreateConnectionObject;
        }

        public SqlConnInfo(CreateConnectionHandler handler)
        {
            _handler = handler;
        }

        public IDbConnection CreateConnectionObject()
        {
            return _handler();
        }

        public string ApplicationName
        {
            get
            {
                return "sqlprofilerapp";
            }
        }
    }
}
