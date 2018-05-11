
namespace YiDaFuture.Application.WorkFlow
{
    /// <summary>
    ///Ver 2018
    /// Copyright (c) 2019 亿达未来科技发展有限公司
    /// 作者:赵金明
    /// 日 期：2017.04.17
    /// 描 述：工作流引擎节点触发方法
    /// </summary>
    public class NodeMethod : INodeMethod
    {
        /// <summary>
        /// 节点审核通过执行方法
        /// </summary>
        /// <param name="processId">流程实例主键</param>
        public void Sucess(string processId)
        {

        }
        /// <summary>
        /// 节点审核失败执行方法
        /// </summary>
        /// <param name="processId">流程实例主键</param>
        public void Fail(string processId)
        {

        }
    }
}
