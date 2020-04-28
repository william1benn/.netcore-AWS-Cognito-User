using System;
using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using System.Collections.Generic;
using System.Text;

namespace UserCreate
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {

            using (var client = new AmazonCognitoIdentityProviderClient(awsAccessKeyId: "AccessKey", awsSecretAccessKey: "SecretKey", RegionEndpoint.USEast1))
            {
                var cognitoRequest = new AdminCreateUserRequest
                {
                    Username = "TestUser",
                    UserPoolId = "POOLID",
                    TemporaryPassword = "P@SSW0Rd",
                    ForceAliasCreation = true,
                    UserAttributes = new List<AttributeType>()

                };
                var email = new AttributeType
                {
                    Name = "email",
                    Value = "user@demo.com"
                };
                var CustomAttribute = new AttributeType
                {
                    Name = "custom:ACustomType",
                    Value = "Value"
                };
                var verified = new AttributeType
                {
                    Name = "email_verified",
                    Value = "true"
                };
                cognitoRequest.UserAttributes.Add(CustomAttribute);
                cognitoRequest.UserAttributes.Add(email);
                cognitoRequest.UserAttributes.Add(verified);


                try
                {
                    var response = client.AdminCreateUserAsync(cognitoRequest);
                    var reply = await response; 

                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("error:" + ex.Message);
                }
            }
         
        }
    } 
}
