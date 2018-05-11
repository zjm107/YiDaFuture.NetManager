using YiDaFuture.Application.WorkFlow;
using System.Data.Entity.ModelConfiguration;

namespace YiDaFuture.Application.Mapping
{
    /// <summary>
    ///Ver 2018
    /// Copyright (c) 2019 亿达未来科技发展有限公司
    /// 作者:赵金明
    /// 日 期：2017.04.17
    /// 描 述：任务实例
    /// </summary>
    public class WfTaskMap : EntityTypeConfiguration<WfTaskEntity>
    {
        public WfTaskMap()
        {
            #region 表、主键
            //表
            this.ToTable("LR_WORKFLOW_TASK");
            //主键
            this.HasKey(t => t.F_Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
