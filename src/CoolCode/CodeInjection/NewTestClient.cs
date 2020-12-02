using Newtonsoft.Json;
using System;
using System.Linq;
using json = System.Text.Json;

namespace CoolCode.CodeInjection
{
    public class NewTestClient
    {
        #region using JSON.Net to deserialize

        public void TestMethod1()
        {
            NewRestProxy proxy = new NewRestProxy();

            string ret = proxy.GetData<string>("http://localhost/myservice/test", (jsonData) =>
            {
                return JsonConvert.DeserializeObject<string>(jsonData);
            });
        }

        #endregion

        #region returns JSON without deserialization

        public void TestMethod2()
        {
            NewRestProxy proxy = new NewRestProxy();

            string ret = proxy.GetData<string>("http://localhost/myservice/test", (jsonData) =>
            {
                return jsonData;
            });
        }

        #endregion

        #region uses C#-default to deserialize

        public void TestMethod3()
        {
            NewRestProxy proxy = new NewRestProxy();

            string ret = proxy.GetData<string>("http://localhost/myservice/test", (jsonData) =>
            {
                return json.JsonSerializer.Deserialize<string>(jsonData);
            });
        }

        #endregion
    }
}
