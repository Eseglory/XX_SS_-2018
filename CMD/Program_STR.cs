using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;

namespace CMD
{
    class Program
    {
        OleDbConnection cn = new OleDbConnection("Provider=MSDAORA; DATA SOURCE=EDEVELOPER:1521/xe;DBA PRIVILEGE=SYSDBA;USER ID=SYS;Password=eseosa12345");

        static void Main(string[] args)
        {
            OracleConnection conn = new OracleConnection("DATA SOURCE=EDEVELOPER:1521/xe;DBA PRIVILEGE=SYSDBA;USER ID=SYS;Password=eseosa12345");
            OracleDataAdapter Headerdr = new OracleDataAdapter("select * from SYS.REPORT_ENTITY", conn);
            OracleDataAdapter dr = new OracleDataAdapter("select * from SYS.STR_TRANSACTIONS", conn);
            DataSet Headerds = new DataSet();
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                Headerdr.Fill(Headerds);
                dr.Fill(ds);
                conn.Close();
                var HeaderEE = Headerds.Tables[0].AsEnumerable().FirstOrDefault();
                var EE = ds.Tables[0].AsEnumerable();
                header headerrp = new header();
                report rp = new report();
                List<report> rpList = new List<report>();
                string path1 = @"C:\SASReport\AppendFile.xml";
                #region Header Item
                string Helementitem1 = headerrp.rentity_id = HeaderEE.Field<string>("rentity_id".ToUpper());
                string Helementitem2 = headerrp.submission_code = HeaderEE.Field<string>("submission_code".ToUpper());
                string Helementitem3 = headerrp.report_code = HeaderEE.Field<string>("report_code".ToUpper());
                string Helementitem4 = headerrp.submission_date = HeaderEE.Field<string>("submission_date".ToUpper());
                string Helementitem5 = headerrp.currency_code_local = HeaderEE.Field<string>("currency_code_local".ToUpper());
                string Helementitem6 = headerrp.gender = HeaderEE.Field<string>("gender".ToUpper());
                string Helementitem7 = headerrp.title = HeaderEE.Field<string>("e_title".ToUpper());
                string Helementitem8 = headerrp.first_name = HeaderEE.Field<string>("e_first_name".ToUpper());
                string Helementitem9 = headerrp.middle_name = HeaderEE.Field<string>("e_middle_name".ToUpper());
                string Helementitem10 = headerrp.last_name = HeaderEE.Field<string>("e_last_name".ToUpper());
                string Helementitem11 = headerrp.birthdate = HeaderEE.Field<string>("e_birthdate".ToUpper());
                string Helementitem12 = headerrp.birth_place = HeaderEE.Field<string>("birth_place".ToUpper());
                string Helementitem13 = headerrp.mothers_name = HeaderEE.Field<string>("mothers_name".ToUpper());
                string Helementitem14 = headerrp.passport_number = HeaderEE.Field<string>("passport_number".ToUpper());
                string Helementitem15 = headerrp.passport_country = HeaderEE.Field<string>("passport_country".ToUpper());
                string Helementitem16 = headerrp.id_number = HeaderEE.Field<string>("id_number".ToUpper());
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

                foreach (var rec in EE)
                {
                    #region Body Item
                    string Bodyementitem1 = rp.transactionnumber = rec.Field<string>("TRANSACTIONNUMBER");
                    string Bodyementitem2 = rp.transaction_description = rec.Field<string>("TRANSACTION_DESCRIPTION");
                    string Bodyementitem3 = rp.date_transaction = rec.Field<string>("DATE_TRANSACTION");
                    string Bodyementitem4 = rp.teller = rec.Field<string>("TELLER");
                    string Bodyementitem5 = rp.authorized = rec.Field<string>("AUTHORIZED");
                    string Bodyementitem6 = rp.late_deposit = rec.Field<string>("LATE_DEPOSIT");
                    string Bodyementitem7 = rp.value_date = rec.Field<string>("VALUE_DATE");
                    string Bodyementitem8 = rp.transmode_code = rec.Field<string>("TRANSMODE_CODE");
                    string Bodyementitem9 = rp.amount_local = rec.Field<string>("AMOUNT_LOCAL");
                    string Bodyementitem10 = rp.from_funds_code = rec.Field<string>("FROM_FUNDS_CODE");
                    string Bodyementitem11 = rp.from_funds_comment = rec.Field<string>("from_funds_comment".ToUpper());
                    string Bodyementitem12 = rp.institution_name = rec.Field<string>("FROM_INSTITUTION_NAME".ToUpper());
                    string Bodyementitem13 = rp.institution_code = rec.Field<string>("FROM_INSTITUTION_CODE".ToUpper());
                    string Bodyementitem14 = rp.branch = rec.Field<string>("TO_BRANCH".ToUpper());
                    string Bodyementitem15 = rp.account = rec.Field<string>("FROM_ACCOUNT".ToUpper());
                    string Bodyementitem16 = rp.currency_code = rec.Field<string>("TO_CURRENCY_CODE".ToUpper());
                    string Bodyementitem17 = rp.account_name = rec.Field<string>("TO_ACCOUNT_NAME".ToUpper());
                    string Bodyementitem18 = rp.client_number = rec.Field<string>("TO_CLIENT_NUMBER".ToUpper());
                    string Bodyementitem1_8 = rp.personal_account_type = rec.Field<string>("personal_account_type".ToUpper());

                    string Bodyementitem19 = rp.name = rec.Field<string>("FROM_ACCOUNT_NAME".ToUpper());
                    string Bodyementitem20 = rp.incorporation_number = rec.Field<string>("incorporation_number".ToUpper());
                    string Bodyementitem21 = rp.business = rec.Field<string>("business".ToUpper());
                    string Bodyementitem22 = rp.tph_contact_type = rec.Field<string>("tph_contact_type".ToUpper());
                    string Bodyementitem23 = rp.tph_communication_type = rec.Field<string>("tph_communication_type".ToUpper());
                    string Bodyementitem24 = rp.tph_number = rec.Field<string>("tph_number".ToUpper());
                    string Bodyementitem25 = rp.address_type = rec.Field<string>("address_type".ToUpper());
                    string Bodyementitem26 = rp.address = rec.Field<string>("address".ToUpper());



                    string Bodyementitem27 = rp.city = rec.Field<string>("city".ToUpper());
                    string Bodyementitem28 = rp.country_code = rec.Field<string>("TO_ACCOUNT_COUNTRY".ToUpper());
                    string Bodyementitem29 = rp.state = rec.Field<string>("incorporation_state".ToUpper());
                    string Bodyementitem30 = rp.incorporation_state = rec.Field<string>("incorporation_state".ToUpper());
                    string Bodyementitem31 = rp.incorporation_country_code = rec.Field<string>("TO_ACCOUNT_COUNTRY".ToUpper());
                    string Bodyementitem32 = rp.first_name = rec.Field<string>("SIGNATORY_FIRST_NAME".ToUpper());
                    string Bodyementitem33 = rp.last_name = rec.Field<string>("SIGNATORY_LAST_NAME".ToUpper());
                    string Bodyementitem34 = rp.title = rec.Field<string>("SIGNATORY_TITLE".ToUpper());
                    string Bodyementitem35 = rp.Tfirst_name = rec.Field<string>("SIGNATORY_FIRST_NAME".ToUpper());


                    string Bodyementitem36 = rp.Tlast_name = rec.Field<string>("SIGNATORY_LAST_NAME".ToUpper());
                    string Bodyementitem37 = rp.birthdate = rec.Field<string>("SIGNATORY_DOB".ToUpper());
                    string Bodyementitem38 = rp.nationality1 = rec.Field<string>("SIGNATORY_NATIONALITY".ToUpper());
                    string Bodyementitem39 = rp.residence = rec.Field<string>("SIGNATORY_RESIDENCE".ToUpper());
                    string Bodyementitem40 = rp.occupation = rec.Field<string>("SIGNATORY_OCCUPATION".ToUpper());
                    string Bodyementitem41 = rp.type = rec.Field<string>("type".ToUpper());
                    string Bodyementitem42 = rp.number = rec.Field<string>("enumber".ToUpper());
                    string Bodyementitem43 = rp.issued_by = rec.Field<string>("issued_by".ToUpper());
                    string Bodyementitem4_3 = rp.issue_country = rec.Field<string>("issue_country".ToUpper());

                    string Bodyementitem44 = "2017-11-11";//rp.opened = rec.Field<string>("TO_ACCT_OPENED".ToUpper());
                    string Bodyementitem45 = rp.balance = rec.Field<string>("TO_ACCT_BALANCE".ToUpper());
                    string Bodyementitem46 = rp.status_code = rec.Field<string>("TO_ACCT_STATUS_CODE".ToUpper());
                    string Bodyementitem47 = rp.from_country = rec.Field<string>("from_country".ToUpper());
                    string Bodyementitem48 = rp.to_funds_code = rec.Field<string>("TO_FUNDS_CODE".ToUpper());
                    string Bodyementitem49 = rp.to_funds_comment = rec.Field<string>("TO_FUNDS_COMMENTS".ToUpper());
                    string Bodyementitem50 = rp.Tinstitution_name = rec.Field<string>("FROM_INSTITUTION_NAME".ToUpper());
                    string Bodyementitem51 = rp.Tinstitution_code = rec.Field<string>("FROM_INSTITUTION_CODE".ToUpper());
                    string Bodyementitem52 = rp.Tbranch = rec.Field<string>("TO_BRANCH".ToUpper());
                    string Bodyementitem53 = rp.Taccount = rec.Field<string>("TO_ACCOUNT".ToUpper());
                    string Bodyementitem54 = rp.Taccount_name = rec.Field<string>("TO_ACCOUNT_NAME".ToUpper());
                    string Bodyementitem55 = rp.beneficiary = rec.Field<string>("TO_CLIENT_NUMBER".ToUpper());
                    string Bodyementitem56 = rp.to_country = rec.Field<string>("TO_ACCOUNT_COUNTRY".ToUpper());
                    #endregion

                    rpList.Add(rp);
                }

                #region XML Defined Strings
                string xml = " <? xml version = \"1.0\" ?>";
                string STitle = "<report>";

                #region Report Header
                string XMLHEADER = xml + STitle + Helement1 + Helement2 + Helement3 + Helement4 + Helement5
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

                using (StreamWriter outputFile = new StreamWriter(path1, true))
                {
                    outputFile.WriteLine(XMLHEADER);
                }
                #endregion

                using (StreamWriter outputFile = new StreamWriter(path1, true))
                {
                    foreach (var rec in rpList)
                    {
                        #region Body Element
                        string Bodyement1 = "<transactionnumber>" + rec.transactionnumber.Trim() + "</transactionnumber>";
                        string Bodyement2 = "<transaction_description>" + rec.transaction_description.Trim() + "</transaction_description>";
                        string Bodyement3 = "<date_transaction>" + rec.date_transaction.Trim() + "</date_transaction>";
                        string Bodyement4 = "<teller>" + rec.teller.Trim() + "</teller>";
                        string Bodyement5 = "<authorized>" + rec.authorized.Trim() + "</authorized>";
                        string Bodyement6 = "<late_deposit>" + rec.late_deposit.Trim() + "</late_deposit>";
                       // string Bodyement7 = "<value_date>" + rec.value_date.Trim() + "</value_date>";
                        string Bodyement8 = "<transmode_code>" + rec.transmode_code.Trim() + "</transmode_code>";
                        string Bodyement9 = "<amount_local>" + rec.amount_local.Trim() + "</amount_local>";
                        string Bodyement10 = "<from_funds_code>" + rec.from_funds_code.Trim() + "</from_funds_code>";
                       // string Bodyement11 = "<from_funds_comment>" + rec.from_funds_comment.Trim() + "</from_funds_comment>";
                        string Bodyement12 = "<institution_name>" + rec.institution_name.Trim() + "</institution_name>";
                        string Bodyement13 = "<institution_code>" + rec.institution_code.Trim() + "</institution_code>";
                        string Bodyement14 = "<branch>" + rec.branch.Trim() + "</branch>";
                        string Bodyement15 = "<account>" + rec.account.Trim() + "</account>";
                        string Bodyement16 = "<currency_code>" + rec.currency_code.Trim() + "</currency_code>";
                        string Bodyement17 = "<account_name>" + rec.account_name.Trim() + "</account_name>";
                        string Bodyement18 = "<client_number>" + rec.client_number.Trim() + "</client_number>";
                        string Bodyement1_8 = "<personal_account_type>" + rec.personal_account_type.Trim() + "</personal_account_type>";

                        string Bodyement19 = "<name>" + rec.name.Trim() + "</name>";
                        //string Bodyement20 = "<incorporation_number>" + rec.incorporation_number.Trim() + "</incorporation_number>";
                        //string Bodyement21 = "<business>" + rec.business.Trim() + "</business>";
                        //string Bodyement22 = "<tph_contact_type>" + rec.tph_contact_type.Trim() + "</tph_contact_type>";
                        //string Bodyement23 = "<tph_communication_type>" + rec.tph_communication_type.Trim() + "</tph_communication_type>";
                        //string Bodyement24 = "<tph_number>" + rec.tph_number.Trim() + "</tph_number>";
                        //string Bodyement25 = "<address_type>" + rec.address_type.Trim() + "</address_type>";
                        //string Bodyement26 = "<address>" + rec.address.Trim() + "</address>";



                        //string Bodyement27 = "<city>" + rec.city.Trim() + "</city>";
                        string Bodyement28 = "<country_code>" + rec.country_code.Trim() + "</country_code>";
                        //string Bodyement29 = "<state>" + rec.state.Trim() + "</state>";
                        //string Bodyement30 = "<incorporation_state>" + rec.incorporation_state.Trim() + "</incorporation_state>";
                        string Bodyement31 = "<incorporation_country_code>" + rec.incorporation_country_code.Trim() + "</incorporation_country_code>";
                        string Bodyement32 = "<first_name>" + rec.first_name.Trim() + "</first_name>";
                        string Bodyement33 = "<last_name>" + rec.last_name.Trim() + "</last_name>";
                        string Bodyement34 = "<title>" + rec.title.Trim() + "</title>";
                        string Bodyement35 = "<first_name>" + rec.first_name.Trim() + "</first_name>";


                        string Bodyement36 = "<last_name>" + rec.last_name.Trim() + "</last_name>";
                        string Bodyement37 = "<birthdate>" + rec.birthdate.Trim() + "</birthdate>";
                        string Bodyement38 = "<nationality1>" + rec.nationality1.Trim() + "</nationality1>";
                        string Bodyement39 = "<residence>" + rec.residence.Trim() + "</residence>";
                        string Bodyement40 = "<occupation>" + rec.occupation.Trim() + "</occupation>";
                        string Bodyement41 = "<type>" + rec.type.Trim() + "</type>";
                        string Bodyement42 = "<number>" + rec.number.Trim() + "</number>";
                        string Bodyement43 = "<issued_by>" + rec.issued_by.Trim() + "</issued_by>";
                        string Bodyement4_3 = "<issue_country>" + rec.issue_country.Trim() + "</issue_country>";

                        string Bodyement44 = "<opened>" + rec.opened.Trim() + "</opened>";
                        string Bodyement45 = "<balance>" + rec.balance.Trim() + "</balance>";
                        string Bodyement46 = "<status_code>" + rec.status_code.Trim() + "</status_code>";
                        string Bodyement47 = "<from_country>" + rec.from_country.Trim() + "</from_country>";
                        string Bodyement48 = "<to_funds_code>" + rec.to_funds_code.Trim() + "</to_funds_code>";
                        string Bodyement49 = "<to_funds_comment>" + rec.to_funds_comment.Trim() + "</to_funds_comment>";
                        string Bodyement50 = "<institution_name>" + rec.institution_name.Trim() + "</institution_name>";
                        string Bodyement51 = "<institution_code>" + rec.institution_code.Trim() + "</institution_code>";
                        string Bodyement52 = "<branch>" + rec.branch.Trim() + "</branch>";
                        string Bodyement53 = "<account>" + rec.account.Trim() + "</account>";
                        string Bodyement54 = "<account_name>" + rec.account_name.Trim() + "</account_name>";
                        string Bodyement55 = "<beneficiary>" + rec.beneficiary.Trim() + "</beneficiary>";
                        string Bodyement56 = "<to_country>" + rec.to_country.Trim() + "</to_country>";
                        rpList.Add(rp);
                        #endregion

                        #region Load
                        rp.transaction = "<transaction>";
                        rp.transactionnumber = Bodyement1;
                        rp.transaction_description = Bodyement2;
                        rp.date_transaction = Bodyement3;
                        rp.teller = Bodyement4;
                        rp.authorized = Bodyement5;
                        rp.late_deposit = Bodyement6;
                        //rp.value_date = Bodyement7;
                        rp.transmode_code = Bodyement8;
                        rp.amount_local = Bodyement9;
                        rp.t_from_my_client = "<t_from_my_client>";

                        rp.from_funds_code = Bodyement10;
                       // rp.from_funds_comment = Bodyement11;

                        rp.from_account = "<from_account>";

                        rp.institution_name = Bodyement12;
                        rp.institution_code = Bodyement13;
                        rp.branch = Bodyement14;
                        rp.account = Bodyement15;
                        rp.currency_code = Bodyement16;
                        rp.account_name = Bodyement17;
                        rp.client_number = Bodyement18;
                        rp.personal_account_type = Bodyement1_8;

                        rp.t_entity = "<t_entity>";

                        rp.name = Bodyement19;
                       // rp.incorporation_number = Bodyement20;
                       // rp.business = Bodyement21;
                        rp.phones = "<phones>";
                        rp.phone = "<phone>";

                       // rp.tph_contact_type = Bodyement22;
                       // rp.tph_communication_type = Bodyement23;
                       // rp.tph_number = Bodyement24;
                        rp.end_phone = "</phone>";
                        rp.end_phones = "</phones>";
                        rp.addresses = "<addresses>";
                        rp.address = "<address>";

                        //rp.address_type = Bodyement25;
                        //rp.address = Bodyement26;
                        //rp.city = Bodyement27;
                        rp.country_code = Bodyement28;
                        //rp.state = Bodyement29;
                        rp.end_address = "</address>";
                        rp.end_addresses = "</addresses>";

                        //rp.incorporation_state = Bodyement30;
                        rp.incorporation_country_code = Bodyement31;
                        rp.director_id = "<director_id>";

                        rp.first_name = Bodyement32;
                        rp.last_name = Bodyement33;
                        rp.end_director_id = "</director_id>";
                        rp.t_entity = "</t_entity>";
                        rp.signatory = "<signatory>";
                        rp.t_person = "<t_person>";

                        rp.title = Bodyement34;
                        rp.Tfirst_name = Bodyement35;


                        rp.Tlast_name = Bodyement36;
                        rp.birthdate = Bodyement37;
                        rp.nationality1 = Bodyement38;
                        rp.residence = Bodyement39;
                        rp.occupation = Bodyement40;
                        rp.identification = "<identification>";

                        rp.type = Bodyement41;
                        rp.number = Bodyement42;
                        rp.issued_by = Bodyement43;
                        rp.issue_country = Bodyement4_3;
                        rp.end_identification = "</identification>";
                        rp.end_t_person = "</t_person>";
                        rp.end_signatory = "</signatory>";

                        rp.opened = Bodyement44;
                        rp.balance = Bodyement45;
                        rp.status_code = Bodyement46;
                        rp.end_from_account = "</from_account>";


                        rp.from_country = Bodyement47;
                        rp.end_t_from_my_client = "</t_from_my_client>";

                        rp.t_to = "<t_to>";

                        rp.to_funds_code = Bodyement48;
                        rp.to_funds_comment = Bodyement49;
                        rp.to_account = "<to_account>";

                        rp.Tinstitution_name = Bodyement50;
                        rp.Tinstitution_code = Bodyement51;
                        rp.Tbranch = Bodyement52;
                        rp.Taccount = Bodyement53;
                        rp.Taccount_name = Bodyement54;
                        rp.beneficiary = Bodyement55;
                        rp.end_to_account = "</to_account>";

                        rp.to_country = Bodyement56;
                        rp.end_t_to = "</t_to>";
                        rp.end_transaction = "</transaction>";
                        #endregion

                        #region Load String
                        string LOADXMLBODY = rp.transaction + rp.transactionnumber + rp.transaction_description +
                        rp.date_transaction + rp.teller + rp.authorized + rp.late_deposit + rp.value_date + rp.transmode_code +
                        rp.amount_local + rp.t_from_my_client + rp.from_funds_code + rp.from_funds_comment + rp.from_account +
                        rp.institution_name + rp.institution_code + rp.branch + rp.account + rp.currency_code + rp.account_name +
                        rp.client_number + rp.personal_account_type + "< t_entity >" + rp.name + rp.incorporation_number + rp.business +
                        rp.phones + rp.phone + rp.tph_contact_type + rp.tph_communication_type + rp.tph_number + rp.end_phone +
                        rp.end_phones + rp.addresses + rp.eaddress + rp.address_type + rp.address + rp.city + rp.country_code +
                        rp.state + rp.end_address + rp.end_addresses + rp.incorporation_state + rp.incorporation_country_code +
                        rp.director_id + rp.first_name + rp.last_name + rp.end_director_id + rp.end_t_entity + rp.signatory + rp.t_person +
                        rp.title + rp.Tfirst_name + rp.Tlast_name + rp.birthdate + rp.nationality1 + rp.residence + rp.occupation +
                        rp.identification + rp.type + rp.number + rp.issued_by + rp.issue_country + rp.end_identification + rp.end_t_person +
                        rp.end_signatory + rp.opened + rp.balance + rp.status_code + rp.end_from_account + rp.from_country + rp.end_t_from_my_client +
                        rp.t_to + rp.to_funds_code + rp.to_funds_comment + rp.to_account + rp.Tinstitution_name + rp.Tinstitution_code +
                        rp.Tbranch + rp.Taccount + rp.Taccount_name + rp.beneficiary + rp.end_to_account + rp.to_country +
                        rp.end_t_to + rp.end_transaction;
                        #endregion

                       outputFile.WriteLine(LOADXMLBODY);
                    }
                }

                string endReport = "</report>";
                using (StreamWriter outputFile = new StreamWriter(path1, true))
                {
                    outputFile.WriteLine(endReport);
                }

                DateTime MyDate = DateTime.Now;
                string FileName = "";
                FileName = MyDate.ToShortDateString();
                string text = XMLHEADER;
                // string path = @"C:\SASReport\"+ FileName + ".xml";
                 string path = @"C:\SASReport\STR_Transaction.xml";
                System.IO.File.WriteAllText(path, text);

                string combindedString = string.Join("", rpList.ToList());
                Console.WriteLine(rp);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }

        }
    }
}
