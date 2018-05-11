using YiDaFuture.DataBase.Repository;
using YiDaFuture.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace YiDaFuture.Application.Base.OrganizationModule
{
    /// <summary>
    ///Ver 2018
    /// Copyright (c) 2019 亿达未来科技发展有限公司
    /// 作者:赵金明
    /// 日 期：2017.03.04
    /// 描 述：角色管理
    /// </summary>
    public class RoleService : RepositoryFactory
    {
        #region 构造函数和属性
        private string fieldSql;
        public RoleService()
        {
            fieldSql = @"
                    t.F_RoleId,
                    t.F_Category,
                    t.F_EnCode,
                    t.F_FullName,
                    t.F_SortCode,
                    t.F_DeleteMark,
                    t.F_EnabledMark,
                    t.F_Description,
                    t.F_CreateDate,
                    t.F_CreateUserId,
                    t.F_CreateUserName,
                    t.F_ModifyDate,
                    t.F_ModifyUserId,
                    t.F_ModifyUserName
                    ";
        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 获取角色数据列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetList()
        {
            try
            {
                var strSql = new StringBuilder();
                strSql.Append("SELECT ");
                strSql.Append(fieldSql);
                strSql.Append(" FROM LR_Base_Role t WHERE t.F_EnabledMark = 1 AND t.F_DeleteMark = 0 ORDER BY t.F_FullName ");
                return this.BaseRepository().FindList<RoleEntity>(strSql.ToString());
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }
        /// <summary>
        /// 获取角色数据列表
        /// </summary>
        /// <param name="roleIds">主键串</param>
        /// <returns></returns>
        public IEnumerable<RoleEntity> GetListByRoleIds(string roleIds)
        {
            try
            {
                return this.BaseRepository().FindList<RoleEntity>(t => roleIds.Contains(t.F_RoleId));
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 虚拟删除角色
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void VirtualDelete(string keyValue)
        {
            try
            {
                RoleEntity entity = new RoleEntity()
                {
                    F_RoleId = keyValue,
                    F_DeleteMark = 1
                };
                this.BaseRepository().Update(entity);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
        }
        /// <summary>
        /// 保存角色（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="roleEntity">角色实体</param>
        /// <returns></returns>
        public void SaveEntity(string keyValue, RoleEntity roleEntity)
        {
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    roleEntity.Modify(keyValue);
                    this.BaseRepository().Update(roleEntity);
                }
                else
                {
                    roleEntity.Create();
                    this.BaseRepository().Insert(roleEntity);
                }
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }

        } 
        #endregion
    }
}
