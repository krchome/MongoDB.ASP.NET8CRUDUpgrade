﻿
using MongoDB.Driver;
using System.Reflection;
using MongoDb.ASP.NETCore3CRUDSample;
using MongoDb.ASP.NETCore3CRUDSample.DataAccess.Models;
using Microsoft.Extensions.Options;

namespace MongoDb.ASP.NETCore3CRUDSample.DataAccess
{
    public class CustomerContext : ICustomerContext
    {
        public readonly IMongoDatabase mongoDatabase;

        public CustomerContext(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            mongoDatabase = client.GetDatabase(options.Value.Database);
        }
        public IMongoCollection<Customer> Customers => mongoDatabase.GetCollection<Customer>("Customers");
       
    }

    public interface ICustomerContext
    {
        IMongoCollection<Customer> Customers { get; }
    }
}
