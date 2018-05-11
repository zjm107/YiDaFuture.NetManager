using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Threading.Tasks;

namespace YiDaFuture.Application.IM.Hubs
{
    /// <summary>
    ///Ver 2018
    /// Copyright (c) 2019 亿达未来科技发展有限公司
    /// 作者:赵金明
    /// 日 期：2017.04.01
    /// 描 述：即使通信服务(可供客户端调用的方法开头用小写)
    /// </summary>
    [HubName("ChatsHub")]
    public class Chats : Hub
    {
        #region 重载Hub方法
        /// <summary>
        /// 建立连接
        /// </summary>
        /// <returns></returns>
        public override Task OnConnected()
        {
            return base.OnConnected();
        }
        /// <summary>
        /// 断开连接
        /// </summary>
        /// <param name="stopCalled">是否是客户端主动断开：true是,false超时断开</param>
        /// <returns></returns>
        public override Task OnDisconnected(bool stopCalled)
        {
            return base.OnDisconnected(stopCalled);
        }
        /// <summary>
        /// 重新建立连接
        /// </summary>
        /// <returns></returns>
        public override Task OnReconnected()
        {
            return base.OnReconnected();
        }
        #endregion

        #region 获取联系人信息（联系人列表，群列表，最近联系人列表）
        #endregion
    }
}
