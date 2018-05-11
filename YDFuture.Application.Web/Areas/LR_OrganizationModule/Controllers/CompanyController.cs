using YiDaFuture.Application.Base.OrganizationModule;
using YiDaFuture.Util;
using YiDaFuture.Util.Operat;
using System.Web.Mvc;

namespace YiDaFuture.Application.Web.Areas.LR_OrganizationModule.Controllers
{
    /// <summary>
    ///Ver 2018
    /// Copyright (c) 2019 亿达未来科技发展有限公司
    /// 作者:赵金明
    /// 日 期：2017.03.09
    /// 描 述：公司管理
    /// </summary>
    public class CompanyController : MvcControllerBase
    {
        private CompanyIBLL companyIBLL = new CompanyBLL();

        #region 获取视图
        /// <summary>
        /// 主页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 表单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Form() {
            return View();
        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 获取公司列表信息
        /// </summary>
        /// <param name="keyword">查询关键字</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetList(string keyword) {
            var data = companyIBLL.GetList(keyword);
            return Success(data);
        }
        /// <summary>
        /// 获取树形数据
        /// </summary>
        /// <param name="parentId">父级id</param>
        /// <returns></returns>
        [HttpGet]
        [AjaxOnly]
        public ActionResult GetTree(string parentId)
        {
            var data = companyIBLL.GetTree(parentId);
            return Success(data);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 保存表单数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体数据</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, CompanyEntity entity)
        {
            companyIBLL.SaveEntity(keyValue, entity);
            return Success("保存成功！", "公司信息", string.IsNullOrEmpty(keyValue) ? OperationType.Create : OperationType.Update, entity.F_CompanyId, entity.ToJson());
        }
        /// <summary>
        /// 删除表单数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult DeleteForm(string keyValue)
        {
            companyIBLL.VirtualDelete(keyValue);
            return Success("删除成功！", "公司信息", OperationType.Delete, keyValue, "");
        }
        #endregion
    }
}