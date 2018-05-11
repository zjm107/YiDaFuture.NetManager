using YiDaFuture.Util;
using System;
namespace YiDaFuture.Application.TwoDevelopment.SystemDemo
{
    /// <summary>
    ///Ver 2018
    /// Copyright (c) 2019 亿达未来科技发展有限公司
    /// 作者:赵金明
    /// 日 期：2017.04.17
    /// 描 述：系统表单-请假单
    /// </summary>
    public class DemoleaveBLL : DemoleaveIBLL
    {
        private DemoleaveService demoleaveService = new DemoleaveService();

        #region 获取数据
        /// <summary>
        /// 根据流程实例获取表单数据
        /// </summary>
        /// <param name="processId"></param>
        /// <returns></returns>
        public DemoleaveEntity GetEntity(string processId)
        {
            try
            {
                return demoleaveService.GetEntity(processId);
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

        #region 提交数据
        /// <summary>
        /// 保存更新数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体对象</param>
        public void SaveEntity(string keyValue, DemoleaveEntity entity)
        {
            try
            {
                demoleaveService.SaveEntity(keyValue, entity);
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
