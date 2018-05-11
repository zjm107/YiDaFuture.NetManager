using YiDaFuture.Application.Base.AuthorizeModule;
using System.Data.Entity.ModelConfiguration;

namespace YiDaFuture.Application.Mapping
{
    /// <summary>
    ///Ver 2018
    /// Copyright (c) 2019 亿达未来科技发展有限公司
    /// 作者:赵金明
    /// 日 期：2017.04.17
    /// 描 述：时段过滤
    /// </summary>
    public class FilterTimeMap : EntityTypeConfiguration<FilterTimeEntity>
    {
        public FilterTimeMap()
        {
            #region 表、主键
            //表
            this.ToTable("LR_BASE_FILTERTIME");
            //主键
            this.HasKey(t => t.F_FilterTimeId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
