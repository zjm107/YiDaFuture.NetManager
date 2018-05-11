﻿using YiDaFuture.Util;
using System;
using System.Collections.Generic;

namespace YiDaFuture.Application.CRM
{
    /// <summary>
    ///Ver 2018
    /// Copyright (c) 2019 亿达未来科技发展有限公司
    /// 创 建：超级管理员
    /// 日 期：2017-07-11 14:20
    /// 描 述：现金余额
    /// </summary>
    public class CrmCashBalanceBLL : CrmCashBalanceIBLL
    {
        CrmCashBalanceService crmCashBalanceService = new CrmCashBalanceService();

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<CrmCashBalanceEntity> GetList(string queryJson)
        {
            try
            {
                return crmCashBalanceService.GetList(queryJson);
            }
            catch (Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowBusinessException(ex);
                }
            }
        }
        #endregion
    }
}
