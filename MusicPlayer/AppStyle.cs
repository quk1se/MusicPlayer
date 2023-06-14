using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Controls;
using System.IO;
using System.Windows;
using System.IO.Packaging;

namespace MusicPlayer
{
    internal class AppStyle
    {
        public MainWindow parent;
        ImageBrush background = new ImageBrush(new BitmapImage(new Uri("background.png", UriKind.Relative)));
        

        private int playBtnPosition = 0;
        private int musicIndex = 0;
        private int repeatOnePosition = 0;
        private int shufflePosition = 0;
        public string[] musicFiles = Directory.GetFiles(@"D:\\itstep\\winforms\\MusicPLayer\\MusicPLayer\\music");

        public int PlayBtnPosition
        {
            set { playBtnPosition = value; }
            get { return playBtnPosition; }
        }
        public string[] MusicFiles
        {
            get { return musicFiles; }
            set { musicFiles = value; }
        }
        public int MusicIndex
        {
            get { return musicIndex; }
            set { musicIndex = value; }
        }
        public int RepeatOnePosition
        {
            set { repeatOnePosition = value; }
            get { return repeatOnePosition; }
        }
        public int ShufflePosition
        {
            set { shufflePosition = value; }
            get { return shufflePosition; }
        }

        public AppStyle(MainWindow parent)
        {
            this.parent = parent;
        }
        public void SetBackground()
        {
            background.Stretch = Stretch.UniformToFill;
            parent.Background = background;
        }
        public void SetPlayButtonImg()
        {
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(@"D:\\itstep\\winforms\\MusicPLayer\\MusicPLayer\\btnsImg\\playBtn.png"));
            RenderOptions.SetBitmapScalingMode(image, BitmapScalingMode.HighQuality);
            RenderOptions.SetEdgeMode(image, EdgeMode.Aliased);
            parent.PlayBtn.Content = image;
            PlayBtnPosition = 1;
        }
        public void SetPauseButtonImg()
        {
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(@"D:\\itstep\\winforms\\MusicPLayer\\MusicPLayer\\btnsImg\\pauseBtn.png"));
            RenderOptions.SetBitmapScalingMode(image, BitmapScalingMode.HighQuality);
            RenderOptions.SetEdgeMode(image, EdgeMode.Aliased);
            parent.PlayBtn.Content = image;
            PlayBtnPosition = 0;
        }
        public void SetBackButtonImg()
        {
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(@"D:\\itstep\\winforms\\MusicPLayer\\MusicPLayer\\btnsImg\\back.png"));
            RenderOptions.SetBitmapScalingMode(image, BitmapScalingMode.HighQuality);
            RenderOptions.SetEdgeMode(image, EdgeMode.Aliased);
            parent.BackBtn.Content = image;
        }
        public void SetNextButtonImg()
        {
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(@"D:\\itstep\\winforms\\MusicPLayer\\MusicPLayer\\btnsImg\\next.png"));
            RenderOptions.SetBitmapScalingMode(image, BitmapScalingMode.HighQuality);
            RenderOptions.SetEdgeMode(image, EdgeMode.Aliased);
            parent.NextBtn.Content = image;
        }
        public void SetRepeatButtonImg()
        {
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(@"D:\\itstep\\winforms\\MusicPLayer\\MusicPLayer\\btnsImg\\repeat.png"));
            RenderOptions.SetBitmapScalingMode(image, BitmapScalingMode.HighQuality);
            RenderOptions.SetEdgeMode(image, EdgeMode.Aliased);
            parent.RepeatBtn.Content = image;
        }
        public void SetRepeatOneButtonImg()
        {
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(@"D:\\itstep\\winforms\\MusicPLayer\\MusicPLayer\\btnsImg\\repeatOne.png"));
            RenderOptions.SetBitmapScalingMode(image, BitmapScalingMode.HighQuality);
            RenderOptions.SetEdgeMode(image, EdgeMode.Aliased);
            parent.RepeatBtn.Content = image;
        }
        public void SetShuffleButtonImg()
        {
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(@"D:\\itstep\\winforms\\MusicPLayer\\MusicPLayer\\btnsImg\\shuffle.png"));
            RenderOptions.SetBitmapScalingMode(image, BitmapScalingMode.HighQuality);
            RenderOptions.SetEdgeMode(image, EdgeMode.Aliased);
            parent.RandomBtn.Content = image;
        }
        public void SetNotShuffleButtonImg()
        {
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(@"D:\\itstep\\winforms\\MusicPLayer\\MusicPLayer\\btnsImg\\shuffleNon.png"));
            RenderOptions.SetBitmapScalingMode(image, BitmapScalingMode.HighQuality);
            RenderOptions.SetEdgeMode(image, EdgeMode.Aliased);
            parent.RandomBtn.Content = image;
        }
        public void SetSkip10BtnImg()
        {
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(@"D:\\itstep\\winforms\\MusicPLayer\\MusicPLayer\\btnsImg\\skip10.png"));
            RenderOptions.SetBitmapScalingMode(image, BitmapScalingMode.HighQuality);
            RenderOptions.SetEdgeMode(image, EdgeMode.Aliased);
            parent.skip10.Content = image;
        }
        public void SetRepeat10BtnImg()
        {
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(@"D:\\itstep\\winforms\\MusicPLayer\\MusicPLayer\\btnsImg\\repeat10.png"));
            RenderOptions.SetBitmapScalingMode(image, BitmapScalingMode.HighQuality);
            RenderOptions.SetEdgeMode(image, EdgeMode.Aliased);
            parent.repeat10.Content = image;
        }
        public void ChangeMusicName()
        {
            parent.MusicName.Text = Path.GetFileNameWithoutExtension(musicFiles[musicIndex]);
        }

    }
}
