﻿using YiDaFuture.Application.OA;
using YiDaFuture.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YiDaFuture.Application.Web.Areas.LR_OAModule.Controllers
{
    /// <summary>
    ///Ver 2018
    /// Copyright (c) 2019 亿达未来科技发展有限公司
    /// 作者:赵金明
    /// 日 期：2017.04.01
    /// 描 述：公告管理
    /// </summary>
    public class NoticeController : MvcControllerBase
    {
        private NoticeIBLL noticeIBLL = new NoticeBLL();

        #region 视图功能
        /// <summary>
        /// 管理页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="keyword">关键词</param>
        /// <returns></returns>
        public ActionResult GetPageList(string pagination,string keyword)
        {
            Pagination paginationobj = pagination.ToObject<Pagination>();
            var data = noticeIBLL.GetPageList(paginationobj, keyword);
            var jsonData = new
            {
                rows = data,
                total = paginationobj.total,
                page = paginationobj.page,
                records = paginationobj.records,
            };
            return Success(jsonData);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public ActionResult GetEntity(string keyValue)
        {
            var data = noticeIBLL.GetEntity(keyValue);
            data.F_NewsContent = WebHelper.HtmlDecode(data.F_NewsContent);
            return Success(data);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 保存表单数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken, AjaxOnly, ValidateInput(false)]
        public ActionResult SaveForm(string keyValue, NewsEntity entity)
        {
            entity.F_NewsContent = WebHelper.HtmlEncode(entity.F_NewsContent);
            noticeIBLL.SaveEntity(keyValue, entity);
            return Success("保存成功！");
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
            noticeIBLL.DeleteEntity(keyValue);
            return Success("删除成功！");
        }
        #endregion
    }
}