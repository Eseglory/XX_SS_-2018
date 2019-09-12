using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMD.Helper_Classes
{
    public class _Connection
    {
        public OracleConnection _connection()
        {
            OracleConnection conn = new OracleConnection("DATA SOURCE=EDEVELOPER:1521/orcl;USER ID=AMLCORE;Password=Eseosa1$");
            return conn;
        }
        public OracleDataAdapter UserProfile(string userName, string passWord)
        {
            OracleDataAdapter Headerdr = new OracleDataAdapter("select * from AMLCORE.REPORT_ENTITY", _connection());
            return Headerdr;
        }
        public OracleDataAdapter GET_DATA(string reportType)
        {

            OracleDataAdapter dr = new OracleDataAdapter();
            if(reportType == "INWC/OTWC")
            {
                dr = new OracleDataAdapter(@"select * from AMLCORE.CTR_TRANSACTIONS WHERE CODE_FROM_TRANS = 'INWC' or CODE_FROM_TRANS = 'OTWC' and SIGNATORY_DOB is not null ", _connection());
                return dr;
            }
            else if (reportType == "BCSC/BCSA")
            {
                dr = new OracleDataAdapter(@"select * from AMLCORE.CTR_TRANSACTIONS WHERE CODE_FROM_TRANS = 'BCSA' or CODE_FROM_TRANS = 'BCSC' and SIGNATORY_DOB is not null ", _connection());
                return dr;
            }
            else
            {
                dr = new OracleDataAdapter(@"select * from AMLCORE.CTR_TRANSACTIONS WHERE CODE_FROM_TRANS = '" + reportType + "' and SIGNATORY_DOB is not null ", _connection());
                return dr;
            }
        }
    }
}
