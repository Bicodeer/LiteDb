using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiteDb_Ex01.Entities;
using LiteDB;
using System.Threading;

namespace LiteDb_Ex01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            verileriListele();
        }
        private List<JOB> verileriGetir()
        {
        
            var liste = new List<JOB>();
            using (var db = new LiteDatabase(@"Veritabani.db"))
            {
                var personel = db.GetCollection<JOB>("Personel");
                foreach (JOB item in personel.FindAll())
                {
                    liste.Add(item);
                }
            }
            return liste;
          
        }

        
        public void verileriListele()
        {
            if (dataGridView1.DataSource != null)
            {
                dataGridView1.DataSource = null;
            }

            dataGridView1.DataSource = verileriGetir();
            dataGridView1.Refresh();
        }
        private void button1_Click(object sender, EventArgs e)
        {/*
            using (var db = new LiteDatabase(@"Veritabani.db"))
            {
                var ekle = db.GetCollection<JOB>("Personel");
                var ekleIs = new JOB
                {
                    islem_adi = comboBox1.Text,
                    islem_icerik = comboBox2.Text,
                    islem_saat = maskedTextBox1.Text,
                    durum = false,

                };
                ekle.Insert(ekleIs);
                verileriListele();
            }*/
            verileriListele();
            backgroundWorker1.RunWorkerAsync();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var db = new LiteDatabase(@"Veritabani.db"))
            {
                var personeller = db.GetCollection<JOB>("Personel");
                personeller.Delete(x => x.Id == Convert.ToInt32(textBox1.Text));
                verileriListele();               
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            maskedTextBox1.Text = "";
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
            if (comboBox1.SelectedIndex==0) 
            {
                if (comboBox2.SelectedIndex == 0)
                {
                    Thread thr = new Thread(toplama00);
                    thr.Name = "1.Thread Çalışıyor.";
                    thr.Start();
                }
                else if (comboBox2.SelectedIndex == 1)
                {
                    Thread thr = new Thread(toplama01);
                    thr.Name = "2.Thread Çalışıyor.";
                    thr.Start();                  
                }else if(comboBox2.SelectedIndex == 2)
                {
                    Thread thr = new Thread(toplama02);
                    thr.Name = "3.Thread Çalışıyor.";
                    thr.Start();
                }
            }
            else
            {
                if (comboBox2.SelectedIndex == 0)
                {
                    Thread thr = new Thread(toplama00);
                    thr.Name = "1.Thread Çalışıyor.";
                    thr.Start();
                }
                else if (comboBox2.SelectedIndex == 1)
                {
                    Thread thr = new Thread(toplama01);
                    thr.Name = "2.Thread Çalışıyor.";
                    thr.Start();
                }
                else if (comboBox2.SelectedIndex == 2)
                {
                    Thread thr = new Thread(toplama02);
                    thr.Name = "3.Thread Çalışıyor.";
                    thr.Start();
                }
            }
        }
        public void toplama00()
        {
            try
            {
                lock (this)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        int a = 4, b = 120, sonuc = 0;
                        sonuc = a + b;
                        listBox1.Items.Add(Thread.CurrentThread.Name + "Toplama İşlemi Çalışıyor.." + sonuc + DateTime.Now.ToString("HH:mm:ss"));
                        Thread.Sleep(2000);
                    }
                }                             
                using (var db = new LiteDatabase(@"Veritabani.db"))
                {
                    var ekle = db.GetCollection<JOB>("Personel");
                    var ekleIs = new JOB
                    {
                        islem_adi = comboBox1.Text,
                        islem_icerik = comboBox2.Text,
                        islem_saat = maskedTextBox1.Text,
                        durum = true,

                    };
                    ekle.Insert(ekleIs);
                    verileriListele();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                using (var db = new LiteDatabase(@"Veritabani.db"))
                {
                    var ekle = db.GetCollection<JOB>("Personel");
                    var ekleIs = new JOB
                    {
                        islem_adi = comboBox1.Text,
                        islem_icerik = comboBox2.Text,
                        islem_saat = maskedTextBox1.Text,
                        durum = false,

                    };
                    ekle.Insert(ekleIs);
                    verileriListele();
                }
            }
            

        }
        public void toplama01()
        { 
            try
            {
                lock (this)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        int a = 4, b = 120, sonuc = 0;
                        sonuc = a + b;
                        listBox1.Items.Add(Thread.CurrentThread.Name + "Toplama İşlemi Çalışıyor.." + sonuc + DateTime.Now.ToString("HH:mm:ss"));
                        Thread.Sleep(60 * 1000);
                    }
                }
                    using (var db = new LiteDatabase(@"Veritabani.db"))
                    {
                        var ekle = db.GetCollection<JOB>("Personel");
                        var ekleIs = new JOB
                        {
                            islem_adi = comboBox1.Text,
                            islem_icerik = comboBox2.Text,
                            islem_saat = maskedTextBox1.Text,
                            durum = true,

                        };
                        ekle.Insert(ekleIs);
                        verileriListele();
                    }                               
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                using (var db = new LiteDatabase(@"Veritabani.db"))
                {
                    var ekle = db.GetCollection<JOB>("Personel");
                    var ekleIs = new JOB
                    {
                        islem_adi = comboBox1.Text,
                        islem_icerik = comboBox2.Text,
                        islem_saat = maskedTextBox1.Text,
                        durum = false,

                    };
                    ekle.Insert(ekleIs);
                    verileriListele();
                }
            }

        }
        public void toplama02()
        {
            try
            {
                lock (this)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        int a = 4, b = 120, sonuc = 0;
                        sonuc = a + b;
                        listBox3.Items.Add(Thread.CurrentThread.Name + "Toplama İşlemi Çalışıyor.." + sonuc + DateTime.Now.ToString("HH:mm:ss"));
                        Thread.Sleep(4 * 60 * 1000);
                    }
                }
                using (var db = new LiteDatabase(@"Veritabani.db"))
                {
                    var ekle = db.GetCollection<JOB>("Personel");
                    var ekleIs = new JOB
                    {
                        islem_adi = comboBox1.Text,
                        islem_icerik = comboBox2.Text,
                        islem_saat = maskedTextBox1.Text,
                        durum = true,

                    };
                    ekle.Insert(ekleIs);
                    verileriListele();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                using (var db = new LiteDatabase(@"Veritabani.db"))
                {
                    var ekle = db.GetCollection<JOB>("Personel");
                    var ekleIs = new JOB
                    {
                        islem_adi = comboBox1.Text,
                        islem_icerik = comboBox2.Text,
                        islem_saat = maskedTextBox1.Text,
                        durum = false,

                    };
                    ekle.Insert(ekleIs);
                    verileriListele();
                }
            }
        }
        public void carpma00()
        {
            try
            {
                lock (this)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        int a = 4, b = 120, sonuc = 0;
                        sonuc = a * b;
                        listBox1.Items.Add(Thread.CurrentThread.Name + "Çarpma İşlemi Çalışıyor.." + sonuc + DateTime.Now.ToString("HH:mm:ss"));
                        Thread.Sleep(5000);
                    }
                }
                using (var db = new LiteDatabase(@"Veritabani.db"))
                {
                    var ekle = db.GetCollection<JOB>("Personel");
                    var ekleIs = new JOB
                    {
                        islem_adi = comboBox1.Text,
                        islem_icerik = comboBox2.Text,
                        islem_saat = maskedTextBox1.Text,
                        durum = true,

                    };
                    ekle.Insert(ekleIs);
                    verileriListele();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                using (var db = new LiteDatabase(@"Veritabani.db"))
                {
                    var ekle = db.GetCollection<JOB>("Personel");
                    var ekleIs = new JOB
                    {
                        islem_adi = comboBox1.Text,
                        islem_icerik = comboBox2.Text,
                        islem_saat = maskedTextBox1.Text,
                        durum = false,

                    };
                    ekle.Insert(ekleIs);
                    verileriListele();
                }
            }            
        }
        public void carpma01()
        {
            try
            {
                lock (this)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        int a = 4, b = 120, sonuc = 0;
                        sonuc = a * b;
                        listBox2.Items.Add(Thread.CurrentThread.Name + "Çarpma İşlemi Çalışıyor.." + sonuc + DateTime.Now.ToString("HH:mm:ss"));
                        Thread.Sleep(20 * 1000);
                    }
                }
                using (var db = new LiteDatabase(@"Veritabani.db"))
                {
                    var ekle = db.GetCollection<JOB>("Personel");
                    var ekleIs = new JOB
                    {
                        islem_adi = comboBox1.Text,
                        islem_icerik = comboBox2.Text,
                        islem_saat = maskedTextBox1.Text,
                        durum = true,

                    };
                    ekle.Insert(ekleIs);
                    verileriListele();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                using (var db = new LiteDatabase(@"Veritabani.db"))
                {
                    var ekle = db.GetCollection<JOB>("Personel");
                    var ekleIs = new JOB
                    {
                        islem_adi = comboBox1.Text,
                        islem_icerik = comboBox2.Text,
                        islem_saat = maskedTextBox1.Text,
                        durum = false,

                    };
                    ekle.Insert(ekleIs);
                    verileriListele();
                }
            }
            
        }
        public void carpma02()
        {
            try
            {
                lock (this)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        int a = 4, b = 120, sonuc = 0;
                        sonuc = a * b;
                        listBox3.Items.Add(Thread.CurrentThread.Name + "Çarpma İşlemi Çalışıyor.." + sonuc + DateTime.Now.ToString("HH:mm:ss"));
                        Thread.Sleep(60 * 1000);
                    }
                }
                using (var db = new LiteDatabase(@"Veritabani.db"))
                {
                    var ekle = db.GetCollection<JOB>("Personel");
                    var ekleIs = new JOB
                    {
                        islem_adi = comboBox1.Text,
                        islem_icerik = comboBox2.Text,
                        islem_saat = maskedTextBox1.Text,
                        durum = true,

                    };
                    ekle.Insert(ekleIs);
                    verileriListele();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                using (var db = new LiteDatabase(@"Veritabani.db"))
                {
                    var ekle = db.GetCollection<JOB>("Personel");
                    var ekleIs = new JOB
                    {
                        islem_adi = comboBox1.Text,
                        islem_icerik = comboBox2.Text,
                        islem_saat = maskedTextBox1.Text,
                        durum = false,

                    };
                    ekle.Insert(ekleIs);
                    verileriListele();
                }
            }                   
        }

        //private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    MessageBox.Show("BakgroundWoker Durduruldu..");
        //}
    }
}
