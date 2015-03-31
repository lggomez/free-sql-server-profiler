using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AnfiniL.SqlServerTools.Impl
{
    class ServerConnector : IServerConnector
    {
        #region IServerConnector Members

        public string[] GetServerList()
        {
            string[] result = new string[SmoApplication.EnumAvailableSqlServers().Rows.Count];

            for (int i = 0; i < SmoApplication.EnumAvailableSqlServers().Rows.Count; i++)
            {
                result[i] = SmoApplication.EnumAvailableSqlServers().Rows[i]["Name"] as string;
            }

            return result;
        }

        public bool TestConnection(string serverName, string userName, string password, out string error)
        {
            return TestServerConnection(new ServerConnection(serverName, userName, password), out error);
        }

        public bool TestConnection(string serverName, out string error)
        {
            return TestServerConnection(new ServerConnection(serverName), out error);
        }

        public bool TestRawConnection(string rawConnectionString, out string error)
        {
            return TestServerConnection(new ServerConnection(new SqlConnection(rawConnectionString)), out error);
        }

        private static bool TestServerConnection(ServerConnection sc, out string error)
        {
            try
            {
                sc.ConnectTimeout = 20;//20 seconds
                sc.Connect();

                if (sc.ServerVersion.Major < 9)
                {
                    error = "Unable to profile SQL Server with version less than 9.0 (SQL Server 2005)";
                    return false;
                }

                error = string.Empty;
                return true;
            }
            catch (Exception exc)
            {
                error = exc.Message;
                return false;
            }
        }

        #endregion
    }
}
