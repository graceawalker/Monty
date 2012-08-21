using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using Monty.Repository;

namespace Monty.Tests
{
    public static class Database
    {
        public static void Clear()
        {
            var server = MongoServer.Create();
            var db = server.GetDatabase("montytest");
            db.Drop();
        }
    }
}
