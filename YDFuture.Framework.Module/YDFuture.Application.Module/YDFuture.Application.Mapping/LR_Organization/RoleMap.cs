using YiDaFuture.Application.Base.OrganizationModule;
using System.Data.Entity.ModelConfiguration;

namespace YiDaFuture.Application.Mapping
{
    /// <summary>
    ///Ver 2018
    /// Copyright (c) 2019 亿达未来科技发展有限公司
    /// 作者:赵金明
    /// 日 期：2017.03.04
    /// 描 述：角色管理
    /// </summary>
    public class RoleMap : EntityTypeConfiguration<RoleEntity>
    {
        public RoleMap()
        {
            #region 表、主键
            //表
            this.ToTable("LR_BASE_ROLE");
            //主键
            this.HasKey(t => t.F_RoleId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
