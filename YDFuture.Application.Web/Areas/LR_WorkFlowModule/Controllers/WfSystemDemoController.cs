using YiDaFuture.Application.TwoDevelopment.SystemDemo;
using System.Web.Mvc;

namespace YiDaFuture.Application.Web.Areas.LR_WorkFlowModule.Controllers
{
    /// <summary>
    ///Ver 2018
    /// Copyright (c) 2019 亿达未来科技发展有限公司
    /// 作者:赵金明
    /// 日 期：2017.04.17
    /// 描 述：系统表单-请假单
    /// </summary>
    public class WfSystemDemoController : MvcControllerBase
    {
        #region 请假表单
        // 请假表单后台方法
        DemoleaveIBLL demoleaveIBLL = new DemoleaveBLL();

        /// <summary>
        /// 系统请假单(视图)
        /// </summary>
        /// <returns></returns>
        public ActionResult DemoLeaveForm()
        {
            return View();
        }
        /// <summary>
        /// 系统请假单(保存数据)
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ActionResult DemoLeaveSaveForm(string keyValue, DemoleaveEntity entity)
        {
            demoleaveIBLL.SaveEntity(keyValue, entity);
            return Success("保存成功");
        }
        /// <summary>
        /// 系统请假单(获取数据)
        /// </summary>
        /// <param name="processId">流程实例主键</param>
        /// <returns></returns>
        public ActionResult DemoLeaveGetFormData(string processId)
        {
            var data = demoleaveIBLL.GetEntity(processId);
            return Success(data);
        }
        #endregion
    }
}