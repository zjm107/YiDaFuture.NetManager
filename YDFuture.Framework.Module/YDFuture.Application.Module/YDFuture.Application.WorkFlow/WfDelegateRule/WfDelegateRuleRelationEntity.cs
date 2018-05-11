using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace YiDaFuture.Application.WorkFlow
{
    /// <summary>
    ///Ver 2018
    /// Copyright (c) 2019 亿达未来科技发展有限公司
    /// 作者:赵金明
    /// 日 期：2017.04.17
    /// 描 述：工作流委托规则与工作流模板关联规则
    /// </summary>
    public class WfDelegateRuleRelationEntity
    {
        #region 实体成员
        /// <summary>
        /// 主键
        /// </summary>
        /// <returns></returns>
        [Column("F_ID")]
        public string F_Id { get; set; }
        /// <summary>
        /// 委托规则主键
        /// </summary>
        /// <returns></returns>
        [Column("F_DELEGATERULEID")]
        public string F_DelegateRuleId { get; set; }
        /// <summary>
        /// 流程模板信息主键
        /// </summary>
        /// <returns></returns>
        [Column("F_SCHEMEINFOID")]
        public string F_SchemeInfoId { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public void Create()
        {
            this.F_Id = Guid.NewGuid().ToString();
        }
        #endregion
    }
}
