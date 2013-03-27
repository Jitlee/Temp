using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Collections.ObjectModel;

namespace AutoDock.Layouts
{
    public class WDockedGroup : WDockGroup
    {
        #region 变量


        #endregion

        #region 属性



        #endregion

        #region 构造函数

        static WDockedGroup()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(WDockedGroup),
                new FrameworkPropertyMetadata(
                    typeof(WDockedGroup)));
        }

        public WDockedGroup()
        {

        }

        #endregion
    }
}
