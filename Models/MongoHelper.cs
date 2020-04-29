using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetCoreAPI.Models
{
    public class MongoHelper
    {
        public static IMongoClient client { get; set; }
        public static IMongoDatabase database { get; set; }
        public static string MongoConnection = "mongodb+srv://karaz:Welcome1@karazcluster-uj07z.mongodb.net/test?retryWrites=true&w=majority";
        public static string MongoDatabase = "Borewell";

        public static IMongoCollection<Student> student_collection { get; set; }

        internal static void ConnectToMongoService()
        {
            try
            {
                client = new MongoClient(MongoConnection);
                database = client.GetDatabase(MongoDatabase);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}