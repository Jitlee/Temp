using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Shapes;
using TopConfigTool.Model;

namespace TopConfigTool.Controls
{
    /// <summary>
    /// TopControl.xaml 的交互逻辑
    /// </summary>
    public partial class TopControl : UserControl
    {
        const double ITEM_WIDTH = 70d;
        const double ITEM_HEIGHT = 35d;
        public TopControl()
        {
            InitializeComponent();
            this.DataContextChanged += TopControl_DataContextChanged;
        }

        private void TopControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var deviceClassfication = DataContext as DeviceClassfication;
            if (null != deviceClassfication)
            {
                UpdateCanvas(deviceClassfication);
            }
        }

        private void UpdateCanvas(DeviceClassfication diviceClassfication)
        {
            var devices = diviceClassfication.Devices;
            var tops = diviceClassfication.Tops;
            var i = 0;
            var count = devices.Count();
            HorizontalDeviceCanvas.Children.Clear();
            VerticalDeviceCanvas.Children.Clear();
            TopCanvas.Children.Clear();
            foreach (var device in devices)
            {
                for (var j = 0; j < count - i; j++)
                {
                    var top = tops[(i * count + j - (i + 1) / 2 * i)];
                    var rectangle = new Rectangle()
                    {
                        SnapsToDevicePixels = true,
                        Width = ITEM_WIDTH,
                        Height = ITEM_HEIGHT,
                        Fill = Brushes.Silver,
                        Opacity = 0.2,
                    };
                    rectangle.SetValue(Canvas.TopProperty, (i + 1) * ITEM_HEIGHT);
                    rectangle.SetValue(Canvas.LeftProperty, (j + 1) * ITEM_WIDTH);
                    TopCanvas.Children.Add(rectangle);
                }
                {
                    // Vertical
                    var border = CreateDeviceItem(device);
                    border.SetValue(Canvas.TopProperty, (i + 1) * ITEM_HEIGHT);
                    VerticalDeviceCanvas.Children.Add(border);
                }
                {
                    // Horizontal
                    var border = CreateDeviceItem(device);
                    border.SetValue(Canvas.LeftProperty, (i + 1) * ITEM_WIDTH);
                    HorizontalDeviceCanvas.Children.Add(border);
                }
                i++;
            }
        }

        private static Border CreateDeviceItem(Model.Device device)
        {
            var border = new Border()
            {
                Width = ITEM_WIDTH,
                Height = ITEM_HEIGHT,
                Child = new TextBlock()
                {
                    Text = device.Description,
                    TextAlignment = TextAlignment.Center,
                    TextWrapping = TextWrapping.WrapWithOverflow,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                },
            };
            return border;
        }

