using MongoDB.Driver;
using NetCoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NetCoreAPI.Controllers
{
    [Route("api/[controller]")]
    public class MongoController : ApiController
    {
        HttpResponseMessage responseMesg = new HttpResponseMessage();

       
        public IEnumerable<Student> GetStudents()
        {
            MongoHelper.ConnectToMongoService();
            MongoHelper.student_collection =
                MongoHelper.database.GetCollection<Student>("studentBorwell");

            var filter = Builders<Student>.Filter.Ne("_Id", "");
            //var result = MongoHelper.student_collection.Find(filter).ToList();
            var result = MongoHelper.student_collection.Find(filter).ToList();

            return result;
        }

        [HttpPost]
        public HttpResponseMessage Create([FromBody]Student studentCreate)
        {
            MongoHelper.ConnectToMongoService();
            MongoHelper.student_collection =
            MongoHelper.database.GetCollection<Student>("students");

            Object id = GenerateRandomId(24);

            MongoHelper.student_collection.InsertOneAsync(new Student
            {
                _Id = id,
                firstName = studentCreate.firstName,
                lastName = studentCreate.lastName,
                emailAddress = studentCreate.emailAddress

            });

            // Validate and add book to database (not shown)
            HttpRequestMessage request = new HttpRequestMessage();
            var response = request.CreateResponse(HttpStatusCode.Created);
            return response;
        }

        private static Random random = new Random();
        private object GenerateRandomId(int v)
        {
            string strarray = "abcdefghijklmnopqrstuvwxyz1234567890";
            return new string(Enumerable.Repeat(strarray, v).Select(s => s[random.Next(s.Length)]).ToArray());
            //throw new NotImplementedException();
        }
    }
}