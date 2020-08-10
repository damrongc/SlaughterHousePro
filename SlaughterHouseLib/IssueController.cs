using System.Configuration;

namespace SlaughterHouseLib
{
    public class IssueController
    {
        readonly string connstr = ConfigurationManager.AppSettings["connstr"].ToString();

    }
}
