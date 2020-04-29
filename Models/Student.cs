using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetCoreAPI.Models
{
    [BsonIgnoreExtraElements]
    public class Student
    {
        public object _Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string emailAddress { get; set; }
    }
}