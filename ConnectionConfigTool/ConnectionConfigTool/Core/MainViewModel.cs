using System.Reflection;
using TopConfigTool.Model;

namespace TopConfigTool.Core
{
    internal class MainViewModel : EntityObject
    {
        #region 变量

        private readonly static MainViewModel _instance = new MainViewModel();

        private readonly string _appTitle = (AssemblyTitleAttribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyTitleAttribute)) as AssemblyTitleAttribute).Title;

        #endregion

        #region 属性

        public static MainViewModel Instance { get { return _instance; } }

        public string AppTitle { get { return _appTitle; } }

        public DeviceViewModel DeviceViewModel { get { return DeviceViewModel.Instance; } }

        #endregion

        #region 构造函数

        private MainViewModel()
        {
            
        }

        #endregion

        #region 公共方法

        #endregion

        #region 私有方法

        #endregion
    }
}
