﻿using YiDaFuture.Application.Form;
using System.Data.Entity.ModelConfiguration;

namespace YiDaFuture.Application.Mapping
{
    /// <summary>
    ///Ver 2018
    /// Copyright (c) 2019 亿达未来科技发展有限公司
    /// 作者:赵金明
    /// 日 期：2017.04.01
    /// 描 述：表单模板信息
    /// </summary>
    public class FormSchemeInfoMap : EntityTypeConfiguration<FormSchemeInfoEntity>
    {
        public FormSchemeInfoMap()
        {
            #region 表、主键
            //表
            this.ToTable("LR_FORM_SCHEMEINFO");
            //主键
            this.HasKey(t => t.F_Id);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
