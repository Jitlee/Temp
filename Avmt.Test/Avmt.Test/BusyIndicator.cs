using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Avmt.Test
{
    [StyleTypedProperty(Property = "Style", StyleTargetType = typeof(Control))]
    public class BusyIndicator : Decorator
    {
        #region 属性

        #region Style

        public static readonly new DependencyProperty StyleProperty =
            DependencyProperty.Register(
            "Style",
            typeof(Style),
            typeof(BusyIndicator),
            new FrameworkPropertyMetadata(OnStylePropertyChanged));

        /// <summary>
        /// 获取或设置加载动画控件的样式
        /// </summary>
        public new Style Style
        {
            get { return (Style)GetValue(StyleProperty); }
            set { SetValue(StyleProperty, value); }
        }

        private static void OnStylePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as BusyIndicator;
            if(null != element)
            {

            }
        }

        #endregion

        #region HorizontalAlignment

        public static readonly new DependencyProperty HorizontalAlignmentProperty =
            DependencyProperty.Register(
            "HorizontalAlignment",
            typeof(HorizontalAlignment),
            typeof(BusyIndicator),
            new FrameworkPropertyMetadata(OnHorizontalAlignmentPropertyChanged));

        /// <summary>
        /// 获取或设置加载动画控件的样式
        /// </summary>
        public new HorizontalAlignment HorizontalAlignment
        {
            get { return (HorizontalAlignment)GetValue(HorizontalAlignmentProperty); }
            set { SetValue(HorizontalAlignmentProperty, value); }
        }

        private static void OnHorizontalAlignmentPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as BusyIndicator;
            if (null != element)
            {

            }
        }

        #endregion

        #region VerticalAlignment

        public static readonly new DependencyProperty VerticalAlignmentProperty =
            DependencyProperty.Register(
            "VerticalAlignment",
            typeof(VerticalAlignment),
            typeof(BusyIndicator),
            new FrameworkPropertyMetadata(OnVerticalAlignmentPropertyChanged));

        /// <summary>
        /// 获取或设置加载动画控件的样式
        /// </summary>
        public new VerticalAlignment VerticalAlignment
        {
            get { return (VerticalAlignment)GetValue(VerticalAlignmentProperty); }
            set { SetValue(VerticalAlignmentProperty, value); }
        }

        private static void OnVerticalAlignmentPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as BusyIndicator;
            if (null != element)
            {

            }
        }

        #endregion

        #region Margin

        public static readonly new DependencyProperty MarginProperty =
            DependencyProperty.Register(
            "Margin",
            typeof(Thickness),
            typeof(BusyIndicator),
            new FrameworkPropertyMetadata(OnMarginPropertyChanged));

        /// <summary>
        /// 获取或设置加载动画控件的样式
        /// </summary>
        public new Thickness Margin
        {
            get { return (Thickness)GetValue(MarginProperty); }
            set { SetValue(MarginProperty, value); }
        }

        private static void OnMarginPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as BusyIndicator;
            if (null != element)
            {

            }
        }

        #endregion

        #region Opacity

        public static readonly new DependencyProperty OpacityProperty =
            DependencyProperty.Register(
            "Opacity",
            typeof(double),
            typeof(BusyIndicator),
            new FrameworkPropertyMetadata(OnOpacityPropertyChanged));

        /// <summary>
        /// 获取或设置加载动画控件的样式
        /// </summary>
        public new double Opacity
        {
            get { return (double)GetValue(OpacityProperty); }
            set { SetValue(OpacityProperty, value); }
        }

        private static void OnOpacityPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as BusyIndicator;
            if (null != element)
            {

            }
        }

        #endregion

        #region IsBusying

        public static DependencyProperty IsBusyingProperty =
            DependencyProperty.Register("IsBusying",
            typeof(bool),
            typeof(BusyIndicator),
            new FrameworkPropertyMetadata(
                false,
                FrameworkPropertyMetadataOptions.AffectsMeasure,
                OnIsBusyingChanged));

        public bool IsBusying
        {
            get { return (bool)GetValue(IsBusyingProperty); }
            set { SetValue(IsBusyingProperty, value); }
        }

        private static void OnIsBusyingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as BusyIndicator;
            if (null != element)
            {
            }
        }

        #endregion

        #region IsEnabledWhenBusying

        public static DependencyProperty IsEnabledWhenBusyingProperty =
            DependencyProperty.Register("IsEnabledWhenBusying",
            typeof(bool),
            typeof(BusyIndicator),
            new FrameworkPropertyMetadata(
                false,
                FrameworkPropertyMetadataOptions.AffectsMeasure,
                OnIsEnabledWhenBusyingChanged));

        public bool IsEnabledWhenBusying
        {
            get { return (bool)GetValue(IsEnabledWhenBusyingProperty); }
            set { SetValue(IsEnabledWhenBusyingProperty, value); }
        }

        private static void OnIsEnabledWhenBusyingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as BusyIndicator;
            if (null != element)
            {
            }
        }

        #endregion

        #region FadeTime

        public static DependencyProperty FadeTimeProperty =
            DependencyProperty.Register("FadeTime",
            typeof(TimeSpan),
            typeof(BusyIndicator),
            new FrameworkPropertyMetadata(TimeSpan.FromSeconds(.5)));

        #endregion

        #endregion
        #region 构造函数

        static BusyIndicator()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(BusyIndicator),
                new FrameworkPropertyMetadata(typeof(BusyIndicator)));
        }

        #endregion
    }
}
