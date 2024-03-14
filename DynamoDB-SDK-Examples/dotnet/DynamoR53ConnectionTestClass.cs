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
        public void GlobalTableQueryTestFunction1()
        {
            try
            {
                AmazonDynamoDBConfig clientConfig = new AmazonDynamoDBConfig();
                // set the endpoint URL
                clientConfig.ServiceURL = "http://samtestddbroutetestone.bsatechnologies.net";

                var client = new AmazonDynamoDBClient(clientConfig);

                var movieTable = Table.LoadTable(client, "SamTest_DDB_Global_MovieTable");


            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

        }

        public async Task GlobalTableQueryTestFunction2Async()
        {
            try
            {
                AmazonDynamoDBConfig clientConfig = new AmazonDynamoDBConfig();
                // set the endpoint URL
                clientConfig.ServiceURL = "http://samtestddbroutetestone.bsatechnologies.net";

                var client = new AmazonDynamoDBClient(clientConfig);

                //var movieTable = Table.LoadTable(client, "SamTest_DDB_Global_MovieTable");


                var request1 = new GetItemRequest
                {
                    TableName = "SamTest_DDB_Global_MovieTable",
                    Key = new Dictionary<string, AttributeValue>
                    {
                        {"MovieId",  new AttributeValue {S = "2"} }
                    }
                };

                var response1 = await client.GetItemAsync(request1);
                Console.WriteLine($"Item retrieved with {response1.Item.Count} attributes.");





                //var request = new QueryRequest
                //{
                //    TableName = "SamTest_DDB_Global_MovieTable",
                //    KeyConditionExpression = "MovieId = :v_Id",
                //    ExpressionAttributeValues = new Dictionary<string, AttributeValue> {
                //    {":v_Id", new AttributeValue { S =  "Amazon DynamoDB#DynamoDB Thread 1" }}}
                //};

                //var response = client.Query(request);






                //foreach (Dictionary<string, AttributeValue> item in response.Items)
                //{
                //    // Process the result.
                //    PrintItem(item);
                //}

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

        }

        public void GlobalTableQueryTestFunction3()
        {
            try
            {
                AmazonDynamoDBConfig clientConfig = new AmazonDynamoDBConfig();
                // set the endpoint URL
                clientConfig.ServiceURL = "http://samtestddbroutetestone.bsatechnologies.net";

                var client = new AmazonDynamoDBClient(clientConfig);

                var movieTable = Table.LoadTable(client, "SamTest_DDB_Global_MovieTable");
                // Scan example.
                FindMovies(movieTable);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

        }

        private void FindMovies(Table movieTable)
        {
            // Assume there is a price error. So we scan to find items priced < 0.
            ScanFilter scanFilter = new ScanFilter();
            scanFilter.AddCondition("MovieId", ScanOperator.LessThan, 3);

            Search search = movieTable.Scan(scanFilter);

            //List<Document> documentList = new List<Document>();
            //do
            //{
            //    documentList = search.GetNextSet();
            //    Console.WriteLine("\nFindProductsWithNegativePrice: printing ............");
            //    foreach (var document in documentList)
            //        PrintDocument(document);
            //} while (!search.IsDone);
        }

        private static void PrintItem(
            Dictionary<string, AttributeValue> attributeList)
        {
            foreach (KeyValuePair<string, AttributeValue> kvp in attributeList)
            {
                string attributeName = kvp.Key;
                AttributeValue value = kvp.Value;

                Console.WriteLine(
                    attributeName + " " +
                    (value.S == null ? "" : "S=[" + value.S + "]") +
                    (value.N == null ? "" : "N=[" + value.N + "]") +
                    (value.SS == null ? "" : "SS=[" + string.Join(",", value.SS.ToArray()) + "]") +
                    (value.NS == null ? "" : "NS=[" + string.Join(",", value.NS.ToArray()) + "]")
                    );
            }
            Console.WriteLine("************************************************");
        }

        //private static void PrintDocument(Document document)
        //{
        //    //   count++;
        //    Console.WriteLine();
        //    foreach (var attribute in document.GetAttributeNames())
        //    {
        //        string stringValue = null;
        //        var value = document[attribute];
        //        if (value is Primitive)
        //            stringValue = value.AsPrimitive().Value.ToString();
        //        else if (value is PrimitiveList)
        //            stringValue = string.Join(",", (from primitive in value.AsPrimitiveList().Entries
        //                                            select primitive.Value).ToArray());
        //        Console.WriteLine("{0} - {1}", attribute, stringValue);
        //    }
        //}


        public async Task DynamoRoute53PutItemTest1()
        {
            try
            {
                AmazonDynamoDBConfig clientConfig = new AmazonDynamoDBConfig();
                // set the endpoint URL
                clientConfig.RegionEndpoint = null;
                clientConfig.ServiceURL = "http://samtestddbroutetestone.bsatechnologies.net";

                //AWSCredentials creds = new AWSCredentials();


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
