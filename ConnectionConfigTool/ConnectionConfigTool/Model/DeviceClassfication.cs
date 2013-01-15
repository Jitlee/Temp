using System.Collections.Generic;
using System.Collections.ObjectModel;
using TopConfigTool.Controls;

namespace TopConfigTool.Model
{
    internal class DeviceClassfication : EntityObject
    {
        #region 变量

        private string _name;

        private ObservableCollection<Device> _devices;

        private ObservableCollection<Top> _tops;

        private readonly TopControl _content = new TopControl();

        #endregion

        #region 属性

        public TopControl Content { get { return _content; } }

        public string Name { get { return _name; } set { _name = value; RaisePropertyChanged("Name"); } }

        public ObservableCollection<Device> Devices { get { return _devices; } set { if (value != _devices) { _devices = value; RaisePropertyChanged("Devices"); } } }

        public ObservableCollection<Top> Tops { get { return _tops; } set { if (value != _tops) { _tops = value; RaisePropertyChanged("Tops"); } } }

        #endregion

        #region 构造函数

        public DeviceClassfication() { }

        public DeviceClassfication(string name, IEnumerable<Device> devices, IEnumerable<Top> tops)
        {
            _name = name;
            Devices = new ObservableCollection<Device>(devices);
            Tops = new ObservableCollection<Top>(tops);
            _content.DataContext = this;
        }

        #endregion
    }
}
