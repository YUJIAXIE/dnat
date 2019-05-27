using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// ZhimaCreditEpSceneAgreementUseModel Data Structure.
    /// </summary>
    [Serializable]
    public class ZhimaCreditEpSceneAgreementUseModel : AopObject
    {
        /// <summary>
        /// 业务时间，日期格式为 yyyy-MM-dd HH:mm:ss
        /// </summary>
        [XmlElement("biz_time")]
        public string BizTime { get; set; }

        /// <summary>
        /// 商户请求的唯一标志，64位长度的字母数字下划线组合。该标识作为对账的关键信息，商户要保证其唯一性。
        /// </summary>
        [XmlElement("out_order_no")]
        public string OutOrderNo { get; set; }

        /// <summary>
        /// 条款编码
        /// </summary>
        [XmlElement("provision_code")]
        public string ProvisionCode { get; set; }

        /// <summary>
        /// 评估订单号
        /// </summary>
        [XmlElement("rating_order_no")]
        public string RatingOrderNo { get; set; }
    }
}
