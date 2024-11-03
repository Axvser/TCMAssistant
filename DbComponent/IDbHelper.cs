using MinimalisticWPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCMAssistant.DbComponent
{
    /// <summary>
    /// 数据库代理接口
    /// </summary>
    internal interface IDbHelper : IProxy
    {
        /// <summary>
        /// 增
        /// </summary>
        /// <param name="conditions">构建增加语句所需参数</param>
        /// <returns>object? 附加信息</returns>
        object? Append(params object?[] conditions);

        /// <summary>
        /// 删
        /// </summary>
        /// <param name="conditions">构建删除语句所需参数</param>
        /// <returns>object? 附加信息</returns>
        object? Delete(params object?[] conditions);

        /// <summary>
        /// 改
        /// </summary>
        /// <param name="conditions">构建编辑语句所需参数</param>
        /// <returns>object? 附加信息</returns>
        object? Edit(params object?[] conditions);

        /// <summary>
        /// 查
        /// </summary>
        /// <param name="conditions">构建查询语句所需参数</param>
        /// <returns>object? 查询结果</returns>
        object? Query(params object?[] conditions);
    }
}
