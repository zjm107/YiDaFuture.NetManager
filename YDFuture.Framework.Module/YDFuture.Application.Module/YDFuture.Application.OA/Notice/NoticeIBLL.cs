﻿using YiDaFuture.Util;
using System.Collections.Generic;

namespace YiDaFuture.Application.OA
{
    /// <summary>
    ///Ver 2018
    /// Copyright (c) 2019 亿达未来科技发展有限公司
    /// 作者:赵金明
    /// 日 期：2017.04.17
    /// 描 述：公告管理
    /// </summary>
    public interface NoticeIBLL
    {
        #region 获取数据
        /// <summary>
        /// 公告列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="keyword">关键词</param>
        /// <returns></returns>
        IEnumerable<NewsEntity> GetPageList(Pagination pagination, string keyword);
        /// <summary>
        /// 公告实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        NewsEntity GetEntity(string keyValue);
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
        /// <param name="newsEntity">公告实体</param>
        /// <returns></returns>
        void SaveEntity(string keyValue, NewsEntity newsEntity);
        #endregion
    }
}
