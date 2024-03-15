using System;
using System.Collections.Generic;
using System.Text;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime;

namespace DotnetSamples
{
    public class DynamoR53ConnectionTestClass
    {
        public async Task DynamoRoute53PutItemTest1()
        {
            try
            {
                AmazonDynamoDBConfig clientConfig = new AmazonDynamoDBConfig();
                // set the endpoint URL
                clientConfig.RegionEndpoint = RegionEndpoint.USEast1;

                var client = new AmazonDynamoDBClient(clientConfig);

                // Define item attributes
                Dictionary<string, AttributeValue> attributes = new Dictionary<string, AttributeValue>();

                // MovieId
                attributes["MovieID"] = new AttributeValue { N = "8" };
                // Director is string
                attributes["Director"] = new AttributeValue { S = "Shyam Test 8" };
                // Movie Name is string
                attributes["Name"] = new AttributeValue { S = "SamTestMovieName 8" };

                // Create PutItem request
                PutItemRequest request = new PutItemRequest
                {
                    TableName = "SamTest_DDB_Global_MovieTable",
                    Item = attributes
                };

                // Issue PutItem request
                var response = await client.PutItemAsync(request);
                Console.WriteLine($"PutItem succeeded.");
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                throw;
            }
        }


    }
}
