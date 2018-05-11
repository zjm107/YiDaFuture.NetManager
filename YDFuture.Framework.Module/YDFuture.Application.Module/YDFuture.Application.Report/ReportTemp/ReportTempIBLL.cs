﻿using YiDaFuture.Util;
using System.Collections.Generic;
using System.Data;

namespace YiDaFuture.Application.Report
{
    /// <summary>
    ///Ver 2018
    /// Copyright (c) 2019 亿达未来科技发展有限公司
    /// 创 建：超级管理员
    /// 日 期：2017-07-12 09:57
    /// 描 述：报表管理
    /// </summary>
    public interface ReportTempIBLL
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="keyword">关键词</param>
        /// <returns></returns>
        IEnumerable<ReportTempEntity> GetPageList(Pagination pagination, string keyword);
        /// <summary>
        /// 获得报表数据
        /// </summary>
        /// <param name="dataSourceId">数据库id</param>
        /// <param name="strSql">SQL语句</param>
        /// <returns></returns>
        DataTable GetReportData(string dataSourceId, string strSql);
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        ReportTempEntity GetEntity(string keyValue);
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="keyValue">主键</param>
        void DeleteEntity(string keyValue);
        /// <summary>
        /// 保存（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        void SaveEntity(string keyValue, ReportTempEntity entity);
        #endregion
    }
}
