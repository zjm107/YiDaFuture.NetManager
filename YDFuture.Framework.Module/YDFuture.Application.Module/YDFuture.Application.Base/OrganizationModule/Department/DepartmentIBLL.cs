﻿using YiDaFuture.Util;
using System.Collections.Generic;

namespace YiDaFuture.Application.Base.OrganizationModule
{
    /// <summary>
    ///Ver 2018
    /// Copyright (c) 2019 亿达未来科技发展有限公司
    /// 作者:赵金明
    /// 日 期：2017.04.17
    /// 描 述：部门管理
    /// </summary>
    public interface DepartmentIBLL
    {
        #region 获取数据
        /// <summary>
        /// 获取部门列表信息(根据公司Id)
        /// </summary>
        /// <param name="companyId">公司Id</param>
        /// <returns></returns>
        List<DepartmentEntity> GetList(string companyId);
        /// <summary>
        /// 获取部门列表信息(根据公司Id)
        /// </summary>
        /// <param name="companyId">公司Id</param>
        /// <param name="keyWord">查询关键字</param>
        /// <returns></returns>
        List<DepartmentEntity> GetList(string companyId, string keyWord);
        /// <summary>
        /// 获取部门数据实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        DepartmentEntity GetEntity(string keyValue);
        /// <summary>
        /// 获取部门数据实体
        /// </summary>
        /// <param name="companyId">公司主键</param>
        /// <param name="departmentId">部门主键</param>
        /// <returns></returns>
        DepartmentEntity GetEntity(string companyId, string departmentId);
        /// <summary>
        /// 获取树形数据
        /// </summary>
        /// <param name="companyId">公司id</param>
        /// <param name="parentId">父级id</param>
        /// <returns></returns>
        List<TreeModel> GetTree(string companyId, string parentId);
        /// <summary>
        /// 获取树形数据
        /// </summary>
        /// <param name="companyId">公司id</param>
        /// <param name="parentId">父级id</param>
        /// <returns></returns>
        List<TreeModel> GetTree(List<CompanyEntity> companylist);
        #endregion

        #region 提交数据
        /// <summary>
        /// 虚拟删除部门信息
        /// </summary>
        /// <param name="keyValue">主键</param>
        void VirtualDelete(string keyValue);
        /// <summary>
        /// 保存部门信息（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="departmentEntity">部门实体</param>
        /// <returns></returns>
        void SaveEntity(string keyValue, DepartmentEntity departmentEntity);
        #endregion
    }
}
