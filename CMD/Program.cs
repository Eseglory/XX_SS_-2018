using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;

namespace CMD
{
    class Program
    {
        OleDbConnection cn = new OleDbConnection("Provider=MSDAORA; DATA SOURCE=EDEVELOPER:1521/xe;DBA PRIVILEGE=SYSDBA;USER ID=SYS;Password=eseosa12345");
        public static string RandomNumbers(int length)
        {
            const string valid = "0123456789";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }
        static void Main(string[] args)
        {
            OracleConnection conn = new OracleConnection("DATA SOURCE=EDEVELOPER:1521/xe;DBA PRIVILEGE=SYSDBA;USER ID=SYS;Password=eseosa12345");
            OracleDataAdapter Headerdr = new OracleDataAdapter("select * from SYS.REPORT_ENTITY", conn);
            OracleDataAdapter dr = new OracleDataAdapter("select * from SYS.CTR_TRANSACTIONS WHERE FROM_FUNDS_CODE = 'K'", conn);
            DataSet Headerds = new DataSet();
            DataSet ds = new DataSet();
            try
            {
                int count = dr.SelectCommand.ArrayBindCount;
                conn.Open();
                Headerdr.Fill(Headerds);
                dr.Fill(ds);
                conn.Close();
                var HeaderEE = Headerds.Tables[0].AsEnumerable().FirstOrDefault();
                var EE = ds.Tables[0].AsEnumerable();
                header headerrp = new header();
                report rp = new report();
                List<report> rpList = new List<report>();

                #region File Name
                DateTime MyDate = DateTime.Now;
                string FileNameDate = "";
                string FileNameTime = "";
                FileNameDate = MyDate.ToShortDateString();
                FileNameTime = MyDate.ToShortTimeString();
                string EceckD = FileNameDate.Replace("/","_");
                string EceckT = FileNameTime.Replace(":", "_");
                EceckD.Trim();
                EceckT.Trim();
                EceckD = "CTR_" + EceckD + ".xml";
                string path = @"C:\SASReport\CTR_CASH\" + EceckD;
                #endregion

                #region Header Item
                string Helementitem1 = headerrp.rentity_id = HeaderEE.Field<string>("rentity_id".ToUpper());
                string Helementitem2 = headerrp.submission_code = HeaderEE.Field<string>("submission_code".ToUpper());
                string Helementitem3 = headerrp.report_code = HeaderEE.Field<string>("report_code".ToUpper());
                DateTime SUBMiteB = HeaderEE.Field<DateTime>("submission_date".ToUpper());
                #region Check Date
                string SUBMiteBDate = SUBMiteB.ToShortDateString();
                string SUBMiteBTime = SUBMiteB.ToShortTimeString();
                DateTime expextedDate = GetFormatedDate(SUBMiteBDate);
                string expextedFormat = expextedDate.ToString("yyyy/MM/dd");
                SUBMiteBDate = expextedFormat.Replace("/","-");
                #endregion
                string Helementitem4 = SUBMiteBDate + "T" + SUBMiteBTime + ":07";
                string Helementitem5 = headerrp.currency_code_local = HeaderEE.Field<string>("currency_code_local".ToUpper());
                string Helementitem6 = headerrp.gender = HeaderEE.Field<string>("gender".ToUpper());
                string Helementitem7 = headerrp.title = HeaderEE.Field<string>("e_title".ToUpper());
                string Helementitem8 = headerrp.first_name = HeaderEE.Field<string>("e_first_name".ToUpper());
                string Helementitem9 = headerrp.middle_name = HeaderEE.Field<string>("e_middle_name".ToUpper());
                string Helementitem10 = headerrp.last_name = HeaderEE.Field<string>("e_last_name".ToUpper());
                DateTime DOB = HeaderEE.Field<DateTime>("e_birthdate".ToUpper());
                #region Brake Date
                string SDOBY = DOB.Year.ToString();
                string SDOBM = DOB.Month.ToString();
                if(Convert.ToDouble(SDOBM) <= 9)
                {
                    SDOBM = "0" + SDOBM;
                }
                string SDOBD = DOB.Day.ToString();
                if (Convert.ToDouble(SDOBD) <= 9)
                {
                    SDOBD = "0" + SDOBD;
                }
                string SDOB = SDOBY + "-" + SDOBM + "-" + SDOBD;
                string SDOBTime = DOB.ToShortTimeString();
                SDOB = SDOB.Replace("/", "-");
                #endregion
                string Helementitem11 = SDOB + "T" + SDOBTime + ":08";
                string Helementitem12 = headerrp.birth_place = HeaderEE.Field<string>("birth_place".ToUpper());
                string Helementitem13 = headerrp.mothers_name = HeaderEE.Field<string>("mothers_name".ToUpper());
                string Helementitem14 = headerrp.passport_number = HeaderEE.Field<string>("passport_number".ToUpper());
                string Helementitem15 = headerrp.passport_country = HeaderEE.Field<string>("passport_country".ToUpper());
                decimal IDNUMB = HeaderEE.Field<decimal>("id_number".ToUpper());
                string Helementitem16 = IDNUMB.ToString(); //headerrp.id_number = HeaderEE.Field<string>("id_number".ToUpper());
                string Helementitem17 = headerrp.nationality1 = HeaderEE.Field<string>("e_nationality1".ToUpper());
                string Helementitem18 = headerrp.residence = HeaderEE.Field<string>("RESISDENCE".ToUpper());
                string Helementitem19 = headerrp.email = HeaderEE.Field<string>("email".ToUpper());
                string Helementitem20 = headerrp.occupation = HeaderEE.Field<string>("occupation".ToUpper());
                string Helementitem21 = headerrp.employer_name = HeaderEE.Field<string>("emp_name".ToUpper());
                string Helementitem22 = headerrp.address_type = HeaderEE.Field<string>("address_type".ToUpper());
                string Helementitem23 = headerrp.address = HeaderEE.Field<string>("address".ToUpper());
                string Helementitem24 = headerrp.city = HeaderEE.Field<string>("city".ToUpper());
                string Helementitem25 = headerrp.country_code = HeaderEE.Field<string>("country_code".ToUpper());
                string Helementitem26 = headerrp.state = HeaderEE.Field<string>("EMP_COUNTRY_STATE".ToUpper());
                string Helementitem27 = headerrp.tph_contact_type = HeaderEE.Field<string>("tph_contact_type".ToUpper());
                string Helementitem28 = headerrp.tph_communication_type = HeaderEE.Field<string>("tph_communication_type".ToUpper());
                string Helementitem29 = headerrp.tph_number = HeaderEE.Field<string>("tph_number".ToUpper());
                string Helementitem30 = headerrp.source_of_wealth = HeaderEE.Field<string>("source_of_wealth".ToUpper());
               if(Helementitem30 == null)
                {
                    Helementitem30 = "Not Defined";
                }
                #endregion

                #region Header Element
                string Helement1 = "<rentity_id>" + Helementitem1.Trim() + "</rentity_id>";
                string Helement2 = "<submission_code>" + Helementitem2.Trim() + "</submission_code>";
                string Helement3 = "<report_code>" + Helementitem3.Trim() + "</report_code>";
                string Helement4 = "<submission_date>" + Helementitem4.Trim() + "</submission_date>";
                string Helement5 = "<currency_code_local>" + Helementitem5.Trim() + "</currency_code_local>";
                string reporting_person = headerrp.reporting_person;

                string Helement6 = "<gender>" + Helementitem6.Trim() + "</gender>";
                string Helement7 = "<title>" + Helementitem7.Trim() + "</title>";
                string Helement8 = "<first_name>" + Helementitem8.Trim() + "</first_name>";
                string Helement9 = "<middle_name>" + Helementitem9.Trim() + "</middle_name>";
                string Helement10 = "<last_name>" + Helementitem10.Trim() + "</last_name>";
                string Helement11 = "<birthdate>" + Helementitem11.Trim() + "</birthdate>";
                string Helement12 = "<birth_place>" + Helementitem12.Trim() + "</birth_place>";
                string Helement13 = "<mothers_name>" + Helementitem13.Trim() + "</mothers_name>";
                string Helement14 = "<passport_number>" + Helementitem14.Trim() + "</passport_number>";
                string Helement15 = "<passport_country>" + Helementitem15.Trim() + "</passport_country>";
                string Helement16 = "<id_number>" + Helementitem16.Trim() + "</id_number>";
                string Helement17 = "<nationality1>" + Helementitem17.Trim() + "</nationality1>";
                string Helement18 = "<residence>" + Helementitem18.Trim() + "</residence>";

                string phones = headerrp.phones.Trim();
                string phone = headerrp.phone.Trim();
                //Only One Phone Node Was Defined
                string Helement2_7 = "<tph_contact_type>" + Helementitem27.Trim() + "</tph_contact_type>";
                string Helement2_8 = "<tph_communication_type>" + Helementitem28.Trim() + "</tph_communication_type>";
                string Helement2_9 = "<tph_number>" + Helementitem29.Trim() + "</tph_number>";
                string endphones = headerrp.end_phones.Trim();
                string endphone = headerrp.end_phone.Trim();

                //Only One Address Node Was Defined
                string Haddresses = "<addresses>";
                string Haddress = "<address>";
                string Helement2_2 = "<address_type>" + Helementitem22.Trim() + "</address_type>";
                string Helement2_3 = "<address>" + Helementitem23.Trim() + "</address>";
                string Helement2_4 = "<city>" + Helementitem24.Trim() + "</city>";
                string Helement2_5 = "<country_code>" + Helementitem25.Trim() + "</country_code>";
                string Helement2_6 = "<state>" + Helementitem26.Trim() + "</state>";
                string endaddress = "</address>";
                string endaddresses = "</addresses>";

                string Helement19 = "<email>" + Helementitem19.Trim() + "</email>";
                string Helement20 = "<occupation>" + Helementitem10.Trim() + "</occupation>";
                string Helement21 = "<employer_name>" + Helementitem21.Trim() + "</employer_name>";
                string employer_address_id = headerrp.employer_address_id;

                string Helement22 = "<address_type>" + Helementitem22.Trim() + "</address_type>";
                string Helement23 = "<address>" + Helementitem23.Trim() + "</address>";
                string Helement24 = "<city>" + Helementitem24.Trim() + "</city>";
                string Helement25 = "<country_code>" + Helementitem25.Trim() + "</country_code>";
                string Helement26 = "<state>" + Helementitem26.Trim() + "</state>";

                string endemployer_address_id = headerrp.end_employer_address_id;
                string employer_phone_id = "<employer_phone_id>";
                string Helement27 = "<tph_contact_type>" + Helementitem27.Trim() + "</tph_contact_type>";
                string Helement28 = "<tph_communication_type>" + Helementitem28.Trim() + "</tph_communication_type>";
                string Helement29 = "<tph_number>" + Helementitem29.Trim() + "</tph_number>";
                string end_employer_phone_id = "</employer_phone_id>";
                string Helement30 = "<source_of_wealth>" + Helementitem30.Trim() + "</source_of_wealth>";
                string end_reporting_person = headerrp.end_reporting_person;
                #endregion

                #region XML Defined Strings
                string STitle = "<report>";

                #region Report Header
                string XMLHEADER = Helement1 + Helement2 + Helement3 + Helement4 + Helement5
                    + reporting_person + Helement6 + Helement7 + Helement8 + Helement9 +
                    Helement10 + Helement11 + Helement12 + Helement13 + Helement14 + Helement15
                    + Helement16 + Helement17 + Helement18 + phones + phone + Helement2_7 +
                    Helement2_8 + Helement2_9 + endphone + endphones + Haddresses + Haddress +
                    Helement2_2 + Helement2_3 + Helement2_4 + Helement2_5 + Helement2_6 + endaddress
                    + endaddresses + Helement19 + Helement20 + Helement21 + employer_address_id +
                    Helement22 + Helement23 + Helement24 + Helement25 + Helement26 + endemployer_address_id
                    + employer_phone_id
                    + Helement27 + Helement28 + Helement29 + end_employer_phone_id +
                    Helement30 + end_reporting_person;
                #endregion

                using (StreamWriter outputFile = new StreamWriter(path, true))
                {
                    outputFile.WriteLine("<?xml version=\"1.0\" ?>");
                }
                using (StreamWriter outputFile = new StreamWriter(path, true))
                {
                    outputFile.WriteLine(STitle);
                }
                using (StreamWriter outputFile = new StreamWriter(path, true))
                {
                    outputFile.WriteLine(XMLHEADER);
                }
                #endregion

                using (StreamWriter outputFileEnd = new StreamWriter(path, true))
                {
                    foreach (var rec in EE)
                    {
                        #region Body Item
                        string transactionnumber = rp.transactionnumber = rec.Field<string>("TRANSACTIONNUMBER");
                        string transaction_description = rp.transaction_description = rec.Field<string>("TRANSACTION_DESCRIPTION");
                        transaction_description = transaction_description.Replace("&", "AND");
                        DateTime TransDate = rec.Field<DateTime>("DATE_TRANSACTION");
                        #region Brake Date
                        string TransDY = TransDate.Year.ToString();
                        string TransDM = TransDate.Month.ToString();
                        if (Convert.ToDouble(TransDM) <= 9)
                        {
                            TransDM = "0" + TransDM;
                        }
                        string TransDD = TransDate.Day.ToString();
                        if (Convert.ToDouble(TransDD) <= 9)
                        {
                            TransDD = "0" + TransDD;
                        }
                        string TransD = TransDY + "-" + TransDM + "-" + TransDD;
                        string TransDTime = TransDate.ToShortTimeString();
                        #endregion

                        string date_transaction = rp.date_transaction = TransD + "T" + TransDTime + ":09";
                        string teller = rp.teller = rec.Field<string>("TELLER");
                        string authorized = rp.authorized = rec.Field<string>("AUTHORIZED");
                        string late_deposit = rp.late_deposit = rec.Field<string>("LATE_DEPOSIT");
                        DateTime PostDate = rec.Field<DateTime>("DATE_POSTING");
                        #region Brake Date
                        string PostDateY = TransDate.Year.ToString();
                        string PostDateM = TransDate.Month.ToString();
                        if (Convert.ToDouble(PostDateM) <= 9)
                        {
                            PostDateM = "0" + PostDateM;
                        }
                        string PostDateD = TransDate.Day.ToString();
                        if (Convert.ToDouble(PostDateD) <= 9)
                        {
                            PostDateD = "0" + PostDateD;
                        }
                        string PostDateDD = PostDateY + "-" + PostDateM + "-" + PostDateD;
                        string PostDateTime = TransDate.ToShortTimeString();
                        #endregion

                        string value_date = rp.value_date = PostDateDD + "T" + PostDateTime + ":09";
                        string transmode_code = rp.transmode_code = rec.Field<string>("TRANSMODE_CODE");
                        decimal AmountLocale = rec.Field<decimal>("AMOUNT_LOCAL");
                        string amount_local = rp.amount_local = AmountLocale.ToString();
                        string from_funds_code = rp.from_funds_code = rec.Field<string>("FROM_FUNDS_CODE");
                        string from_funds_comment = rp.from_funds_comment = rec.Field<string>("FROM_FUNDS_COMMENTS".ToUpper());
                        from_funds_comment = from_funds_comment.Replace("&","AND");
                        string institution_name = rp.institution_name = rec.Field<string>("FROM_INSTITUTION_NAME".ToUpper());
                        string institution_code = rp.institution_code = rec.Field<string>("FROM_INSTITUTION_CODE".ToUpper());
                        string branch = rp.branch = rec.Field<string>("TO_BRANCH".ToUpper());
                        string account = rp.account = rec.Field<string>("FROM_ACCOUNT".ToUpper());
                        string currency_code = rp.currency_code = rec.Field<string>("TO_CURRENCY_CODE".ToUpper());
                        string account_name = rp.account_name = rec.Field<string>("FROM_ACCOUNT_NAME".ToUpper());
                        string client_number = rp.client_number = rec.Field<string>("TO_CLIENT_NUMBER".ToUpper());
                        string personal_account_type = rp.personal_account_type = rec.Field<string>("personal_account_type".ToUpper());

                        string name = rp.name = rec.Field<string>("ENT_NAME".ToUpper());
                        string incorporation_number = rp.incorporation_number = rec.Field<string>("ENT_INCORP_NO".ToUpper());
                        string business = rp.business = rec.Field<string>("ENT_BUSINESS".ToUpper());
                        string tph_contact_type = rp.tph_contact_type = rec.Field<string>("ENT_CONTACT_TYPE".ToUpper());
                        string tph_communication_type = rp.tph_communication_type = rec.Field<string>("ENT_COMM_TYPE".ToUpper());
                        string tph_number = rp.tph_number = rec.Field<string>("ENT_PHONE".ToUpper());
                        string address_type = rp.address_type = rec.Field<string>("ENT_ADDRSS_TYPE".ToUpper());
                        string address = rp.address = rec.Field<string>("ENT_ADDRESS".ToUpper());



                        string city = rp.city = rec.Field<string>("ENT_CITY".ToUpper());
                        string country_code = rp.country_code = rec.Field<string>("ENT_COUNTRY_CODE".ToUpper());
                        string state = rp.state = rec.Field<string>("ENT_STATE".ToUpper());
                        string incorporation_state = rp.incorporation_state = rec.Field<string>("ENT_INCORP_STATE".ToUpper());
                        string incorporation_country_code = rp.incorporation_country_code = rec.Field<string>("ENT_INCORP_COUNTRY_CODE".ToUpper());
                        string first_name = rp.first_name = rec.Field<string>("FROM_PERSON_FIRST_NAME".ToUpper());
                        string last_name = rp.last_name = rec.Field<string>("FROM_PERSON_LAST_NAME".ToUpper());
                        string title = rp.title = rec.Field<string>("SIGNATORY_TITLE".ToUpper());
                        string Tfirst_name = rp.Tfirst_name = rec.Field<string>("TO_PERSON_FIRST_NAME".ToUpper());
                        string dfirst_name = rp.first_name = rec.Field<string>("ENT_DIR_1ST_NAME".ToUpper());
                        string dlast_name = rp.last_name = rec.Field<string>("ENT_DIR_LAST_NAME".ToUpper());

                        string Tlast_name = rp.Tlast_name = rec.Field<string>("TO_PERSON_LAST_NAME".ToUpper());
                        DateTime? SignDate = rec.Field<DateTime?>("SIGNATORY_DOB".ToUpper());
                        if(SignDate == null)
                        {
                            SignDate = DateTime.Now;
                        }
                        if(transmode_code == null || transmode_code == "")
                        {
                            transmode_code = "C";
                        }
                        #region Brake Date
                        string SignDateDY = TransDate.Year.ToString();
                        string SignDateDM = TransDate.Month.ToString();
                        if (Convert.ToDouble(SignDateDM) <= 9)
                        {
                            SignDateDM = "0" + SignDateDM;
                        }
                        string SignDateDDD = TransDate.Day.ToString();
                        if (Convert.ToDouble(SignDateDDD) <= 9)
                        {
                            SignDateDDD = "0" + SignDateDDD;
                        }
                        string SignDateDD = SignDateDY + "-" + SignDateDM + "-" + SignDateDDD;
                        string SignDateDTime = TransDate.ToShortTimeString();
                        #endregion

                        string birthdate = rp.birthdate = SignDateDD + "T" + SignDateDTime + ":06";
                        string nationality1 = rp.nationality1 = rec.Field<string>("SIGNATORY_NATIONALITY".ToUpper());
                        if (nationality1 == "UK " || nationality1 == "UK")
                        {
                            nationality1 = "GB";
                        }
                        string residence = rp.residence = rec.Field<string>("SIGNATORY_RESIDENCE".ToUpper());
                        residence = residence.Trim();
                        if (residence.Trim() == "UK")
                        {
                            residence = "GB";
                        }
                        string occupation = rp.occupation = rec.Field<string>("SIGNATORY_OCCUPATION".ToUpper());
                        string type = rp.type = "O";//rec.Field<string>("type".ToUpper());
                        string number = rp.number = "AT" + RandomNumbers(8) ; //rec.Field<string>("enumber".ToUpper());
                        string issued_by = rp.issued_by = institution_name;//rec.Field<string>("issued_by".ToUpper());
                        string issue_country = rp.issue_country = rec.Field<string>("from_country".ToUpper());
                        DateTime OpenDate = rec.Field<DateTime>("TO_ACCT_OPENED".ToUpper());
                        #region Brake Date
                        string OpenDateDY = OpenDate.Year.ToString();
                        string OpenDateDM = OpenDate.Month.ToString();
                        if (Convert.ToDouble(OpenDateDM) <= 9)
                        {
                            OpenDateDM = "0" + OpenDateDM;
                        }
                        string OpenDateDD = OpenDate.Day.ToString();
                        if (Convert.ToDouble(OpenDateDD) <= 9)
                        {
                            OpenDateDD = "0" + OpenDateDD;
                        }
                        string OpenDateD = OpenDateDY + "-" + OpenDateDM + "-" + OpenDateDD;

                        string OpenDateTime = OpenDate.ToShortTimeString();
                        OpenDateD = OpenDateD.Replace("/", "-");
                        #endregion

                        string opened = rp.opened = OpenDateD + "T" + OpenDateTime + ":07";
                        string balance = rp.balance = rec.Field<string>("TO_ACCT_BALANCE".ToUpper());
                        string status_code = rp.status_code = rec.Field<string>("TO_ACCT_STATUS_CODE".ToUpper());
                        string from_country = rp.from_country = rec.Field<string>("from_country".ToUpper());
                        string to_funds_code = rp.to_funds_code = rec.Field<string>("TO_FUNDS_CODE".ToUpper());
                        string to_funds_comment = rp.to_funds_comment = rec.Field<string>("TO_FUNDS_COMMENTS".ToUpper());
                        to_funds_comment = to_funds_comment.Replace("&", "AND");
                        string Tinstitution_name = rp.Tinstitution_name = rec.Field<string>("TO_INSTITUTION_NAME".ToUpper());
                        string Tinstitution_code = rp.Tinstitution_code = rec.Field<string>("TO_INSTITUTION_CODE".ToUpper());
                        string Tbranch = rp.Tbranch = rec.Field<string>("TO_BRANCH".ToUpper());
                        string Taccount = rp.Taccount = rec.Field<string>("TO_ACCOUNT".ToUpper());
                        string Taccount_name = rp.Taccount_name = rec.Field<string>("TO_ACCOUNT_NAME".ToUpper());
                        string beneficiary = rp.beneficiary = rec.Field<string>("TO_CLIENT_NUMBER".ToUpper());
                        string to_country = rp.to_country = rec.Field<string>("TO_ACCOUNT_COUNTRY".ToUpper());

                        if (incorporation_country_code.Trim() == "UK")
                        {
                            incorporation_country_code = "GB";
                        }
                        if (to_country.Trim() == "UK")
                        {
                            to_country = "GB";
                        }

                        if (country_code.Trim() == "UK")
                        {
                            country_code = "GB";
                        }
                        #region signatory
                        string SignTile = rp.to_country = rec.Field<string>("SIGNATORY_TITLE".ToUpper());
                        string SignFName = rp.to_country = rec.Field<string>("SIGNATORY_FIRST_NAME".ToUpper());
                        string SignLName = rp.to_country = rec.Field<string>("SIGNATORY_LAST_NAME".ToUpper());
                        DateTime SignDOB =  rec.Field<DateTime>("SIGNATORY_DOB".ToUpper());
                        string SignNationality = rp.to_country = rec.Field<string>("SIGNATORY_NATIONALITY".ToUpper());
                        string SignResidence = rp.to_country = rec.Field<string>("SIGNATORY_RESIDENCE".ToUpper());
                        SignResidence = SignResidence.Trim();
                        SignNationality = SignNationality.Trim();
                        string SignOccupation = rp.to_country = rec.Field<string>("SIGNATORY_OCCUPATION".ToUpper());
                        if(SignOccupation == null || SignOccupation == "") { SignOccupation = "Not Defined"; }
                        #region Brake Date
                        string YSignDOB = SignDOB.Year.ToString();
                        string MSignDOB = SignDOB.Month.ToString();
                        if (Convert.ToDouble(MSignDOB) <= 9)
                        {
                            MSignDOB = "0" + MSignDOB;
                        }
                        string SignDOBD = SignDOB.Day.ToString();
                        if (Convert.ToDouble(SignDOBD) <= 9)
                        {
                            SignDOBD = "0" + SignDOBD;
                        }
                        string SignDOBs = YSignDOB + "-" + MSignDOB + "-" + SignDOBD;

                        string SignDOBT = SignDOB.ToShortTimeString();
                        SignDOBs = SignDOBs.Replace("/", "-");
                        string SignDOBNazo = SignDOBs + "T" + OpenDateTime + ":07";
                        #endregion

                        #endregion
                        #endregion

                        #region Body Element
                        string transaction = "<transaction>";
                        string Bodyement1 = "<transactionnumber>" + transactionnumber.Trim() + "</transactionnumber>";
                        string Bodyement2 = "<transaction_description>" + transaction_description.Trim() + "</transaction_description>";
                        string Bodyement3 = "<date_transaction>" + date_transaction.Trim() + "</date_transaction>";
                        string Bodyement4 = "<teller>" + teller.Trim() + "</teller>";
                        string Bodyement5 = "<authorized>" + authorized.Trim() + "</authorized>";
                        string Bodyement6 = "<late_deposit>" + late_deposit.Trim() + "</late_deposit>";
                        string Bodyement7 = "<value_date>" + value_date.Trim() + "</value_date>";
                        string Bodyement8 = "<transmode_code>" + transmode_code.Trim() + "</transmode_code>";
                        string Bodyement9 = "<amount_local>" + amount_local.Trim() + "</amount_local>";

                        string t_from_my_client = "<t_from_my_client>";
                        string Bodyement10 = "<from_funds_code>" + from_funds_code.Trim() + "</from_funds_code>";
                        string Bodyement11 = "<from_funds_comment>" + from_funds_comment.Trim() + "</from_funds_comment>";
                        #region From Account
                        string from_account = "<from_account>";
                        string Bodyement12 = "<institution_name>" + institution_name.Trim() + "</institution_name>";
                        string Bodyement13 = "<institution_code>" + institution_code.Trim() + "</institution_code>";
                        string Bodyement14 = "<branch>" + branch.Trim() + "</branch>";
                        if (account == string.Empty || account == null || account == "")
                        {
                            account = "Not Defined";
                        }
                        if (account_name == string.Empty || account_name == null || account_name == "")
                        {
                            account_name = "Not Defined";
                        }
                        if (name == string.Empty || name == null || name == "")
                        {
                            name = "Not Defined";
                        }
                        if (client_number == string.Empty || client_number == null || client_number == "")
                        {
                            client_number = "Not Defined";
                        }
                        if(personal_account_type == null || personal_account_type == "")
                        {
                            personal_account_type = "A";
                        }
                        string Bodyement15 = "<account>" + account.Trim() + "</account>";
                        string Bodyement16 = "<currency_code>" + currency_code.Trim() + "</currency_code>";
                        string Bodyement17 = "<account_name>" + account_name.Trim() + "</account_name>";
                        string Bodyement18 = "<client_number>" + client_number.Trim() + "</client_number>";
                        string Bodyement1_8 = "<personal_account_type>" + personal_account_type.Trim() + "</personal_account_type>";
                        string t_entity = "<t_entity>";
                        string Bodyement19 = "<name>" + name.Trim() + "</name>";
                        string Bodyement20 = "<incorporation_number>" + incorporation_number.Trim() + "</incorporation_number>";
                        string Bodyement21 = "<business>" + business.Trim() + "</business>";
                        string phonesM = "<phones>";
                        string phoneM = "<phone>";
                        string Bodyement22 = "<tph_contact_type>" + tph_contact_type.Trim() + "</tph_contact_type>";
                        string Bodyement23 = "<tph_communication_type>" + tph_communication_type.Trim() + "</tph_communication_type>";
                        string Bodyement24 = "<tph_number>" + tph_number.Trim() + "</tph_number>";
                        string end_phone = "</phone>";
                        string end_phones = "</phones>";
                        string addresses = "<addresses>";
                        string eaddress = "<address>";
                        string Bodyement25 = "<address_type>" + address_type.Trim() + "</address_type>";
                        if (city == string.Empty || city == null || city == "")
                        {
                            city = "Not Defined";
                        }
                        string Bodyement26 = "<address>" + address.Trim() + "</address>";
                        string Bodyement27 = "<city>" + city.Trim() + "</city>";
                        string Bodyement28 = "<country_code>" + country_code.Trim() + "</country_code>";
                        string Bodyement29 = "<state>" + state.Trim() + "</state>";
                        string end_address = "</address>";
                        string end_addresses = "</addresses>";
                        string Bodyement30 = "<incorporation_state>" + incorporation_state.Trim() + "</incorporation_state>";
                        string Bodyement31 = "<incorporation_country_code>" + incorporation_country_code.Trim() + "</incorporation_country_code>";
                        string director_id = "<director_id>";
                        string Bodyement32 = "<first_name>" + dfirst_name.Trim() + "</first_name>";
                        string Bodyement33 = "<last_name>" + dlast_name.Trim() + "</last_name>";
                        string end_director_id = "</director_id>";
                        string end_t_entity = "</t_entity>";
                        string signatory = "<signatory>";
                        string t_person = "<t_person>";
                        #region not defined
                        if (title == string.Empty || title == null || title == "")
                        {
                            title = "Not Defined";
                        }
                        if (first_name == string.Empty || first_name == null || first_name == "")
                        {
                            first_name = "Not Defined";
                        }
                        if (last_name == string.Empty || last_name == null || last_name == "")
                        {
                            last_name = "Not Defined";
                        }
                        if (Tfirst_name == string.Empty || Tfirst_name == null || Tfirst_name == "")
                        {
                            Tfirst_name = "Not Defined";
                        }
                        if (Tlast_name == string.Empty || Tlast_name == null || Tlast_name == "")
                        {
                            Tlast_name = "Not Defined";
                        }
                        if (nationality1 == string.Empty || nationality1 == null || nationality1 == "")
                        {
                            if (residence != null || residence != "")
                            {
                                nationality1 = residence;
                            }
                            else
                            {
                                nationality1 = "Not Defined";
                            }
                        }
                        if (nationality1 == string.Empty || nationality1 == null || nationality1 == "")
                        {
                            nationality1 = "Not Defined";
                        }
                        if(tph_contact_type == "xx" || tph_contact_type == null)
                        {
                            tph_contact_type = "B";
                        }
                        if (tph_contact_type == "xx" || tph_contact_type == null)
                        {
                            tph_contact_type = "B";
                        }
                        if (tph_communication_type == "xx" || tph_communication_type == null)
                        {
                            tph_contact_type = "M";
                        }
                        if (address_type == "xx" || address_type == null)
                        {
                            tph_contact_type = "B";
                        }
                        #endregion
                        string Bodyement34 = "<title>" + title.Trim() + "</title>";
                        string Bodyement35 = "<first_name>" + first_name.Trim() + "</first_name>";
                        string Bodyement36 = "<last_name>" + last_name.Trim() + "</last_name>";
                        string Bodyement37 = "<birthdate>" + birthdate.Trim() + "</birthdate>";
                        string Bodyement38 = "<nationality1>" + nationality1.Trim() + "</nationality1>";
                        string Bodyement39 = "<residence>" + residence.Trim() + "</residence>";
                        if(occupation == string.Empty || occupation == null || occupation == "")
                        {
                            occupation = "Not Defined";
                        }
                        string Bodyement40 = "<occupation>" + occupation.Trim() + "</occupation>";
                        string identification = "<identification>";
                        string Bodyement41 = "<type>" + type.Trim() + "</type>";
                        if (number == string.Empty || number == null || number == "")
                        {
                            number = "Not Defined";
                        }
                        if (issued_by == string.Empty || issued_by == null || issued_by == "")
                        {
                            issued_by = "Not Defined";
                        }
                        string Bodyement42 = "<number>" + number.Trim() + "</number>";
                        string Bodyement43 = "<issued_by>" + issued_by.Trim() + "</issued_by>";
                        string Bodyement4_3 = "<issue_country>" + issue_country.Trim() + "</issue_country>";
                        string end_identification = "</identification>";
                        string end_t_person = "</t_person>";
                        string end_signatory = "</signatory>";
                        string Bodyement44 = "<opened>" + opened.Trim().ToString() + "</opened>";
                        string Bodyement45 = "<balance>" + balance.Trim() + "</balance>";
                        string Bodyement46 = "<status_code>" + status_code.Trim() + "</status_code>";
                        string end_from_account = "</from_account>";
                        #endregion
                        string Bodyement47 = "<from_country>" + from_country.Trim() + "</from_country>";
                        string end_t_from_my_client = "</t_from_my_client>";
                        string t_to = "<t_to>";
                        string Bodyement48 = "<to_funds_code>" + to_funds_code.Trim() + "</to_funds_code>";
                        string Bodyement49 = "<to_funds_comment>" + to_funds_comment.Trim() + "</to_funds_comment>";
                        #region To Account
                        string to_account = "<to_account>";
                        string Bodyement50 = "<institution_name>" + Tinstitution_name.Trim() + "</institution_name>";
                        string Bodyement51 = "<institution_code>" + Tinstitution_code.Trim() + "</institution_code>";
                        string Bodyement52 = "<branch>" + Tbranch.Trim() + "</branch>";
                        #region Not Defined
                        if (Taccount == string.Empty || Taccount == null || Taccount == "")
                        {
                            Taccount = "Not Defined";
                        }
                        if (Taccount_name == string.Empty || Taccount_name == null || Taccount_name == "")
                        {
                            Taccount_name = "Not Defined";
                        }
                        #endregion
                        string Bodyement53 = "<account>" + Taccount.Trim() + "</account>";
                        string Bodyement5_3 = "<currency_code>" + currency_code.Trim() + "</currency_code>";
                        string Bodyement54 = "<account_name>" + Taccount_name.Trim() + "</account_name>";
                        if(Taccount_name != "" || Taccount_name == "") { Taccount_name = "Not Defined"; }
                        string Bodyement5_4A = "<client_number>" + client_number.Trim() + "</client_number>";
                        string Bodyement5_4B = "<personal_account_type>" + personal_account_type + "</personal_account_type>";
                        //if (Taccount != "" || Taccount != null)
                        //{
                            string Tsignatory = "<signatory>";
                            string Tt_person = "<t_person>";
                            string Bodyement5_4C = "<title>" + SignTile.Trim() + "</title>";
                        //}
                        string Bodyement5_4D = "<first_name>" + SignFName.Trim() + "</first_name>";
                            string Bodyement5_4E = "<last_name>" + SignLName.Trim() + "</last_name>";
                        //if (Taccount != "" || Taccount != null)
                        //{
                            string Bodyement5_4F = "<birthdate>" + SignDOBNazo.Trim() + "</birthdate>";
                            string Bodyement5_4G = "<nationality1>" + SignNationality.Trim() + "</nationality1>";
                            string Bodyement5_4H = "<residence>" + SignResidence + "</residence>";
                            string Bodyement5_4I = "<occupation>" + SignOccupation + "</occupation>";
                            string end_Tt_person = "</t_person>";
                            string end_Tsignatory = "</signatory>";
                            string Bodyement5_4J = "<opened>" + opened + "</opened>";
                            string Bodyement5_4K = "<balance>" + balance + "</balance>";
                            string Bodyement5_4L = "<status_code>" + status_code + "</status_code>";
                        //}
                        string Bodyement55 = "<beneficiary>" + beneficiary.Trim() + "</beneficiary>";
                        string end_to_account = "</to_account>";
                        #endregion
                        string Bodyement56 = "<to_country>" + to_country.Trim() + "</to_country>";
                        string Bodyement5_6 = "</t_to>";
                        string Bodyement57 = "</transaction>";
                        #endregion
                        //string t_toH =
                        //  to_account + Bodyement50 + Bodyement51 + Bodyement52 + Bodyement53 +
                        //   Bodyement54 + Bodyement55 + end_to_account;
                        string t_toH =
                          to_account + Bodyement50 + Bodyement51 + Bodyement52 + Bodyement53 +
                          Bodyement5_3 + Bodyement54 + Bodyement5_4A + Bodyement5_4B + Tsignatory
                          + Tt_person + Bodyement5_4C + Bodyement5_4D + Bodyement5_4E
                          + Bodyement5_4F + Bodyement5_4G + Bodyement5_4H + Bodyement5_4I
                          + end_Tt_person + end_Tsignatory + Bodyement5_4J + Bodyement5_4K
                          + Bodyement5_4L + end_to_account;
                        string f_accH = from_account + Bodyement12 + Bodyement13 + Bodyement14 + Bodyement15
                           + Bodyement16 + Bodyement17 + Bodyement18 + Bodyement1_8 + t_entity + Bodyement19 +
                           Bodyement20 + Bodyement21 + phonesM + phoneM + Bodyement22 + Bodyement23 + Bodyement24
                           + end_phone + end_phones + addresses + eaddress + Bodyement25 + Bodyement26 + Bodyement27
                           + Bodyement28 + Bodyement29 + end_address + end_addresses + Bodyement30 + Bodyement31
                           + director_id + Bodyement32 + Bodyement33 + end_director_id + end_t_entity + signatory
                           + t_person + Bodyement34 + Bodyement35 + Bodyement36 + Bodyement37 + Bodyement38
                           + Bodyement39 + Bodyement40 + identification + Bodyement41 + Bodyement42 + Bodyement43
                           + Bodyement4_3 + end_identification + end_t_person + end_signatory + Bodyement44 + Bodyement45
                           + Bodyement46 + end_from_account;

                        #region Conditions

                        if (Taccount == "Not Defined" || Taccount.Trim() == "" || Taccount.Trim() == "CASH/CHEQUE" || Taccount == "CASH" || Taccount == "CHEQUE")
                        {
                            t_toH = "<to_person>" +
                                Bodyement5_4D + Bodyement5_4E
                                + "</to_person>";
                        }
                        if (account == "Not Defined" || account == "" || account.Trim() == "CASH/CHEQUE" || account == "CASH" || account == "CHEQUE")
                        {
                            f_accH =  "<from_person>" + Bodyement35 + Bodyement36 + "</from_person >" ;
                        }

                        if (account != "" && account != null && institution_name == "SKYE BANK NIG PLC")
                        {
                            t_from_my_client = "<t_from_my_client>";
                            end_t_from_my_client = "</t_from_my_client>";
                        }
                        else
                        {
                            t_from_my_client = "<t_from>";
                            end_t_from_my_client = "</t_from>";
                        }
                        if (Taccount != "" && account != null && Tinstitution_name == "SKYE BANK NIG PLC")
                        {
                            t_to = "<t_to_my_client>";
                            Bodyement5_6 = "</t_to_my_client>";
                        }
                        else
                        {
                            t_to = "<t_to>";
                            Bodyement5_6 = "</t_to>";
                        }
                        #endregion

                        #region LOAD DATA
                        string LD = transaction + Bodyement1 + Bodyement2 + Bodyement3 + Bodyement4 + Bodyement5
                           + Bodyement6 + Bodyement7 + Bodyement8 + Bodyement9 + t_from_my_client + Bodyement10
                           + Bodyement11 + f_accH + Bodyement47 + end_t_from_my_client + t_to
                           + Bodyement48 + Bodyement49 + t_toH + Bodyement56 + Bodyement5_6 + Bodyement57;
                        LD = LD.Replace("&", "AND");
                        #endregion

                        outputFileEnd.WriteLine(LD);
                    }
                }

                string endReport = "</report>";
                    using (StreamWriter outputFileEnd = new StreamWriter(path, true))
                    {
                        outputFileEnd.WriteLine(endReport);
                    }

                Console.WriteLine("Report Was Successfully Generated.!");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();

            }

        }
        private static DateTime GetFormatedDate(string currentformatdate)
        {
            string[] dateparts = currentformatdate.Split('/');
            DateTime expextedDate = new DateTime(Convert.ToInt32(dateparts[2]), Convert.ToInt32(dateparts[0]), Convert.ToInt32(dateparts[1]));
            return expextedDate;
        }

    }
}
