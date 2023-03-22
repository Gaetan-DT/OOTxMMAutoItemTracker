using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace MajoraAutoItemTracker
{
    public partial class Form1 : Form
    {
        MemoryListener mMemoryListener = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Log("Attaching to modloader");
            ModLoader64Wrapper modLoader64Wrapper = new ModLoader64Wrapper();
            Log("Initializing thread");
            mMemoryListener = new MemoryListener(modLoader64Wrapper, CallBackMemoryListener);
            mMemoryListener.start();
            Log("Thread started");
        }

        private void BtnStopListener_Click(object sender, EventArgs e)
        {
            mMemoryListener.stop();
            mMemoryListener = null;
            Log("Thread Stoped");
        }

        private void CallBackMemoryListener(String message)
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (message != null)
                    this.Log(message);
                Log("Link transformation: " + mMemoryListener.getMemoryDump().currentLinkTransformation);
            });
            // Open a Stream and decode a PNG image

            /** Stream ImgOcarinaSource = new FileStream("mm_items_mono.png", FileMode.Open, FileAccess.Read, FileShare.Read);
            PngBitmapDecoder decoder = new PngBitmapDecoder(ImgOcarinaSource, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            BitmapSource bitmapSource = decoder.Frames[0];

            // Draw the Image
            Image myImage = new Bitmap();
            myImage.Source = bitmapSource;
            myImage.Stretch = Stretch.None;
            myImage.Margin = new Thickness(20); **/
            //Debug.WriteLine(System.IO.Directory.GetCurrentDirectory());

            Image PngOcarina = Image.FromFile(@"..\..\UI\Itemicons\mm_items_mono.png");

            /** Bitmap bitmapOcarina = new Bitmap(PngOcarina);
            Image croppedOcarina = bitmapOcarina.Clone(new Rectangle(0, 0, 42, 42), bitmapOcarina.PixelFormat);
            this.ImgOcarina.Image = croppedOcarina;            

            Bitmap bitmapBow = new Bitmap(PngOcarina);
            Image croppedBow = bitmapBow.Clone(new Rectangle(42, 0, 42, 42), bitmapBow.PixelFormat);
            this.ImgBow.Image = croppedBow;

            Bitmap bitmapFireArrow = new Bitmap(PngOcarina);
            Image croppedFireArrow = bitmapFireArrow.Clone(new Rectangle(84, 0, 42, 42), bitmapFireArrow.PixelFormat);
            this.ImgFireArrow.Image = croppedFireArrow;

            Bitmap bitmapIceArrow = new Bitmap(PngOcarina);
            Image croppedIceArrow = bitmapIceArrow.Clone(new Rectangle(126, 0, 42, 42), bitmapIceArrow.PixelFormat);
            this.ImgIceArrow.Image = croppedIceArrow;

            Bitmap bitmapLightArrow = new Bitmap(PngOcarina);
            Image croppedLightArrow = bitmapLightArrow.Clone(new Rectangle(168, 0, 42, 42), bitmapLightArrow.PixelFormat);
            this.ImgLightArrow.Image = croppedLightArrow;

            Bitmap bitmapScrubTrade = new Bitmap(PngOcarina);
            Image croppedScrubTrade = bitmapScrubTrade.Clone(new Rectangle(336, 84, 42, 42), bitmapScrubTrade.PixelFormat);
            this.ImgScrubTrade.Image = croppedScrubTrade;

            Bitmap bitmapBomb = new Bitmap(PngOcarina);
            Image croppedBomb = bitmapBomb.Clone(new Rectangle(252, 0, 42, 42),bitmapBomb.PixelFormat);
            this.ImgBomb.Image = croppedBomb;

            Bitmap bitmapBombchu = new Bitmap(PngOcarina);
            Image croppedBombchu = bitmapBombchu.Clone(new Rectangle(294, 0, 42, 42), bitmapBombchu.PixelFormat);
            this.ImgBombchu.Image = croppedBombchu;

            Bitmap bitmapStick = new Bitmap(PngOcarina);
            Image croppedStick = bitmapStick.Clone(new Rectangle(336, 0 , 42, 42),bitmapStick.PixelFormat);
            this.ImgStick.Image = croppedStick;

            Bitmap bitmapNuts = new Bitmap(PngOcarina);
            Image croppedNuts = bitmapNuts.Clone(new Rectangle(378, 0, 42, 42), bitmapNuts.PixelFormat);
            this.ImgNuts.Image = croppedNuts;

            Bitmap bitmapBeans = new Bitmap(PngOcarina);
            Image croppedBeans = bitmapBeans.Clone(new Rectangle(420,0, 42, 42),bitmapNuts.PixelFormat);
            this.ImgBeans.Image = croppedBeans;

            Bitmap bitmapKey = new Bitmap(PngOcarina);
            Image croppedKey = bitmapKey.Clone(new Rectangle(546, 84, 42, 42), bitmapKey.PixelFormat);
            this.ImgKeyMama.Image = croppedKey; **/
        }

        private void Log(String message)
        {            
            tboxDebug.AppendText(message + "\r\n");
            Debug.WriteLine(message);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void ImgBeans_Click(object sender, EventArgs e)
        {

        }
    }
}
