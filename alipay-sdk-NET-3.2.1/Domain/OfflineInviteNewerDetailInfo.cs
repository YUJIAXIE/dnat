using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// OfflineInviteNewerDetailInfo Data Structure.
    /// </summary>
    [Serializable]
    public class OfflineInviteNewerDetailInfo : AopObject
    {
        /// <summary>
        /// 被邀请手机号
        /// </summary>
        [XmlElement("invited_phone")]
        public string InvitedPhone { get; set; }

        /// <summary>
        /// 二级渠道
        /// </summary>
        [XmlElement("partner_id")]
        public string PartnerId { get; set; }

        /// <summary>
        /// 一级渠道
        /// </summary>
        [XmlElement("pid")]
        public string Pid { get; set; }

        /// <summary>
        /// 是否可结算核销用户
        /// </summary>
        [XmlElement("settled")]
        public bool Settled { get; set; }

        /// <summary>
        /// 是否可结算的绑卡用户
        /// </summary>
        [XmlElement("settled_and_bind")]
        public bool SettledAndBind { get; set; }

        /// <summary>
        /// 绑卡时间
        /// </summary>
        [XmlElement("user_bind_card_time")]
        public string UserBindCardTime { get; set; }

        /// <summary>
        /// 用户实名时间
        /// </summary>
        [XmlElement("user_cert_time")]
        public string UserCertTime { get; set; }

        /// <summary>
        /// 用户领奖时间
        /// </summary>
        [XmlElement("user_prize_time")]
        public string UserPrizeTime { get; set; }
    }
}
