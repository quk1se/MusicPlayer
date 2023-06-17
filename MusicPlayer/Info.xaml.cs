using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MusicPlayer
{
    /// <summary>
    /// Логика взаимодействия для Info.xaml
    /// </summary>
    public partial class Info : Window
    {
        public Info()
        {
            InitializeComponent();
            Title = "Help information";
            Icon = new BitmapImage(new Uri(@"D:\\itstep\\winforms\\MusicPLayer\\MusicPLayer\\btnsImg\\info.ico", UriKind.RelativeOrAbsolute));
            SetImages("folder",folderInfoImg);
            SetText("This button will help you select the folder you want to listen to music from, the default is the project folder.", folderInfo);
            SetImages("repeat", repeatImg);
            SetText("This button allows you to loop the same song if the button shows the number 1. Otherwise, all songs just go in a circle.", repeatInfo);
            SetImages("shuffle", shuffleImg);
            SetText("This button allows you to listen to songs in random order, if the button is on, it is highlighted in bolder.", shuffleInfo);
            SetImages("skip10", skip10Img);
            SetText("This button skips the song 10 seconds ahead.", skip10Info);
            SetImages("repeat10", repeat10Img);
            SetText("This button skips the song 10 seconds back.", repeat10Info);
        }

        public void SetImages(string fileName, Image img)
        {
            Image image = new Image();
            image.Source = new BitmapImage(new Uri($@"D:\\itstep\\winforms\\MusicPLayer\\MusicPLayer\\btnsImg\\{fileName}.png", UriKind.RelativeOrAbsolute));
            image.Stretch = Stretch.Uniform;
            RenderOptions.SetBitmapScalingMode(image, BitmapScalingMode.HighQuality);

            img.Source = image.Source;
        }
        public void SetText(string text, TextBlock txtBlock)
        {
            txtBlock.Text = text;
            txtBlock.FontFamily = new FontFamily("Arial Black");
            txtBlock.FontSize = 14;
        }
    }
}
