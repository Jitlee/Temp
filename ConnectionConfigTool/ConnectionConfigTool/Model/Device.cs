using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Linq;
using TopConfigTool.Util;

namespace TopConfigTool.Model
{
    internal class Device : EntityObject
    {
        #region 变量

        private string _description;

        private string _graphCode;

        private bool _isMapDevice;

        private bool _isDetailDevice;

        private readonly ObservableCollection<DeviceAttribute> _attributes = new ObservableCollection<DeviceAttribute>();
        
        #endregion

        #region 属性

        public string Description { get { return _description; } set { _description = value; RaisePropertyChanged("Description"); } }
        
        public string GraphCode { get { return _graphCode; } set { _graphCode = value; RaisePropertyChanged("GraphCode"); } }

        public bool IsMapDevice { get { return _isMapDevice; } set { _isMapDevice = value; RaisePropertyChanged("IsMapDevice"); } }

        public bool IsDetailDevice { get { return _isDetailDevice; } set { _isDetailDevice = value; RaisePropertyChanged("IsDetailDevice"); } }

        public ObservableCollection<DeviceAttribute> Attributes { get { return _attributes; } }

        #endregion

        #region 构造函数

        public Device() { }

        public Device(XElement xElement)
        {
            _description = xElement.AttributeValue("Description");
            _graphCode = xElement.AttributeValue("GraphCode");
            InitGraphPanelType(xElement.AttributeValue("GraphPanelType"));
            var xmlAttributes = xElement
                .Attributes()
                .Where(a => !string.Equals(a.Name.LocalName, "Description", StringComparison.CurrentCultureIgnoreCase) &&
                            !string.Equals(a.Name.LocalName, "GraphCode", StringComparison.CurrentCultureIgnoreCase) &&
                            !string.Equals(a.Name.LocalName, "GraphPanelType", StringComparison.CurrentCultureIgnoreCase));
            foreach (var xmlAttribute in xmlAttributes)
            {
                _attributes.Add(new DeviceAttribute(xmlAttribute.Name.LocalName, xmlAttribute.Value));
            }
        }

        #endregion

        #region 私有函数

        private void InitGraphPanelType(string graphPanelType)
        {
            if (string.IsNullOrEmpty(graphPanelType))
            {
                _isMapDevice = true;
                _isDetailDevice = false;
            }
            else
            {
                var types = graphPanelType.Split(',').Select(t => Converter.ToInt(t));
                _isMapDevice = types.Contains(1);
                _isDetailDevice = types.Contains(2);
            }
        }

        #endregion
    }
}
