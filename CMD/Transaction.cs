using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMD
{
    public class report
    {
        public string transaction = "<transaction>";
        public string transactionnumber { get; set; }
        public string transaction_description { get; set; }
        public string date_transaction { get; set; }
        public string teller { get; set; }
        public string authorized { get; set; }
        public string late_deposit { get; set; }
        public string value_date { get; set; }
        public string transmode_code { get; set; }
        public string amount_local { get; set; }

        #region Parent Node TFM <t_from_my_client>
        public string t_from_my_client = "<t_from_my_client>";
        public string from_funds_code { get; set; }
        public string from_funds_comment { get; set; }
        // <from_account>
        public string from_account = "<from_account>";
        public string institution_name { get; set; }
        public string institution_code { get; set; }
        public string branch { get; set; }
        public string account { get; set; }
        public string currency_code { get; set; }
        public string account_name { get; set; }
        public string client_number { get; set; }
        public string personal_account_type { get; set; }
        // <t_entity>
        public string t_entity = "<t_entity>";
        public string name { get; set; }
        public string incorporation_number { get; set; }
        public string business { get; set; }
        //<phones>
        public string phones = "<phones>";
        //<phone>
        public string phone = "<phone>";
        public string tph_contact_type { get; set; }
        public string tph_communication_type { get; set; }
        public string tph_number { get; set; }
        //</phone>
        public string end_phone = "</phone>";
        //</phones>
        public string end_phones = "</phones>";
        //<addresses>
        public string addresses = "<addresses>";
        //<address>
        public string eaddress = "<address>";
        public string address_type { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string country_code { get; set; }
        public string state { get; set; }
        //</addresses>
        public string end_address = "</address>";
        public string end_addresses = "</addresses>";
        public string incorporation_state { get; set; }
        public string incorporation_country_code { get; set; }
        //<director_id>
        public string director_id = "<director_id>";
        public string first_name { get; set; }
        public string last_name { get; set; }
        //</director_id>
        public string end_director_id = "</director_id>";
        // </t_entity>
        public string end_t_entity = "</t_entity>";
        // <signatory>
        public string signatory = "<signatory>";
        // <t_person>
        public string t_person = "<t_person>";
        public string title { get; set; }
        public string Tfirst_name { get; set; }
        public string Tlast_name { get; set; }
        public string birthdate { get; set; }
        public string nationality1 { get; set; }
        public string residence { get; set; }
        public string occupation { get; set; }

        //<identification>
        public string identification = "<identification>";
        public string type { get; set; }
        public string number { get; set; }
        public string issued_by { get; set; }
        public string issue_country { get; set; }
        //</identification>
        public string end_identification = "</identification>";
        // </t_person>
        public string end_t_person = "</t_person>";
        // </signatory>
        public string end_signatory = "</signatory>";
        public string opened { get; set; }
        public string balance { get; set; }
        public string status_code { get; set; }
        //</from_account>
        public string end_from_account = "</from_account>";
        public string from_country { get; set; }
        // </t_from_my_client>
        public string end_t_from_my_client = "</t_from_my_client>";
        //<t_to>
        public string t_to = "<t_to>";
        public string to_funds_code { get; set; }
        public string to_funds_comment { get; set; }
        //<to_account>>
        public string to_account = "<to_account>";
        public string Tinstitution_name { get; set; }
        public string Tinstitution_code { get; set; }
        public string Tbranch { get; set; }
        public string Taccount { get; set; }
        public string Taccount_name { get; set; }
        public string beneficiary { get; set; }
        //</to_account>
        public string end_to_account = "</to_account>";
        public string to_country { get; set; }
        // </t_to>
        public string end_t_to = "</t_to>";
        // </transaction>
        public string end_transaction = "</transaction>";

        #endregion


    }

    public class header
    {
        public string rentity_id { get; set; }
        public string submission_code { get; set; }
        public string report_code { get; set; }
        public string submission_date { get; set; }
        public string currency_code_local { get; set; }
        //<reporting_person>
        public string reporting_person = "<reporting_person>";
        public string gender { get; set; }
        public string title { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string birthdate { get; set; }
        public string birth_place { get; set; }
        public string mothers_name { get; set; }
        public string passport_number { get; set; }
        public string passport_country { get; set; }
        public string id_number { get; set; }
        public string nationality1 { get; set; }
        public string residence { get; set; }

        // <phones>
        //<phone>
        public string phones = "<phones>";
        public string phone = "<phone>";
        public string tph_contact_type { get; set; }
        public string tph_communication_type { get; set; }
        public string tph_number { get; set; }
        public string end_phone = "</phone>";
        public string end_phones = "</phones>";

        //<addresses>
        public string addresses = "<addresses>";
        public string eaddress = "<address>";

        public string address_type { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string country_code { get; set; }
        public string state { get; set; }
        //</address>
        public string end_address = "</address>";
        public string end_addresses = "</addresses>";
        public string email { get; set; }
        public string occupation { get; set; }
        public string employer_name { get; set; }
        //<employer_address_id>
        public string employer_address_id = "<employer_address_id>";
        public string empaddress_type { get; set; }
        public string empaddress { get; set; }
        public string empcity { get; set; }
        public string empcountry_code { get; set; }
        public string empstate { get; set; }
        //</employer_address_id>
        public string end_employer_address_id = "</employer_address_id>";
        //<employer_phone_id>
        public string employer_phone_id = "<employer_phone_id>";
        public string emptph_contact_type { get; set; }
        public string emptph_communication_type { get; set; }
        public string emptph_number { get; set; }
        //</employer_phone_id>
        public string end_employer_phone_id = "</employer_phone_id>";
        public string source_of_wealth { get; set; }
        //</reporting_person>
        public string end_reporting_person = "</reporting_person>";
    }


}
