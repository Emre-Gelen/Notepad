using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uyg3Notepad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.Show();
        }

        private void durumÇubuğuToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            statusStrip1.Visible = durumÇubuğuToolStripMenuItem.Checked;
        }

        private void sözcükKaydırToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox1.WordWrap = sözcükKaydırToolStripMenuItem.Checked;
        }

        private void geriAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void kesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void kopyalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void yapıştırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        bool acikDosyaVarmi = false;
        bool degisiklikVarmi = false;
        string acikDosyaAdi = "";

        public void dosyaAcmaIslemleri()
        {
          
            OpenFileDialog od = new OpenFileDialog();
            DialogResult basilan = od.ShowDialog();
            if (basilan == DialogResult.OK)
            {
                richTextBox1.Clear();
                acikDosyaAdi = od.FileName;
                acikDosyaVarmi = true;
                richTextBox1.LoadFile(acikDosyaAdi, RichTextBoxStreamType.PlainText);
                degisiklikVarmi = false;
            }
        }
        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (acikDosyaVarmi == false)
            {
                if (degisiklikVarmi == false)
                    dosyaAcmaIslemleri();
                else
                {
                    DialogResult basilan = MessageBox.Show("Kaydedilsin mi?", "Notepad", MessageBoxButtons.YesNoCancel);
                    if (basilan == DialogResult.No)
                        dosyaAcmaIslemleri();
                    else if (basilan == DialogResult.Yes)
                    {
                        SaveFileDialog sd = new SaveFileDialog();
                        DialogResult basilan2 = sd.ShowDialog();
                        if (basilan2 == DialogResult.OK)
                        {
                            richTextBox1.SaveFile(sd.FileName, RichTextBoxStreamType.PlainText);
                            dosyaAcmaIslemleri();
                        }
                    }
                }
            }
            else//acikdosyavarmi=true
            {
                if (degisiklikVarmi == false)
                    dosyaAcmaIslemleri();
                else
                {
                    DialogResult basilan = MessageBox.Show("Kaydedilsin mi?", "Notepad", MessageBoxButtons.YesNoCancel);
                    if (basilan == DialogResult.No)
                        dosyaAcmaIslemleri();
                    else if (basilan == DialogResult.Yes)
                    {
                        richTextBox1.SaveFile(acikDosyaAdi, RichTextBoxStreamType.PlainText);
                        dosyaAcmaIslemleri();
                    }


                }
            }//else if
        }//metot

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            degisiklikVarmi = true;
        }

        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (acikDosyaVarmi == true)
            {
                if (degisiklikVarmi == false)
                {
                    richTextBox1.Clear();
                    degisiklikVarmi = false;
                }
                else
                {
                    DialogResult basılan = MessageBox.Show("Kaydedilsin mi?", "Notepad", MessageBoxButtons.YesNoCancel);
                    if (basılan == DialogResult.Yes)
                    {
                        richTextBox1.SaveFile(acikDosyaAdi, RichTextBoxStreamType.PlainText);
                        richTextBox1.Clear();
                        degisiklikVarmi = false;
                    }
                    else if (basılan == DialogResult.No)
                    {
                        richTextBox1.Clear();
                    }
                }//else
            }//if
            else
            {
                if (richTextBox1.Text == "")
                {
                    degisiklikVarmi = false;
                }
                if (degisiklikVarmi == false)
                {
                    richTextBox1.Clear();
                    degisiklikVarmi=false;
                }
                else
                {
                    DialogResult basılan = MessageBox.Show("Kaydedilsin mi?", "Notepad", MessageBoxButtons.YesNoCancel);
                    if (basılan == DialogResult.Yes)
                    {
                        SaveFileDialog sd = new SaveFileDialog();
                        sd.DefaultExt = ".txt";
                        DialogResult basılan2 = sd.ShowDialog();
                        degisiklikVarmi = false;
                        if (basılan2 == DialogResult.OK)
                        {
                            richTextBox1.SaveFile(sd.FileName, RichTextBoxStreamType.PlainText);
                            richTextBox1.Clear();
                            degisiklikVarmi = false;
                        }
                    }
                    else if(basılan ==DialogResult.No)
                    {
                        richTextBox1.Clear();
                        degisiklikVarmi = false;
                    }
                }
            }
        }//metot

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (acikDosyaVarmi == true)
            {
                if (degisiklikVarmi == true)
                {
                    richTextBox1.SaveFile(acikDosyaAdi, RichTextBoxStreamType.PlainText);
                }
            }
            else
            {
                if (degisiklikVarmi == true)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.DefaultExt = ".txt";
                    DialogResult basılan = sfd.ShowDialog();
                    if (basılan == DialogResult.OK)
                    {
                        richTextBox1.SaveFile(sfd.FileName, RichTextBoxStreamType.PlainText);
                        acikDosyaAdi = sfd.FileName;
                        acikDosyaVarmi = true;
                    }
                }
            }
        }
        private void farklıKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.DefaultExt = ".txt";
            DialogResult basılan = sd.ShowDialog();
            if (basılan == DialogResult.OK)
            {
                richTextBox1.SaveFile(sd.FileName, RichTextBoxStreamType.PlainText);
                acikDosyaVarmi = true;
                acikDosyaAdi = sd.FileName;
            }
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (acikDosyaVarmi == true)
            {
                if (degisiklikVarmi == true)
                {
                    DialogResult basılan = MessageBox.Show("Kaydedilsin mi?", "Notepad", MessageBoxButtons.YesNoCancel);
                    if (basılan == DialogResult.Yes)
                    {
                        richTextBox1.SaveFile(acikDosyaAdi, RichTextBoxStreamType.PlainText);
                        Close();
                    }
                    else if (basılan == DialogResult.No)
                    {
                        Close();
                    }
                }
                else
                {
                    Close();
                }
            }
            else
            {
                if (degisiklikVarmi == true)
                {
                    DialogResult basılan = MessageBox.Show("Kaydedilsin mi?", "Notepad", MessageBoxButtons.YesNoCancel);
                    if (basılan == DialogResult.Yes)
                    {
                        SaveFileDialog sd = new SaveFileDialog();
                        sd.DefaultExt = ".txt";
                        DialogResult basılan2 = sd.ShowDialog();
                        if (basılan2 == DialogResult.OK)
                        {
                            richTextBox1.SaveFile(sd.FileName, RichTextBoxStreamType.PlainText);
                            Close();
                        }
                    }//if
                    else if (basılan == DialogResult.No)
                    {
                        Close();
                    }
                }
                else
                    Close();
            }
               
        }

        private void bulToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void yazıTipiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            DialogResult basılan = fd.ShowDialog();
            if (basılan == DialogResult.OK)
            {
                Font font = fd.Font;
                richTextBox1.Font = font;
            }
        }

        private void yardımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.bing.com/search?q=windows+10%E2%80%99da+not+defteriyle+ilgili+yard%C4%B1m+alma&filters=guid:%224466414-tr-dia%22%20lang:%22tr%22&form=T00032&ocid=HelpPane-BingIA");
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
    }//class
}//namespace
