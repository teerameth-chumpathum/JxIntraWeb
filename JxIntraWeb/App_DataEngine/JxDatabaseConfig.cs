using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JxIntraWeb.App_DataEngine
{
    public class JxDatabaseConfig
    {
        public const string ScriptConnectAppDBase1 = "Server=147.50.36.66,1888; Database=TP_PRI_MGS;User Id=tpadmin; Password=v4zXQzZ4zTuGHjPE4PBQkaGtXSQhpQ;Max Pool Size=3000;Connection Timeout=3000;Persist Security Info=True;";
        //public const string ScriptConnectAppDBase1 = "Server=61.91.54.130,1888; Database=TP_PRI_MGS;User Id=tpadmin; Password=v4zXQzZ4zTuGHjPE4PBQkaGtXSQhpQ;Max Pool Size=3000;Connection Timeout=3000;Persist Security Info=True;";
        public const string ScriptConnectAppDBase2 = "Server=147.50.36.66,1888; Database=TP_MNT_MGS;User Id=tpadmin; Password=v4zXQzZ4zTuGHjPE4PBQkaGtXSQhpQ;Max Pool Size=3000;Connection Timeout=3000;Persist Security Info=True;";
        //public const string ScriptConnectAppDBase2 = "Server=61.91.54.130,1888; Database=TP_MNT_MGS;User Id=tpadmin; Password=v4zXQzZ4zTuGHjPE4PBQkaGtXSQhpQ;Max Pool Size=3000;Connection Timeout=3000;Persist Security Info=True;";
        public const string ScriptConnectAppDBase3 = "Server=192.168.10.8\\SQLEXPRESS2014; Database=GreenWMS_THAIPARCEL;User Id=sa; Password=@pattayavr7646;Max Pool Size=3000;Connection Timeout=3000;Persist Security Info=True;";
        //
        public const string ScriptConnectAppDBaseAlias = "TP_PRI_MGS-ClD54.130";
    }
}