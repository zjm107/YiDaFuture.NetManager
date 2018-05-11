using System.Collections.Generic;

namespace YiDaFuture.Application.WorkFlow
{
    /// <summary>
    ///Ver 2018
    /// Copyright (c) 2019 亿达未来科技发展有限公司
    /// 作者:赵金明
    /// 日 期：2017.04.17
    /// 描 述：工作流模板模型
    /// </summary>
    public class WfSchemeModel
    {
        #region 原始属性
        /// <summary>
        /// 节点数据
        /// </summary>
        public List<WfNodeInfo> nodes { get; set; }
        /// <summary>
        /// 线条数据
        /// </summary>
        public List<WfLineInfo> lines { get; set; }
        #endregion
    }
}
