using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TopConfigTool.Model
{
    internal class Top : EntityObject
    {
        #region 变量

        private bool _connection;

        private bool _articulated;

        private bool _inclusion;

        private bool _affiliated;

        #endregion

        #region 属性

        public Device Device1 { get; private set; }

        public Device Device2 { get; private set; }

        public bool Connection { get { return _connection; } set { _connection = value; RaisePropertyChanged("Connection"); } }

        public bool Articulated { get { return _articulated; } set { _articulated = value; RaisePropertyChanged("Articulated"); } }

        public bool Inclusion { get { return _inclusion; } set { _inclusion = value; RaisePropertyChanged("Inclusion"); } }

        public bool Affiliated { get { return _affiliated; } set { _affiliated = value; RaisePropertyChanged("Affiliated"); } }

        #endregion

        #region 构造函数

        public Top(Device device1, Device device2)
        {
            Device1 = device1;
            Device2 = device2;
        }

        #endregion
    }
}
