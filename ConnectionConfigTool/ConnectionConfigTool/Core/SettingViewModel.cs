using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TopConfigTool.Model;
using TopConfigTool.Util;

namespace TopConfigTool.Core
{
    internal class SettingViewModel : EntityObject
    {
        #region 变量

        #endregion

        #region 属性

        #region 单例

        private static readonly SettingViewModel _instance = new SettingViewModel();

        public static SettingViewModel Instance { get { return _instance; } }

        #endregion

        #region 保存命令

        private readonly DelegateCommand _saveCommand;

        public DelegateCommand SaveCommand { get { return _saveCommand; } }

        #endregion

        #region avmt.config 文件路径

        private string _avmtConfig;

        public string AvmtConfig
        {
            get { return _avmtConfig; }
            set { _avmtConfig = value; RaisePropertyChanged("avmt.config"); _saveCommand.RaiseCanExecuteChanged(); }
        }

        private void InitAvmtConfig()
        {
            _avmtConfig = RWReg.GetValue("Avmt", "AvmtConfig", "avmt.exe.config").ToString();
        }

        private void SaveAvmtConfig()
        {
            RWReg.SetValue("Avmt", "AvmtConfig", _avmtConfig);
        }

        private bool CanSaveAvmtConfig()
        {
            var avmtConfig = RWReg.GetValue("Avmt", "AvmtConfig", "avmt.exe.config").ToString();
            return !string.Equals(avmtConfig, _avmtConfig, StringComparison.CurrentCultureIgnoreCase);
        }

        #endregion

        #endregion

        #region 构造函数

        private SettingViewModel()
        {
            InitSetting();
            _saveCommand = new DelegateCommand(Save, CanSave);
        }

        #endregion

        #region 公共方法

        #endregion

        #region 私有方法

        private void InitSetting()
        {
            InitAvmtConfig();
        }

        private bool CanSave()
        {
            return CanSaveAvmtConfig();
        }

        private void Save()
        {
            SaveAvmtConfig();
            _saveCommand.RaiseCanExecuteChanged();
        }

        #endregion
    }
}
