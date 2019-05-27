using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// MEquityUseRule Data Structure.
    /// </summary>
    [Serializable]
    public class MEquityUseRule : AopObject
    {
        /// <summary>
        /// 权益不可用时段信息，不可用时间段只支持周期维度DAY类型，举例：指定日期2018-12-12至2018-12-22时间段不可用，数据结构为：{"timeDimensionType":"DAY","times":"2018-12-12,2018-12-22"}，目前列表数据最多支持5组
        /// </summary>
        [XmlArray("disabled_times")]
        [XmlArrayItem("m_time_control_info")]
        public List<MTimeControlInfo> DisabledTimes { get; set; }

        /// <summary>
        /// 使用权益最低消费金额(单位:分)，最低消费金额范围1~499999的整数
        /// </summary>
        [XmlElement("min_cost_amount")]
        public string MinCostAmount { get; set; }

        /// <summary>
        /// 权益适用的商品
        /// </summary>
        [XmlArray("suit_item_list")]
        [XmlArrayItem("m_item_info")]
        public List<MItemInfo> SuitItemList { get; set; }

        /// <summary>
        /// 权益可用时段信息，可用时间段只支持周期维度WEEK类型，举例：  每周一、周二、周日的06:00:00~07:04:59时间段可用，数据结构为：{"timeDimensionType":"WEEK","times":"06:00:00,07:04:59","values":"1,2,7"}，目前支持最多设置5组时间
        /// </summary>
        [XmlArray("usaged_times")]
        [XmlArrayItem("m_time_control_info")]
        public List<MTimeControlInfo> UsagedTimes { get; set; }
    }
}
