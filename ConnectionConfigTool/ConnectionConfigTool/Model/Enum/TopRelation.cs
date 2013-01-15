using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TopConfigTool.Model
{
    /// <summary>
    /// 拓扑关系
    /// </summary>
    internal enum TopRelation
    {
        /// <summary>
        /// 没有关系
        /// </summary>
        None = 0,

        /// <summary>
        /// 连接关系
        /// </summary>
        Connection = 1,

        /// <summary>
        /// 挂接关系
        /// </summary>
        Articulated = 2,

        /// <summary>
        /// 包含关系
        /// </summary>
        Inclusion = 4,

        /// <summary>
        /// 附属关系
        /// </summary>
        Affiliated = 8,
    }
}
