using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpSelFrameworl.Utilities
{
    internal class JasonRedear
    {
        public String extractData(String tokenName)
        {
            String myJasonString = File.ReadAllText("Utilities//testData.Jason");
            var jsonObject = JToken.Parse(myJasonString);
            return jsonObject.SelectToken(tokenName).Value<string>();

        }

        public string[] extractDataArray(String tokenName)
        {
            String myJasonString = File.ReadAllText("Utilities//testData.Jason");
            var jsonObject = JToken.Parse(myJasonString);
           List<String> products = jsonObject.SelectTokens(tokenName).Values<string>().ToList();
            return products.ToArray();

        }
    }
}
