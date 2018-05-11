using YiDaFuture.Application.Report;
using System.Data.Entity.ModelConfiguration;

namespace YiDaFuture.Application.Mapping
{
    /// <summary>
    ///Ver 2018
    /// Copyright (c) 2019 亿达未来科技发展有限公司
    /// 创 建：超级管理员
    /// 日 期：2017-07-12 09:57
    /// 描 述：报表管理
    /// </summary>
    public class ReportTempMap : EntityTypeConfiguration<ReportTempEntity>
    {
        public ReportTempMap()
        {
            #region 表、主键
            //表
            this.ToTable("LR_REPORTTEMP");
            //主键
            this.HasKey(t => t.F_TempId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
