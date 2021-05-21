using System;
using System.Threading.Tasks;
using GraphQL.SystemTextJson;
using GraphQL.Types;

namespace Infraestructure.GraphQL
{
    public class GraphQLServer
    {
        public static async Task Run(string[] args)
        {
                var schema = Schema.For(@"
                type Query {
                    hello: String
                }
                ");
        
                var json = await schema.ExecuteAsync(_ =>
                {
                _.Query = "{ hello }";
                _.Root = new { Hello = "Hello World!" };
                });
            
                Console.WriteLine(json);
        }
    }
}