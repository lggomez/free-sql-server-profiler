namespace AnfiniL.SqlServerTools
{
    public interface IServerConnector
    {
        string[] GetServerList();
        bool TestConnection(string serverName, string userName, string password, out string error);
        bool TestConnection(string serverName, out string error);
        bool TestRawConnection(string rawConnectionString, out string error);
    }
}
