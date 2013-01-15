using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace TopConfigTool.Util
{
    internal static class XElementExtensions
    {
        /// <summary>
        /// 通过名称获取节点值，失败返回空
        /// </summary>
        /// <param name="root"></param>
        /// <param name="xName"></param>
        /// <returns></returns>
        public static string ElementValue(this XElement root, XName xName)
        {
            if (null != root.Element(xName))
            {
                return root.Element(xName).Value;
            }
            return string.Empty;
        }

        /// <summary>
        /// 通过名称获取属性值，失败返回空
        /// </summary>
        /// <param name="root"></param>
        /// <param name="xName"></param>
        /// <returns></returns>
        public static string AttributeValue(this XElement root, XName xName)
        {
            if (null != root.Attribute(xName))
            {
                return root.Attribute(xName).Value;
            }
            return string.Empty;
        }
    }
}
