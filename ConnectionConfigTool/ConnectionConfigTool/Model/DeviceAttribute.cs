using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TopConfigTool.Model
{
    internal class DeviceAttribute : EntityObject
    {
        #region 属性

        private string _name;
        public string Name { get { return _name; } set { _name = value; RaisePropertyChanged("Name"); } }

        private string _value;
        public string Value { get { return _value; } set { _value = value; RaisePropertyChanged("GraphCode"); } }

        #endregion

        #region 构造方法

        public DeviceAttribute() { }

        public DeviceAttribute(string name, string value)
        {
            _name = name;
            _value = value;
        }

        #endregion

        #region 重载

        public override bool Equals(object obj)
        {
            var atrribute = obj as DeviceAttribute;
            if (null != atrribute && null != atrribute._name)
            {
                return atrribute._name.Equals(_value, StringComparison.CurrentCultureIgnoreCase);
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }
}
