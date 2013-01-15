using System;
using System.ComponentModel;
using System.IO;
using System.Windows;

namespace TopConfigTool.Util
{
    internal static class Common
    {
        public readonly static string ApplicationDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "EasyCodeword");

        public readonly static string TempFile = GetAppPath("tmp");

        public static string GetAppPath(string path)
        {
            if (!Directory.Exists(ApplicationDataPath))
            {
                Directory.CreateDirectory(ApplicationDataPath);
            }
            return Path.Combine(ApplicationDataPath, path);
        }

        public static string GetAppPath(string path1, string path2)
        {
            if (!Directory.Exists(ApplicationDataPath))
            {
                Directory.CreateDirectory(ApplicationDataPath);
            }
            return Path.Combine(Path.Combine(ApplicationDataPath, path1), path2);
        }

        private static readonly bool _IsInDesignMode = (bool)DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue;
        public static bool IsInDesignMode
        {
            get { return _IsInDesignMode; }
        }

        ///// <summary>
        ///// 判断当前是否具有管理员权限
        ///// </summary>
        //public static bool IsAdmin()
        //{
        //    return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
        //}
    }
}
