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

        private string selectedFolder = @"D:\\itstep\\winforms\\MusicPLayer\\MusicPLayer\\music";
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
        public string SelectedFolder
        {
            set { selectedFolder = value; }
            get { return selectedFolder; }
        }
        public void SetButtonImg(string fileName,Button btnName)
        {
            Image image = new Image();
            image.Source = new BitmapImage(new Uri($@"D:\\itstep\\winforms\\MusicPLayer\\MusicPLayer\\btnsImg\\{fileName}.png"));
            RenderOptions.SetBitmapScalingMode(image, BitmapScalingMode.HighQuality);
            RenderOptions.SetEdgeMode(image, EdgeMode.Aliased);
            btnName.Content = image;
        }
        public void SetImages(string fileName, Image img)
        {
            Image image = new Image();
            image.Source = new BitmapImage(new Uri($@"D:\\itstep\\winforms\\MusicPLayer\\MusicPLayer\\btnsImg\\{fileName}.png", UriKind.RelativeOrAbsolute));
            image.Stretch = Stretch.Uniform;
            RenderOptions.SetBitmapScalingMode(image, BitmapScalingMode.HighQuality);

            img.Source = image.Source;
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
        public void ChangeMusicName()
        {
            try
            {
                parent.MusicName.Text = Path.GetFileNameWithoutExtension(musicFiles[musicIndex]);
            }
            catch (System.IndexOutOfRangeException)
            {
                MessageBox.Show("This folder is empty!");
                musicFiles = Directory.GetFiles(@"D:\\itstep\\winforms\\MusicPLayer\\MusicPLayer\\music");
                musicIndex = 0;
                parent.MusicName.Text = Path.GetFileNameWithoutExtension(musicFiles[musicIndex]);
            }
        }
        public void SetNewFolder()
        {
            MusicFiles = Directory.GetFiles(selectedFolder);
        }

    }
}
