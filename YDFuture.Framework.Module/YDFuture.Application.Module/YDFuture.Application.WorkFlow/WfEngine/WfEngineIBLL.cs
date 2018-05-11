﻿
using YiDaFuture.Util;
using System.Collections.Generic;
namespace YiDaFuture.Application.WorkFlow
{
    /// <summary>
    ///Ver 2018
    /// Copyright (c) 2019 亿达未来科技发展有限公司
    /// 作者:赵金明
    /// 日 期：2017.04.17
    /// 描 述：工作流引擎接口
    /// </summary>
    public interface WfEngineIBLL
    {
         /// <summary>
        /// 流程发起初始化接口
        /// </summary>
        /// <param name="parameter">流程参数</param>
        /// <returns></returns>
        WfResult<WfContent> Bootstraper(WfParameter parameter);
        /// <summary>
        /// 获取某个任务节点的信息
        /// </summary>
        /// <param name="parameter">流程参数</param>
        /// <returns></returns>
        WfResult<WfContent> GetTaskInfo(WfParameter parameter);
        /// <summary>
        /// 获取流程实例信息
        /// </summary>
        /// <param name="parameter">流程参数</param>
        /// <returns></returns>
        WfResult<WfContent> GetProcessInfo(WfParameter parameter);
        /// <summary>
        /// 创建流程实例
        /// </summary>
        /// <param name="parameter">流程参数</param>
        /// <returns></returns>
        WfResult Create(WfParameter parameter);
        /// <summary>
        /// 审核流程节点
        /// </summary>
        /// <param name="parameter">流程参数</param>
        /// <returns></returns>
        WfResult Audit(WfParameter parameter);
    }
}
