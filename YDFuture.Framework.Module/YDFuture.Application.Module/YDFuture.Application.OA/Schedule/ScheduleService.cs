using YiDaFuture.DataBase.Repository;
using YiDaFuture.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace YiDaFuture.Application.OA.Schedule
{
    /// <summary>
    ///Ver 2018
    /// Copyright (c) 2019 亿达未来科技发展有限公司
    /// 作者:赵金明
    /// 日 期：2017.07.11
    /// 描 述：日程管理
    /// </summary>
    public class ScheduleService : RepositoryFactory
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns>返回列表</returns>
        public IEnumerable<ScheduleEntity> GetList()
        {
            try
            {
                return this.BaseRepository().FindList<ScheduleEntity>();
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                    throw;
                else
                    throw ExceptionEx.ThrowServiceException(ex);
            }
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public ScheduleEntity GetEntity(string keyValue)
        {
            try
            {
                return this.BaseRepository().FindEntity<ScheduleEntity>(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                    throw;
                else
                    throw ExceptionEx.ThrowServiceException(ex);
            }
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            try
            {
                this.BaseRepository().Delete(keyValue);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                    throw;
                else
                    throw ExceptionEx.ThrowServiceException(ex);
            }
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, ScheduleEntity entity)
        {
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    entity.Modify(keyValue);
                    this.BaseRepository().Update(entity);
                }
                else
                {
                    entity.Create();
                    this.BaseRepository().Insert(entity);
                }
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                    throw;
                else
                    throw ExceptionEx.ThrowServiceException(ex);
            }
        }
        #endregion
    }
}
