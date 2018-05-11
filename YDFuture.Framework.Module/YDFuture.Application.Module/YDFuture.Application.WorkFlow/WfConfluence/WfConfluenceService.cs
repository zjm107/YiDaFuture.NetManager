﻿using YiDaFuture.DataBase.Repository;
using YiDaFuture.Util;
using System;
using System.Collections.Generic;

namespace YiDaFuture.Application.WorkFlow
{
    /// <summary>
    ///Ver 2018
    /// Copyright (c) 2019 亿达未来科技发展有限公司
    /// 作者:赵金明
    /// 日 期：2017.04.17
    /// 描 述：会签记录操作
    /// </summary>
    public class WfConfluenceService : RepositoryFactory
    {
        #region 获取数据
        /// <summary>
        /// 获取会签记录
        /// </summary>
        /// <param name="processId">流程实例主键</param>
        /// <param name="nodeId">节点主键</param>
        /// <returns></returns>
        public IEnumerable<WfConfluenceEntity> GetList(string processId, string nodeId)
        {
            try
            {
                return  this.BaseRepository().FindList<WfConfluenceEntity>(t => t.F_ProcessId == processId && t.F_NodeId == nodeId);
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
        /// 保存成功的会前记录
        /// </summary>
        /// <param name="entity">实体</param>
        public void SaveEntity(WfConfluenceEntity entity)
        {
            try
            {
                string processId = entity.F_ProcessId;
                string nodeId = entity.F_NodeId;
                string formNodeId = entity.F_FormNodeId;
                WfConfluenceEntity oldEntity = this.BaseRepository().FindEntity<WfConfluenceEntity>(t => t.F_ProcessId == processId && t.F_NodeId == nodeId && t.F_FormNodeId == formNodeId);
                if (oldEntity == null)
                {
                    entity.Create();
                    this.BaseRepository().Insert(entity);
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
        /// <summary>
        /// 删除会签节点数据
        /// </summary>
        /// <param name="processId">实例主键</param>
        /// <param name="nodeId">节点主键</param>
        public void DeleteEntity(string processId, string nodeId)
        {
            try
            {
                this.BaseRepository().Delete<WfConfluenceEntity>(t => t.F_ProcessId == processId && t.F_NodeId == nodeId);
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
