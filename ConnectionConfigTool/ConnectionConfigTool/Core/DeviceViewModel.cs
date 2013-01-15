using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using Microsoft.Win32;
using TopConfigTool.Model;
using TopConfigTool.Util;

namespace TopConfigTool.Core
{
    internal class DeviceViewModel : EntityObject
    {
        #region 变量

        private static readonly DeviceViewModel _instance = new DeviceViewModel();

        private readonly ObservableCollection<DeviceClassfication> _deviceClassfications = new ObservableCollection<DeviceClassfication>();

        #endregion

        #region 属性

        public static DeviceViewModel Instance { get { return _instance; } }

        public ObservableCollection<DeviceClassfication> DeviceClassfications
        {
            get { return _deviceClassfications; }
        }

        #endregion

        #region 构造函数

        private DeviceViewModel()
        {
            if (!Common.IsInDesignMode)
            {
                LoadDevices();
            }
        }

        #endregion

        #region 公共方法

        #endregion

        #region 私有方法

        private void LoadDevices(bool autoOpenFileDialog = true)
        {
            var path = SettingViewModel.Instance.AvmtConfig;
            if (File.Exists(path))
            {
                _deviceClassfications.Clear();
                var xElement = XElement.Load(path);
                var deviceTypesXml = xElement.XPathSelectElements("EquipmentConfigs/EquipmentConfig");
                if (null != deviceTypesXml)
                {
                    foreach(var deviceTypeXml in deviceTypesXml)
                    {
                        var devicesXml = deviceTypeXml.XPathSelectElements("EquipmentItems/EquipmentItem");
                        var deviceType = deviceTypeXml.AttributeValue("Title");
                        var devices = devicesXml.Select(x => new Device(x));
                        var tops = CreateTops(devices);
                        var deviceClassfication = new DeviceClassfication(deviceType, devices, tops);
                        _deviceClassfications.Add(deviceClassfication);
                    }
                }
                RaisePropertyChanged("DeviceClassfications");
            }
            else
            {
                var openFileDialog = new OpenFileDialog();
                openFileDialog.FileName = "avmt.exe.config";
                openFileDialog.Title = "请选择 avmt.exe.config 文件的路径";
                if (openFileDialog.ShowDialog().Value == true)
                {
                    SettingViewModel.Instance.AvmtConfig = openFileDialog.FileName;
                    LoadDevices(false);
                }
            }
        }
        private IEnumerable<Top> CreateTops(IEnumerable<Device> devices)
        {
            var devicesArray = devices.ToArray();
            var len = devicesArray.Length;
            for (int i = 0; i < devicesArray.Length; i++)
            {
                for (int j = 0; j < len - i; j++)
                {
                    yield return new Top(devicesArray[i], devicesArray[j]);
                }
            }
        }

        #endregion
    }
}
