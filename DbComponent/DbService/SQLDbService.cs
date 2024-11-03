using MinimalisticWPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCMAssistant.DbComponent.DbService
{
    internal class SQLDbService : IDbHelper
    {
        /// <summary>
        /// 请使用此代理对象执行数据库操作
        /// </summary>
        public IDbHelper Proxy { get; set; }
        public SQLDbService() { Proxy = this.CreateProxy<IDbHelper>(); }

        public object? Append(params object?[] conditions)
        {
            return null;
        }

        public object? Delete(params object?[] conditions)
        {
            return null;
        }

        public object? Edit(params object?[] conditions)
        {
            return null;
        }

        public object? Query(params object?[] conditions)
        {
            return null;
        }
    }
}