        private void MainCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize != e.PreviousSize)
            {
                MainCanvas.Clip = new RectangleGeometry(new Rect(e.NewSize));

                UpdateScollBar(e.NewSize);
                UpdateGridLine(e);
            }
        }

        private void UpdateGridLine(SizeChangedEventArgs e)
        {
            if (e.NewSize.Height > e.PreviousSize.Height
                || e.NewSize.Width > e.PreviousSize.Width)
            {
                GridLineCanvas.Children.Clear();
                var row = (int)(e.NewSize.Height / ITEM_HEIGHT);
                var column = (int)(e.NewSize.Width / ITEM_WIDTH);
                for (int i = 2; i <= row; i++)
                {
                    for (int j = 2; j <= column; j++)
                    {
                        GridLineCanvas.Children.Add(new Line()
                        {
                            X1 = 0d,
                            Y1 = i * ITEM_HEIGHT,
                            X2 = e.NewSize.Width,
                            Y2 = i * ITEM_HEIGHT,
                            Stroke = Brushes.Silver,
                            StrokeThickness = .5d,
                            SnapsToDevicePixels = true,
                        });

                        GridLineCanvas.Children.Add(new Line()
                        {
                            X1 = j * ITEM_WIDTH,
                            Y1 = 0d,
                            X2 = j * ITEM_WIDTH,
                            Y2 = e.NewSize.Height,
                            Stroke = Brushes.Silver,
                            StrokeThickness = .5d,
                            SnapsToDevicePixels = true,
                        });
                    }
                }
                GridLineCanvas.Children.Add(new Line()
                {
                    X1 = 0d,
                    Y1 = ITEM_HEIGHT,
                    X2 = e.NewSize.Width,
                    Y2 = ITEM_HEIGHT,
                    Stroke = Brushes.Black,
                    StrokeThickness = 1.5d,
                    SnapsToDevicePixels = true,
                });
                GridLineCanvas.Children.Add(new Line()
                {
                    X1 = ITEM_WIDTH,
                    Y1 = 0d,
                    X2 = ITEM_WIDTH,
                    Y2 = e.NewSize.Height,
                    Stroke = Brushes.Black,
                    StrokeThickness = 1.5d,
                    SnapsToDevicePixels = true,
                });
            }
        }

        private void UpdateScollBar(Size size)
        {
            var deviceClassfication = DataContext as DeviceClassfication;
            if (null != deviceClassfication)
            {
                var count = (double)deviceClassfication.Devices.Count + 1d;
                UpdateVerticalScrollBar(size, count);
                UpdateHorizontalScrollBar(size, count);
                UpdateVerticalScrollBar(size, count);
                UpdateHorizontalScrollBar(size, count);
            }
        }

        private void UpdateVerticalScrollBar(Size size, double count)
        {
            var height = Math.Floor(size.Height / ITEM_HEIGHT) * ITEM_HEIGHT;
            var viewHeight = count * ITEM_HEIGHT;
            var offset = viewHeight - height;
            if (viewHeight > height)
            {
                VerticalScrollBar.Visibility = Visibility.Visible;
                VerticalScrollBar.LargeChange = VerticalScrollBar.SmallChange = ITEM_HEIGHT / offset;
                VerticalScrollBar.ViewportSize = height / offset;
            }
            else
            {
                VerticalScrollBar.Visibility = Visibility.Collapsed;
            }
        }

        private void UpdateHorizontalScrollBar(Size size, double count)
        {
            var width = Math.Floor(size.Width / ITEM_WIDTH) * ITEM_WIDTH;
            var viewWidth = count * ITEM_WIDTH;
            var offset = viewWidth - width;
            if (viewWidth > width)
            {
                HorizontalScrollBar.Visibility = Visibility.Visible;
                HorizontalScrollBar.LargeChange = HorizontalScrollBar.SmallChange = ITEM_WIDTH / offset;
                HorizontalScrollBar.ViewportSize = width / offset;
            }
            else
            {
                HorizontalScrollBar.Visibility = Visibility.Collapsed;
            }
        }

        private void HorizontalScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            var scrollBar = sender as ScrollBar;
            SetScrollBarMoveToPoint(scrollBar, e);
            var offset = - Math.Floor(e.NewValue / scrollBar.SmallChange)* ITEM_WIDTH;
            TopCanvas.SetValue(Canvas.LeftProperty, offset);
            HorizontalDeviceCanvas.SetValue(Canvas.LeftProperty, offset);
        }

        private void VerticalScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            var scrollBar = sender as ScrollBar;
            SetScrollBarMoveToPoint(scrollBar, e);
            var offset = - Math.Floor(e.NewValue / scrollBar.SmallChange) * ITEM_HEIGHT;
            TopCanvas.SetValue(Canvas.TopProperty, offset);
            VerticalDeviceCanvas.SetValue(Canvas.TopProperty, offset);
        }

        private void SetScrollBarMoveToPoint(ScrollBar scrollBar, ScrollEventArgs e)
        {
            if (e.ScrollEventType == ScrollEventType.ThumbTrack ||
                e.ScrollEventType == ScrollEventType.ThumbPosition)
            {
                if (e.NewValue / scrollBar.SmallChange - Math.Floor(e.NewValue / scrollBar.SmallChange) > 0.0000001d)
                {
                    scrollBar.Value = Math.Floor(e.NewValue / scrollBar.SmallChange) * scrollBar.SmallChange;
                    e.Handled = true;
                }
            }
        }

        private void MainCanvas_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            var flag = e.Delta == 0 ? 0d : (e.Delta < 0 ? 1d : -1d);
            VerticalScrollBar.Value += flag * VerticalScrollBar.SmallChange;
            var offset = -Math.Floor(VerticalScrollBar.Value / VerticalScrollBar.SmallChange) * ITEM_WIDTH;
            TopCanvas.SetValue(Canvas.TopProperty, offset);
            VerticalDeviceCanvas.SetValue(Canvas.TopProperty, offset);
        }
    }
}
