using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RawInput_dll;
using System.IO;

namespace RawInputApp
{
    public partial class Form1 : Form
    {
        private readonly RawInput _rawinput;
        public Form1()
        {
            _rawinput = new RawInput(Handle, true);
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _rawinput.KeyPressed += _rawinput_KeyPressed;
        }
        private void _rawinput_KeyPressed(object sender, RawInputEventArg e)
        {
            if (e.KeyPressEvent.KeyPressState == "MAKE" & e.KeyPressEvent.VKeyName.ToString() != "LSHIFT")
            {
                Getrawinput.CardAsync = Getrawinput.CardAsync + e.KeyPressEvent.VKeyName.ToString();
            }
            
            if (Getrawinput.CardAsync != null & e.KeyPressEvent.VKeyName.ToString() != "BREAK") 
            {
                if (Getrawinput.CardAsync.Length >= 5)
                {
                    Getrawinput.GetCardinfo(Getrawinput.CardAsync);
                    ShowPicture(Getrawinput.FilenameAsync);
                }
            }
        }
        private void ShowPicture (string filename)
        {
            if (File.Exists(filename))
            {
                Invoke(new MethodInvoker(() =>
                {
                    pictureBox1.Image = new Bitmap(filename);
                }
                ));
            }
            else
            {
                pictureBox1.Image = null;
            }
        }


    }
}