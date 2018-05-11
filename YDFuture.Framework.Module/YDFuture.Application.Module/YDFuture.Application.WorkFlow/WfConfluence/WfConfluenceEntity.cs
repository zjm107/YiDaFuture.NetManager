using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace YiDaFuture.Application.WorkFlow
{
    /// <summary>
    ///Ver 2018
    /// Copyright (c) 2019 亿达未来科技发展有限公司
    /// 作者:赵金明
    /// 日 期：2017.04.17
    /// 描 述：会签记录操作(保存同意的操作)
    /// </summary>
    public class WfConfluenceEntity
    {
        #region 字段属性
        /// <summary>
        /// 主键
        /// </summary>
        [Column("F_ID")]
        public string F_Id { get; set; }
        /// <summary>
        /// 流程实例
        /// </summary>
        [Column("F_PROCESSID")]
        public string F_ProcessId { get; set; }
        /// <summary>
        /// 节点主键
        /// </summary>
         [Column("F_NODEID")]
        public string F_NodeId { get; set; }
        /// <summary>
        /// 上一节点主键
        /// </summary>
        [Column("F_FORMNODEID")]
        public string F_FormNodeId { get; set; }
        /// <summary>
        /// 1 是 0 否
        /// </summary>
        [Column("F_ISOK")]
        public int F_IsOk { get; set; }
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
