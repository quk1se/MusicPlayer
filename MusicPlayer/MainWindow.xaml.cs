using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MusicPlayer
{
    public partial class MainWindow : Window
    {
        private AppStyle appStyle;
        private MediaPlayer mediaPlayer;
        private bool isPaused;
        private TimeSpan pausePosition;
        private Slider progressSlider;
        private DateTime lastClickTime = DateTime.MinValue;
        public Random randomTrack = new Random();
        public int tempPosition = 0;
        public MainWindow()
        {
            InitializeComponent();
            StartSett();
            mediaPlayer = new MediaPlayer();
            mediaPlayer.Volume = 0.1;
            mediaPlayer.MediaEnded += MediaPlayer_MediaEnded;
        }

        public void StartSett()
        {
            appStyle = new AppStyle(this);
            appStyle.SetBackground();
            appStyle.SetPlayButtonImg();
            appStyle.SetBackButtonImg();
            appStyle.SetNextButtonImg();
            appStyle.ChangeMusicName();
            appStyle.SetRepeatButtonImg();
            appStyle.SetNotShuffleButtonImg();
            appStyle.SetSkip10BtnImg();
            appStyle.SetRepeat10BtnImg();
            appStyle.SetVolumeDownImg();
            appStyle.SetVolumeUpImg();
            volumeSlider.BorderBrush = Brushes.Black;
            PlayBtn.FocusVisualStyle = null;
            this.ResizeMode = ResizeMode.NoResize;
            this.Title = "Moseeefy";
            this.Icon = new BitmapImage(new Uri(@"D:\\itstep\\winforms\\MusicPLayer\\MusicPLayer\\btnsImg\\moseeefy.ico", UriKind.RelativeOrAbsolute));
            volumeDown.Source = new BitmapImage(new Uri(@"D:\\itstep\\winforms\\MusicPLayer\\MusicPLayer\\btnsImg\\volumeDown.png", UriKind.RelativeOrAbsolute));
            volumeUp.Source = new BitmapImage(new Uri(@"D:\\itstep\\winforms\\MusicPLayer\\MusicPLayer\\btnsImg\\volumeUp.png", UriKind.RelativeOrAbsolute));
        }

        private void PlayBtn_Click(object sender, RoutedEventArgs e)
        {
            if (appStyle.PlayBtnPosition == 1)
            {
                appStyle.SetPauseButtonImg();
                mediaPlayer.Open(new Uri(appStyle.musicFiles[appStyle.MusicIndex]));
                
                if (isPaused)
                {
                    mediaPlayer.Position = pausePosition;
                    mediaPlayer.Play();
                    isPaused = false;
                }
                else
                {
                    mediaPlayer.Play();
                }
            }
            else if (appStyle.PlayBtnPosition == 0)
            {
                appStyle.SetPlayButtonImg();
                if (mediaPlayer.CanPause)
                {
                    mediaPlayer.Pause();
                    pausePosition = mediaPlayer.Position;
                    isPaused = true;
                }
            }
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            tempPosition = appStyle.MusicIndex;
            if (appStyle.PlayBtnPosition == 1) appStyle.SetPauseButtonImg();
            if (appStyle.ShufflePosition == 1)
            {
                appStyle.MusicIndex = randomTrack.Next(0, appStyle.MusicFiles.Length);
                while (tempPosition == appStyle.MusicIndex) 
                    appStyle.MusicIndex = randomTrack.Next(0, appStyle.MusicFiles.Length);
                appStyle.ChangeMusicName();
            }
            else 
            {
                appStyle.MusicIndex += 1;
                if (appStyle.MusicIndex == appStyle.MusicFiles.Length) appStyle.MusicIndex = 0;
                appStyle.ChangeMusicName();
            }
            mediaPlayer.Open(new Uri(appStyle.musicFiles[appStyle.MusicIndex]));
          
            mediaPlayer.Play();

        }


        private void BackBtn_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if ((DateTime.Now - lastClickTime).TotalMilliseconds < 300)
            {
                if (appStyle.PlayBtnPosition == 1) appStyle.SetPauseButtonImg();
                if (appStyle.MusicIndex == 0) appStyle.MusicIndex = appStyle.MusicFiles.Length;
                appStyle.MusicIndex -= 1;
                appStyle.ChangeMusicName();
                mediaPlayer.Open(new Uri(appStyle.musicFiles[appStyle.MusicIndex]));
                mediaPlayer.Play();
            }
            else
            {
                mediaPlayer.Position = TimeSpan.Zero;
            }
            lastClickTime = DateTime.Now;
        }
        private void MediaPlayer_MediaEnded(object sender, EventArgs e)
        {
            tempPosition = appStyle.MusicIndex;
            if (appStyle.RepeatOnePosition == 0 && appStyle.ShufflePosition == 1)
            {
                appStyle.MusicIndex = randomTrack.Next(0,appStyle.MusicFiles.Length);
                while (tempPosition == appStyle.MusicIndex)
                    appStyle.MusicIndex = randomTrack.Next(0, appStyle.MusicFiles.Length);
                appStyle.ChangeMusicName();
            }
            else if (appStyle.RepeatOnePosition == 0 && appStyle.ShufflePosition == 0)
            {
                appStyle.MusicIndex += 1;
                if (appStyle.MusicIndex == appStyle.MusicFiles.Length) appStyle.MusicIndex = 0;
                appStyle.ChangeMusicName();
            }
            mediaPlayer.Open(new Uri(appStyle.musicFiles[appStyle.MusicIndex]));
            mediaPlayer.Play();
        }

        private void RepeatBtn_Click(object sender, RoutedEventArgs e)
        {
            if (appStyle.RepeatOnePosition == 0)
            {
                appStyle.RepeatOnePosition = 1;
                appStyle.SetRepeatOneButtonImg();
            }
            else
            {
                appStyle.RepeatOnePosition = 0;
                appStyle.SetRepeatButtonImg();
            }
        }

        private void RandomBtn_Click(object sender, RoutedEventArgs e)
        {
            if (appStyle.ShufflePosition == 0)
            {
                appStyle.ShufflePosition = 1;
                appStyle.SetShuffleButtonImg();
            }
            else
            {
                appStyle.ShufflePosition = 0;
                appStyle.SetNotShuffleButtonImg();
            }
        }

        private void repeat10_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Position -= TimeSpan.FromSeconds(10);
        }

        private void skip10_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Position += TimeSpan.FromSeconds(10);
        }

        private void volumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mediaPlayer.Volume = volumeSlider.Value / 1000;
        }


        private void volumeSlider_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Slider slider = (Slider)sender;

            Point mousePos = e.GetPosition(slider);
            double ratio = mousePos.X / slider.ActualWidth;
            double newValue = ratio * (slider.Maximum - slider.Minimum) + slider.Minimum;

            slider.Value = newValue;
        }
    }
}
