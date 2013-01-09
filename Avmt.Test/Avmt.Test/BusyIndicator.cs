using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Avmt.Test
{
    [StyleTypedProperty(Property = "Style", StyleTargetType = typeof(Control))]
    public class BusyIndicator : Decorator
    {
        private Guid _backgroundChildId = Guid.Empty;

        #region 属性

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
                var isBusying = (bool)e.NewValue;

                if (isBusying)
                {
                    element._backgroundChildId = BackgroundVisualHost.AddChild(element,
                        new Control()
                        {
                            HorizontalAlignment = element.HorizontalAlignment,
                            VerticalAlignment = element.VerticalAlignment,
                            Margin = element.Margin
                        });
                }
                else
                {
                    BackgroundVisualHost.RemoveChild(element, element._backgroundChildId);
                }

                if (!element.IsEnabledWhenBusying)
                {
                    element.SetIndicatorProperty(IsEnabledProperty, !isBusying);
                }

                if (null != element.Child)
                {
                    AnimationChildOpcatiy(isBusying, element.Child, element.FadeTime);
                }
            }
        }

        #endregion

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
                var style = e.NewValue as Style;
                if (null != style)
                {
                    style.Seal();
                }
                element.SetIndicatorProperty(Control.StyleProperty, style);
            }
        }

        #endregion

        #region HorizontalAlignment

        public static readonly new DependencyProperty HorizontalAlignmentProperty =
            DependencyProperty.Register(
            "HorizontalAlignment",
            typeof(HorizontalAlignment),
            typeof(BusyIndicator),
            new FrameworkPropertyMetadata(HorizontalAlignment.Center, OnHorizontalAlignmentPropertyChanged));

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
                element.SetIndicatorProperty(e.Property, e.NewValue);
            }
        }

        #endregion

        #region VerticalAlignment

        public static readonly new DependencyProperty VerticalAlignmentProperty =
            DependencyProperty.Register(
            "VerticalAlignment",
            typeof(VerticalAlignment),
            typeof(BusyIndicator),
            new FrameworkPropertyMetadata(VerticalAlignment.Center, OnVerticalAlignmentPropertyChanged));

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
                element.SetIndicatorProperty(e.Property, e.NewValue);
            }
        }

        #endregion

        #region Margin

        public static readonly new DependencyProperty MarginProperty =
            DependencyProperty.Register(
            "Margin",
            typeof(Thickness),
            typeof(BusyIndicator),
            new FrameworkPropertyMetadata(new Thickness(0d), OnMarginPropertyChanged));

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
                element.SetIndicatorProperty(e.Property, e.NewValue);
            }
        }

        #endregion

        #region OpacityWhenBusy

        public static readonly DependencyProperty OpacityWhenBusyProperty =
            DependencyProperty.RegisterAttached(
            "OpacityWhenBusy",
            typeof(double?),
            typeof(BusyIndicator),
            new FrameworkPropertyMetadata(0.5));

        [AttachedPropertyBrowsableForChildren]
        public static double? GetOpacityWhenBusy(UIElement obj)
        {
            return (double?)obj.GetValue(OpacityWhenBusyProperty);
        }

        public static void SetOpacityWhenBusy(UIElement obj, double? value)
        {
            obj.SetValue(OpacityWhenBusyProperty, value);
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
            if (null != element && element.IsBusying)
            {
                element.SetIndicatorProperty(IsEnabledProperty, e.NewValue);
            }
        }

        #endregion

        #region FadeTime

        public static DependencyProperty FadeTimeProperty =
            DependencyProperty.Register("FadeTime",
            typeof(TimeSpan),
            typeof(BusyIndicator),
            new FrameworkPropertyMetadata(TimeSpan.FromSeconds(.5)));

        public TimeSpan FadeTime
        {
            get { return (TimeSpan)GetValue(FadeTimeProperty); }
            set { SetValue(FadeTimeProperty, value); }
        }

        #endregion

        #endregion

        #region 构造函数

        static BusyIndicator()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(BusyIndicator),
                new FrameworkPropertyMetadata(typeof(BusyIndicator)));
        }

        public BusyIndicator()
        {
            this.Loaded += BusyIndicator_Loaded;
        }

        #endregion

        #region 重载方法

        protected override void OnVisualChildrenChanged(DependencyObject visualAdded, DependencyObject visualRemoved)
        {
            base.OnVisualChildrenChanged(visualAdded, visualRemoved);

            if (visualAdded is UIElement)
            {
                AnimationChildOpcatiy(IsBusying, visualAdded as UIElement, FadeTime);
            }
        }

        protected override Size ArrangeOverride(Size arrangeSize)
        {
            if (_backgroundChildId != Guid.Empty && IsLoaded)
            {
                Dispatcher.BeginInvoke(new Action(UpdateWindowPosition));
            }
            return base.ArrangeOverride(arrangeSize);
        }

        #endregion

        private void BusyIndicator_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateWindowPosition();
        }

        private void UpdateWindowPosition()
        {
            var root = this.VisualAncestors().OfType<UIElement>().LastOrDefault();
            if (null != root)
            {
                BackgroundVisualHost.WindowPositionChanged(this, this.TranslatePoint(new Point(), root));
            }
        }

        private static void AnimationChildOpcatiy(bool isBusying, UIElement child, TimeSpan fadeTime)
        {
            var opacityWhenBusy = GetOpacityWhenBusy(child);
            if (opacityWhenBusy.HasValue)
            {
                var animation = new DoubleAnimation();
                animation.Duration = new Duration(fadeTime);

                if (isBusying)
                {
                    animation.To = opacityWhenBusy;
                }

                child.BeginAnimation(OpacityProperty, animation);
            }
        }

        private void SetIndicatorProperty(DependencyProperty property, object value)
        {
            if (_backgroundChildId != Guid.Empty)
            {
                BackgroundVisualHost.DispatchAction(this, _backgroundChildId, (child) => { child.SetValue(property, value); });
            }
        }
    }
}
