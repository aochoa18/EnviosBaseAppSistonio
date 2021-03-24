using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClienteBackend
{

    //Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Source
    {
        public string @object { get; set; }
        public string uuid { get; set; }
        public string type { get; set; }
        public string token { get; set; }
        public string brand { get; set; }
        public string country { get; set; }
        public string holder { get; set; }
        public int bin { get; set; }
        public string last4 { get; set; }
        public bool is_saved { get; set; }
        public string expire_month { get; set; }
        public string expire_year { get; set; }
        public string additional { get; set; }
        public string bank { get; set; }
        public bool prepaid { get; set; }
        public string validation_date { get; set; }
        public string creation_date { get; set; }
    }

    public class Transaction2
    {
        public string uuid { get; set; }
        public DateTime created { get; set; }
        public DateTime created_from_client_timezone { get; set; }
        public string operative { get; set; }
        public int amount { get; set; }
        public string authorization { get; set; }
        public string status { get; set; }
        public string error { get; set; }
        public Source source { get; set; }
        public string antifraud { get; set; }
    }

    public class Order
    {
        public string uuid { get; set; }
        public DateTime created { get; set; }
        public DateTime created_from_client_timezone { get; set; }
        public int amount { get; set; }
        public string currency { get; set; }
        public bool paid { get; set; }
        public string status { get; set; }
        public bool safe { get; set; }
        public int refunded { get; set; }
        public string additional { get; set; }
        public string service { get; set; }
        public string customer { get; set; }
        public List<Transaction2> transactions { get; set; }
        public string token { get; set; }
        public string ip { get; set; }
    }

    public class Client
    {
        public string uuid { get; set; }
    }

    public class Payment
    {
        public int installments { get; set; }
    }

    public class ExtraData
    {
        public Payment payment { get; set; }
    }

    public class GataweyJsonResponse
    {
        public string message { get; set; }
        public int code { get; set; }
        public DateTime current_time { get; set; }
        public Order order { get; set; }
        public Client client { get; set; }
        public ExtraData extra_data { get; set; }
    }

    public class Metadata
    {
        public int terminal_service_type_id { get; set; }
    }

    public class Gateway
    {
        public string name { get; set; }
    }

    public class Form
    {
        public string name { get; set; }
    }

    public class Metadata2
    {
        public Gateway gateway { get; set; }
        public int amount { get; set; }
        public bool is_subscription { get; set; }
        public Form form { get; set; }
    }

    public class CustomFields
    {
    }

    public class Person
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int treatment { get; set; }
        public string gender { get; set; }
        public int type { get; set; }
        public int identification_type { get; set; }
        public string identification { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string street_number { get; set; }
        public string rest_address { get; set; }
        public string zip_code { get; set; }
        public string time_zone { get; set; }
        public string language_code { get; set; }
        public string born_date { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string deleted_at { get; set; }
        public string country_id { get; set; }
        public string department { get; set; }
    }

    public class Lead
    {
        public int id { get; set; }
        public int type { get; set; }
        public string company_name { get; set; }
        public Metadata2 metadata { get; set; }
        public CustomFields custom_fields { get; set; }
        public string cookie_id { get; set; }
        public string bakery_id { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string deleted_at { get; set; }
        public int person_id { get; set; }
        public int commerce_id { get; set; }
        public bool is_from_webhook { get; set; }
        public bool is_from_zapier { get; set; }
        public string origin_app { get; set; }
        public int actual_state { get; set; }
        public string last_event { get; set; }
        public Person person { get; set; }
    }

    public class Transaction
    {
        public int id { get; set; }
        public bool is_subscription { get; set; }
        public string amount { get; set; }
        public string conversion_amount { get; set; }
        public string appeal { get; set; }
        public string fund { get; set; }
        public string url_landing { get; set; }
        public string utm_campaign { get; set; }
        public string utm_source { get; set; }
        public string utm_medium { get; set; }
        public string utm_content { get; set; }
        public string utm_term { get; set; }
        public string transaction_gateway_code { get; set; }
        public bool monthly_plan_charge { get; set; }
        public string subscription_gateway_code { get; set; }
        public int state { get; set; }
        public bool status { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string deleted_at { get; set; }
        public string next_payment_date { get; set; }
        public int terminal_id { get; set; }
        public int gateway_currency_id { get; set; }
        public int lead_id { get; set; }
        public int commerce_id { get; set; }
        public int form_id { get; set; }
        public GataweyJsonResponse gatawey_json_response { get; set; }
        public bool is_from_webhook { get; set; }
        public int payment_method { get; set; }
        public bool is_manual { get; set; }
        public Metadata metadata { get; set; }
        public bool is_from_wc { get; set; }
        public string wc_request { get; set; }
        public string external_order { get; set; }
        public string ecommerce { get; set; }
        public Lead lead { get; set; }
    }

    public class RespuestaPago
    {
        public string @event { get; set; }
        public Transaction transaction { get; set; }
        public string subscription { get; set; }
    }
}