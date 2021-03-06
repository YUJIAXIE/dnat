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

namespace Aliyun.Acs.Alidns.Model.V20150109
{
	public class DescribeDomainNsResponse : AcsResponse
	{

		private string requestId;

		private bool? allAliDns;

		private bool? includeAliDns;

		private List<string> dnsServers;

		private List<string> expectDnsServers;

		public string RequestId
		{
			get
			{
				return requestId;
			}
			set	
			{
				requestId = value;
			}
		}

		public bool? AllAliDns
		{
			get
			{
				return allAliDns;
			}
			set	
			{
				allAliDns = value;
			}
		}

		public bool? IncludeAliDns
		{
			get
			{
				return includeAliDns;
			}
			set	
			{
				includeAliDns = value;
			}
		}

		public List<string> DnsServers
		{
			get
			{
				return dnsServers;
			}
			set	
			{
				dnsServers = value;
			}
		}

		public List<string> ExpectDnsServers
		{
			get
			{
				return expectDnsServers;
			}
			set	
			{
				expectDnsServers = value;
			}
		}
	}
}
