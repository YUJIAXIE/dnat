/*
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements.  See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership.  The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License.  You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */
using System.Collections.Generic;

using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Http;
using Aliyun.Acs.Core.Transform;
using Aliyun.Acs.Core.Utils;
using Aliyun.Acs.Alidns.Transform;
using Aliyun.Acs.Alidns.Transform.V20150109;

namespace Aliyun.Acs.Alidns.Model.V20150109
{
    public class AddDomainRecordRequest : RpcAcsRequest<AddDomainRecordResponse>
    {
        public AddDomainRecordRequest()
            : base("Alidns", "2015-01-09", "AddDomainRecord", "alidns", "openAPI")
        {
        }

		private string rR;

		private string line;

		private string userClientIp;

		private string domainName;

		private string lang;

		private string type;

		private long? priority;

		private string _value;

		private long? tTL;

		private string accessKeyId;

		public string RR
		{
			get
			{
				return rR;
			}
			set	
			{
				rR = value;
				DictionaryUtil.Add(QueryParameters, "RR", value);
			}
		}

		public string Line
		{
			get
			{
				return line;
			}
			set	
			{
				line = value;
				DictionaryUtil.Add(QueryParameters, "Line", value);
			}
		}

		public string UserClientIp
		{
			get
			{
				return userClientIp;
			}
			set	
			{
				userClientIp = value;
				DictionaryUtil.Add(QueryParameters, "UserClientIp", value);
			}
		}

		public string DomainName
		{
			get
			{
				return domainName;
			}
			set	
			{
				domainName = value;
				DictionaryUtil.Add(QueryParameters, "DomainName", value);
			}
		}

		public string Lang
		{
			get
			{
				return lang;
			}
			set	
			{
				lang = value;
				DictionaryUtil.Add(QueryParameters, "Lang", value);
			}
		}

		public string Type
		{
			get
			{
				return type;
			}
			set	
			{
				type = value;
				DictionaryUtil.Add(QueryParameters, "Type", value);
			}
		}

		public long? Priority
		{
			get
			{
				return priority;
			}
			set	
			{
				priority = value;
				DictionaryUtil.Add(QueryParameters, "Priority", value.ToString());
			}
		}

		public string _Value
		{
			get
			{
				return _value;
			}
			set	
			{
				_value = value;
				DictionaryUtil.Add(QueryParameters, "Value", value);
			}
		}

		public long? TTL
		{
			get
			{
				return tTL;
			}
			set	
			{
				tTL = value;
				DictionaryUtil.Add(QueryParameters, "TTL", value.ToString());
			}
		}

		public string AccessKeyId
		{
			get
			{
				return accessKeyId;
			}
			set	
			{
				accessKeyId = value;
				DictionaryUtil.Add(QueryParameters, "AccessKeyId", value);
			}
		}

        public override AddDomainRecordResponse GetResponse(UnmarshallerContext unmarshallerContext)
        {
            return AddDomainRecordResponseUnmarshaller.Unmarshall(unmarshallerContext);
        }
    }
}
