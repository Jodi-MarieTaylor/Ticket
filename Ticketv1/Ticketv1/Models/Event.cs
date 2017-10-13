using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Npgsql;

namespace Ticketv1.Models
{
    [Table("events", Schema = "public")]
    public class Event
    {
      
        [Key]
        public int id { get; set; }
        public int user_id { get; set; }
        public int company_id { get; set; }
        public int attachment_id { get; set; }
        public string name { get; set; }
        public string summary { get; set; }
        public string location { get; set; }
        public string category { get; set; }
        public int account_id { get; set; }
        public int event_limit { get; set; }
        public string meta1 { get; set; }
        public string meta2 { get; set; }
        public string zid { get; set; }
        public DateTime event_date { get; set; }
        public DateTime end_date { get; set; }
        public DateTime inserted_at { get; set; }
        public DateTime updated_at { get; set; }


        public int SaveDetails()
        {
            

            var conn = new NpgsqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            //cmd.CommandText = "INSERT INTO events(user_id, name, summary, location, category, event_limit, event_date, end_date,  zid, inserted_at, updated_at) values ('" + 1 + "','" + name + "','" + summary + "','" + location + "','" + category + "','" + event_limit + "','" + event_date + "','" + end_date + "','"   + zid + "','" + inserted_at + "','" + updated_at + "')";
            cmd.ExecuteNonQuery();
            conn.Close();
            return 1;
        }
    }
}

