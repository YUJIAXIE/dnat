using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AntMerchantExpandItemModifyModel Data Structure.
    /// </summary>
    [Serializable]
    public class AntMerchantExpandItemModifyModel : AopObject
    {
        /// <summary>
        /// 商品扩展信息：可以解析成 Map<String, String> 的 json string
        /// </summary>
        [XmlElement("ext_info")]
        public string ExtInfo { get; set; }

        /// <summary>
        /// 前台类目id, null表示未分类
        /// </summary>
        [XmlElement("front_category_id")]
        public string FrontCategoryId { get; set; }

        /// <summary>
        /// 商品id
        /// </summary>
        [XmlElement("item_id")]
        public string ItemId { get; set; }

        /// <summary>
        /// 商品标签列表，null表示不修改标签列表，空list表示清空标签
        /// </summary>
        [XmlArray("label_list")]
        [XmlArrayItem("item_label_modify_info")]
        public List<ItemLabelModifyInfo> LabelList { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// 场景：GAS_CHARGE（加油）
        /// </summary>
        [XmlElement("scene")]
        public string Scene { get; set; }

        /// <summary>
        /// 商品sku列表，至少有一个
        /// </summary>
        [XmlArray("sku_list")]
        [XmlArrayItem("item_sku_modify_info")]
        public List<ItemSkuModifyInfo> SkuList { get; set; }
    }
}
