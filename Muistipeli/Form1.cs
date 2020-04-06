using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muistipeli
{
    public partial class Form1 : Form
    {
        int usedtime = 0, valitut = 0, nayttoaika = -1;
        int taso = 5, parejajaljella = 0, siirrot = 0;
        int[,] kuvat = new int[5, 6];
        int[,] nayttokuvat = new int[5, 6];
        int[,] valittuna = new int[2, 2];
        int[,] tasot = new int[,] { { 3, 2 }, { 2, 4 }, { 3, 4 }, { 4, 4 }, { 5, 4 }, { 5, 6 } };
        MyPicBox[,] kuvaloota = new MyPicBox[5, 6];
        System.Media.SoundPlayer sp1 = new System.Media.SoundPlayer();
        System.Media.SoundPlayer sp2 = new System.Media.SoundPlayer();
        System.Media.SoundPlayer sp3 = new System.Media.SoundPlayer();
        Random r = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++) 
            {
                for (int j = 0; j < 6; j++) 
                { // luodaan 5*6 pictureboxia eli kuvalootaa
                    kuvaloota[i, j] = new MyPicBox(i, j);
                    kuvaloota[i, j].Location = new System.Drawing.Point(10 + j * 90, 90 + i * 90);
                    kuvaloota[i, j].Size = new System.Drawing.Size(80, 80);
                    kuvaloota[i, j].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    kuvaloota[i, j].Click += new System.EventHandler(kuvaloota_Click);
                    this.Controls.Add(kuvaloota[i, j]);
                }
            }

            sekoitaKuvat(); // sekoitetaan kuvat kuvalootiin
            sp1.SoundLocation = "blip.wav"; // ladataan ääniefektit
            sp2.SoundLocation = "nono.wav";
            sp3.SoundLocation = "done.wav";
            btnRight.Enabled = false; // aloitetaan suurimmalta tasolta, joten ei sallita isompaa tasoa
            naytaKuvat(); // näytetään kuvalootien kuvat
        }

        private void kuvaloota_Click(object sender, EventArgs e)
        {
            MyPicBox pb = (MyPicBox)sender;

            if ((nayttoaika == -1) && ((pb.y < tasot[taso, 0]) && (pb.x < tasot[taso, 1]))) // jos ollaan pelialueella ja väärän parin odotusaika loppu
            { // sallitaan kuvien klikkailu
                if (nayttokuvat[pb.y, pb.x] == 0) // jos klikattu suljettua kuvalootaa
                {
                    valittuna[valitut, 0] = pb.y; // talletetaan klikatun kuvan paikka
                    valittuna[valitut, 1] = pb.x;
                    kuvaloota[pb.y, pb.x].Image = imageList1.Images[kuvat[pb.y, pb.x]]; // näytetään kuva
                    nayttokuvat[pb.y, pb.x] = kuvat[pb.y, pb.x]; // merkataan kuvaloota avatuksi
                    valitut++; // valittuja kuvia on yksi enemmän

                    if (valitut == 2) // jos kaksi kuvaa valittuna
                    {
                        siirrot++; // siirtojen määrä on yhtä suurempi

                        if (kuvat[valittuna[0, 0], valittuna[0, 1]] == kuvat[valittuna[1, 0], valittuna[1, 1]]) // jos löytyi pari
                        {
                            parejajaljella--; // yksi pari vähemmän
                            try
                            {
                                sp1.Play(); // soitetaan "pari löytyi" -ääni
                            }
                            catch { }

                            if (parejajaljella == 0) // jos kaikki parit löydetty
                                sp3.Play(); // soitetaan "kaikki parit löydetty" -ääni
                        }
                        else // kuvat olivat eriparia
                        {
                            nayttoaika = 10; // asetetaan sekunnin näyttöviive, jonka aikana ei voi klikkailla
                            try
                            {
                                sp2.Play(); // soitetaan "väärä pari" -ääni
                            }
                            catch { }
                        }

                        valitut = 0; // valittuja kuvia ei ole
                    }
                }
            }
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            btnRight.Enabled = true; // sallitaan tason lisäys
            taso--; // helpommalle tasolle
            if (taso < 1) // jos ollaan tasolla 0
                btnLeft.Enabled = false; // ei enää alaspäin

            sekoitaKuvat(); // tämän tason alustukset
            naytaKuvat();
            siirrot = 0;
            usedtime = 0;
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            btnLeft.Enabled = true; // sallitaan tason vähennys
            taso++; // vaikeammalle tasolle
            if (taso > 4) // jos ollaan tasolla 5
                btnRight.Enabled = false; // ei enää ylöspäin

            sekoitaKuvat(); // tämän tason alustukset
            naytaKuvat();
            siirrot = 0;
            usedtime = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int min, sec;

            if (parejajaljella > 0) // jos kaikki parit eivät vielä löytyneet
                usedtime++; // lisätään aikaa

            min = usedtime / 600;
            sec = (usedtime - min * 600) / 10;
            lblAika.Text = "Aika: " + min + ":" + sec.ToString("00");
            lblSiirrot.Text = "Siirtoja: " + siirrot;

            if (nayttoaika >= 0) // jos väärän parin laskuria jäljellä
                nayttoaika--; // vähennetään laskuria

            if (nayttoaika == 0) // jos väärää paria näytetty tarpeeksi
            { // piilotetaan väärän parin kuvat
                kuvaloota[valittuna[0, 0], valittuna[0, 1]].Image = imageList1.Images[0];
                nayttokuvat[valittuna[0, 0], valittuna[0, 1]] = 0;
                kuvaloota[valittuna[1, 0], valittuna[1, 1]].Image = imageList1.Images[0];
                nayttokuvat[valittuna[1, 0], valittuna[1, 1]] = 0;
            }
        }

        private void naytaKuvat()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if ((i < tasot[taso, 0]) && (j < tasot[taso, 1])) // jos kuva pelialueella
                        kuvaloota[i, j].Image = imageList1.Images[nayttokuvat[i, j]]; // näytetään kuvalootassa kuva tai suljettu luukku
                    else // jos kuva ei pelialueella
                        kuvaloota[i, j].Image = null; // ei näytetä kuvalootassa mitään
                }
            }

            lblTaso.Text = "Taso: " + (taso + 1);
        }

        private void sekoitaKuvat()
        {
            parejajaljella = tasot[taso, 0] * tasot[taso, 1] / 2; // merkitään pareja jäljellä = luukkujen määrä / 2

            for (int i = 0; i < tasot[taso, 0]; i++) 
            {
                for (int j = 0; j < tasot[taso, 1]; j++) 
                {
                    kuvat[i, j] = (i * 6 + j) / 2 + 1; // laitetaan pelialueella oleviin peräkkäisiin kuvalootiin parit
                    nayttokuvat[i, j] = 0; // merkitään kuvalootan luukku suljetuksi
                }
            }

            for (int i = 0; i < 100; i++) // sekoitetaan pelialueen kuvalootien kuvat sata kertaa
            {
                int tmp, x1, x2, y1, y2;

                y1 = r.Next(0, tasot[taso, 0]);
                x1 = r.Next(0, tasot[taso, 1]);
                y2 = r.Next(0, tasot[taso, 0]);
                x2 = r.Next(0, tasot[taso, 1]);
                tmp = kuvat[y1, x1];
                kuvat[y1, x1] = kuvat[y2, x2];
                kuvat[y2, x2] = tmp;
            }
        }
    }

    public class MyPicBox : PictureBox
    {
        public int x, y;

        public MyPicBox(int i, int j)
        {
            y = i;
            x = j;
        }
    }
}
