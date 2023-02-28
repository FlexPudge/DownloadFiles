using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DownloadFiles.Service
{
    public class GetRequest
    {
        private HttpWebRequest _request;
        private string _address;
        public string Response { get; set; }

        public GetRequest(string address)
        {
            _address = address;
            Run();
        }

        public void Run()
        {
            _request = (HttpWebRequest)WebRequest.Create(_address);
            _request.Method = "GET";
            try
            {
                HttpWebResponse response = (HttpWebResponse)_request.GetResponse();
                var stream = response.GetResponseStream();
                if (stream != null) Response = new StreamReader(stream).ReadToEnd();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message.ToString());
            }
        }
    }
}
