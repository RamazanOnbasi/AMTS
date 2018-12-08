using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace AMTS
{
    public partial class YoneticiGirisi : Form
    {
        private Form Secim;
        private XmlDocument girisBilgileri;
        private Boolean kapa;
        private Boolean izniVar;

        public YoneticiGirisi(Form Secim)
        {
            InitializeComponent();
            kapa = true;
            izniVar = false;
            this.Secim = Secim;
            girisBilgileri = new XmlDocument();
            girisBilgileri.Load("Kullaniciler.xml");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(XmlNode node in girisBilgileri.DocumentElement)
            {
                string ad = node.Attributes[0].InnerText;
                string sifre = node.Attributes[1].InnerText;

                if (yoneticiAdi.Text == ad && parola.Text == sifre)
                    izniVar = true;
            }

            if (izniVar)
            {
                YoneticiMDI yoneticiMDI = new YoneticiMDI(Secim);
                Close();
                yoneticiMDI.Show();
            }

            else
                MessageBox.Show("Adınızı veya parolanızı yanlış girdiniz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            kapa = false;
            Close();
        }

        void YoneticiGirisi_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!kapa)
                Secim.Show();

            else if (kapa && !izniVar)
                Secim.Close();
        }
    }
}
