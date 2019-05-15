using Aliyun.Acs.Alidns.Model.V20150109;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class DoMain
    {

        public string Add(string RR)
        {
            DLL.BLL.ConfigBLL cb = new DLL.BLL.ConfigBLL();
            var config = cb.SelectConfig();

            //var accessKeyId;"Info = 'AccessKeyID'"
            DataRow[] dr = config.Select();
            var result = string.Empty;
            IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", dr[0]["Value"].ToString(), dr[1]["Value"].ToString());
            DefaultAcsClient client = new DefaultAcsClient(profile);
            var request = new AddDomainRecordRequest();
            request._Value = dr[3]["Value"].ToString();
            request.Type = "a";
            request.RR = RR;
            request.DomainName = dr[2]["Value"].ToString();
            try
            {
                var response = client.GetAcsResponse(request);
                result = System.Text.Encoding.Default.GetString(response.HttpResponse.Content);
            }
            catch (ServerException e)
            {
                result = e.ToString();
            }
            catch (ClientException e)
            {
                result = e.ToString();
            }
            return result;
        }


    }
}