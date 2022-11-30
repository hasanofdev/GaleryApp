using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace GaleryApp.Pages
{
    /// <summary>
    /// Interaction logic for ImageFrame.xaml
    /// </summary>
    public partial class ImageFrame : Page, INotifyPropertyChanged
    {
        List<ImageSource> _images;
        ImageSource _currentImage;
        DispatcherTimer Timer;

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        public ImageSource CurrentImage
        {
            get { return _currentImage; }
            set { _currentImage = value; NotifyPropertyChanged(); }
        }
        public ImageFrame(ImageSource source, List<ImageSource> imageSources)
        {
            InitializeComponent();
            DataContext = this;
            _currentImage = source;
            _images = imageSources;
        }
        private void Left_Click(object sender, RoutedEventArgs e)
        {
            int selectedItemIndex = _images.FindIndex(f => f == CurrentImage);
            if (selectedItemIndex == 0)
                selectedItemIndex = _images.Count;

            CurrentImage = _images[selectedItemIndex -= 1];
        }
        private void Right_Click(object sender, RoutedEventArgs e)
        {
            int selectedItemIndex = _images.FindIndex(f => f == CurrentImage);
            if (selectedItemIndex == _images.Count - 1)
                selectedItemIndex = -1;

            CurrentImage = _images[selectedItemIndex += 1];
        }
        private void PlayPause_Click(object sender, RoutedEventArgs e)
        {
            Button? btn = sender as Button;

            if (btn.Content as string == "▶")
            {
                Timer = new DispatcherTimer();
                Timer.Interval = TimeSpan.FromMilliseconds(1000);
                Timer.Tick += Timer_Tick;
                Timer.Start();
                LeftButton.IsEnabled = false;
                RightButton.IsEnabled = false;
                btn.Content = "⏯";
            }
            else if (btn.Content as string == "⏯")
            {
                LeftButton.IsEnabled = true;
                RightButton.IsEnabled = true;
                Timer.Stop();
                btn.Content = "▶";
            }

        }
        private void Timer_Tick(object? sender, EventArgs e)
        {
            DispatcherTimer? timer = sender as DispatcherTimer;
            int selectedItemIndex = _images.FindIndex(f => f == CurrentImage);
            if (selectedItemIndex == _images.Count - 1)
                selectedItemIndex = -1;

            CurrentImage = _images[selectedItemIndex += 1];
        }

        #region Continue
        private void JumpLeft_Click(object sender, RoutedEventArgs e)
        {

        }
        private void JumpRight_Click(object sender,RoutedEventArgs e)
        {

        }
        #endregion
    }
}