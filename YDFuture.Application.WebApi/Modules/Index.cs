using Nancy;

namespace YiDaFuture.Application.WebApi.Modules
{
    /// <summary>  
    ///Ver 2018
    /// Copyright (c) 2019 亿达未来科技发展有限公司
    /// 作者:赵金明
    /// 日 期：2017.05.12
    /// 描 述：默认页面
    /// </summary>
    public class Index : BaseApi
    {
        public Index()
            : base()
        {
            Get["/"] = MainIndex;
            Get["/bgimg"] = BgImg;
        }
        /// <summary>
        /// 默认开始页面
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Response MainIndex(dynamic _)
        {
            return Response.AsFile("index.html");
        }
        /// <summary>
        /// 默认开始页面图片
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Response BgImg(dynamic _)
        {
            return Response.AsImage("port.png");
        }
    }
}