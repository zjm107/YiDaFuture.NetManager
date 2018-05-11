using System;
namespace YiDaFuture.Application.IM
{
    /// <summary>
    ///Ver 2018
    /// Copyright (c) 2019 亿达未来科技发展有限公司
    /// 作者:赵金明
    /// 日 期：2017.04.01
    /// 描 述：日志打印函数
    /// </summary>
    public class ConsoleEx
    {
        /// <summary>
        /// 控制台屏幕输出
        /// </summary>
        /// <param name="msg">消息</param>
        public static void WriteLine(string msg)
        {
            try
            {
                Console.WriteLine("【{0}】{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), msg);
            }
            catch
            {
            }
        }
    }
}
