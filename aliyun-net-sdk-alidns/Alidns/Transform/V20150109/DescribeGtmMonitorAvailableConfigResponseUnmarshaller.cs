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
using System;
using System.Collections.Generic;

using Aliyun.Acs.Core.Transform;
using Aliyun.Acs.Alidns.Model.V20150109;

namespace Aliyun.Acs.Alidns.Transform.V20150109
{
    public class DescribeGtmMonitorAvailableConfigResponseUnmarshaller
    {
        public static DescribeGtmMonitorAvailableConfigResponse Unmarshall(UnmarshallerContext context)
        {
			DescribeGtmMonitorAvailableConfigResponse describeGtmMonitorAvailableConfigResponse = new DescribeGtmMonitorAvailableConfigResponse();

			describeGtmMonitorAvailableConfigResponse.HttpResponse = context.HttpResponse;
			describeGtmMonitorAvailableConfigResponse.RequestId = context.StringValue("DescribeGtmMonitorAvailableConfig.RequestId");

			List<DescribeGtmMonitorAvailableConfigResponse.DescribeGtmMonitorAvailableConfig_IspCityNode> describeGtmMonitorAvailableConfigResponse_ispCityNodes = new List<DescribeGtmMonitorAvailableConfigResponse.DescribeGtmMonitorAvailableConfig_IspCityNode>();
			for (int i = 0; i < context.Length("DescribeGtmMonitorAvailableConfig.IspCityNodes.Length"); i++) {
				DescribeGtmMonitorAvailableConfigResponse.DescribeGtmMonitorAvailableConfig_IspCityNode ispCityNode = new DescribeGtmMonitorAvailableConfigResponse.DescribeGtmMonitorAvailableConfig_IspCityNode();
				ispCityNode.IspName = context.StringValue("DescribeGtmMonitorAvailableConfig.IspCityNodes["+ i +"].IspName");
				ispCityNode.IspCode = context.StringValue("DescribeGtmMonitorAvailableConfig.IspCityNodes["+ i +"].IspCode");
				ispCityNode.CityName = context.StringValue("DescribeGtmMonitorAvailableConfig.IspCityNodes["+ i +"].CityName");
				ispCityNode.CityCode = context.StringValue("DescribeGtmMonitorAvailableConfig.IspCityNodes["+ i +"].CityCode");
				ispCityNode.DefaultSelected = context.BooleanValue("DescribeGtmMonitorAvailableConfig.IspCityNodes["+ i +"].DefaultSelected");
				ispCityNode.Mainland = context.BooleanValue("DescribeGtmMonitorAvailableConfig.IspCityNodes["+ i +"].Mainland");

				describeGtmMonitorAvailableConfigResponse_ispCityNodes.Add(ispCityNode);
			}
			describeGtmMonitorAvailableConfigResponse.IspCityNodes = describeGtmMonitorAvailableConfigResponse_ispCityNodes;
        
			return describeGtmMonitorAvailableConfigResponse;
        }
    }
}
