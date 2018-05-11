
namespace YiDaFuture.Application.BaseModule.CodeGeneratorModule
{
    /// <summary>
    ///Ver 2018
    /// Copyright (c) 2019 亿达未来科技发展有限公司
    /// 作者:赵金明
    /// 日 期：2017.04.17
    /// 描 述：基础设置
    /// </summary>
    public class BaseModel
    {
        /// <summary>
        /// 创建人员
        /// </summary>
        public string createUser { get; set; }
        /// <summary>
        /// 功能名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 功能描述
        /// </summary>
        public string describe { get; set; }
        /// <summary>
        /// 输出区域
        /// </summary>
        public string outputArea { get; set; }
        /// <summary>
        /// 映射类输出目录
        /// </summary>
        public string mappingDirectory { get; set; }
        /// <summary>
        /// 后端类输出目录
        /// </summary>
        public string serviceDirectory { get; set; }
        /// <summary>
        /// 前端项输出目录
        /// </summary>
        public string webDirectory { get; set; }
    }
}
