using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics; 
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using System.Data.SQLite;

namespace TLENREADER_NET
{
    public partial class TlenReaderNET : Form
    {
        public TlenReaderNET()
        {
            InitializeComponent();
        }
        public struct DATChat
        {
            public Double time;
            public Int32 flags;
            public Int32 size;
            public Int32 ID;
            public Int32 unknown;
            public String msg;
        };

        public struct IDXChat
        {
            public String name;
            public String network;
            public Double time;
            public Int32 flags;
            public Int32 offset;
            public Int32 count;
            public Int32 ID_r;
        };


        public struct idx_rozm
        {
            public Int32 id_rozm;
            public Double czas;
            public String name;
            public Int32 offset;
            public Int16 size_sms;
        };

        public struct dat_rozm
        {
            public String time;
            public String login;
            public String msg;
        };

        public struct SMSidx
        {
            public String tel;
            public Int32 unknown;
            public Double time;
            public Int32 flags;
            public Int32 offset;
            public Int16 size;
            public Int16 recvd;
            public Int32 unknown2;
        };
    

        public idx_rozm[] indeks = new idx_rozm[1];
        //public dat_rozm[] rozmowy = new dat_rozm[1];

        public FileStream plk_idx_strm = null;
        public FileStream plk_dat_strm = null;
        public FileStream sms_idx_strm = null;
        public FileStream sms_dat_strm = null;
        public DATChat cht;
        public IDXChat cht_idx;
        public SMSidx sms_idx;
        bool del_chat = false;

        //System.Data.SQLite.SQLiteConnection sqlconn;
        //System.Data.SQLite.SQLiteDataAdapter sqlda;
        //System.Data.DataSet ds;






        private void Czytaj_plik(Boolean del)
        {
            indeks[0].id_rozm = 0;
            indeks[0].czas = 0;
            indeks[0].name = "nieznany";

            Array.Resize(ref indeks, 1);            

            if (del == true)
            {
                if (plk_dat_strm != null)
                {

                    Czytaj_dat(false, true, null);
                    string text;
                    int x = 0;
                    for (x = 1; x <= indeks.GetUpperBound(0); x++)
                    {
                        string str1 = "", str2 = "";
                        str1 = indeks[x].name;
                        str2 = Oblicz_date(indeks[x].czas);
                        text = indeks[x].id_rozm.ToString();

                        ListViewItem LVI_L = new ListViewItem(text);
                        LVI_L.SubItems.Add(str1);
                        LVI_L.SubItems.Add(str2);
                        listView_ListaRozm.Items.Add(LVI_L);
                    }

                }
                else
                {
                    MessageBox.Show("Wystąpił nieznany błąd - strumień dat = null !!!");
                }
            }
            else if (del == false)
            {
                if (plk_dat_strm != null)
                {
                    Czytaj_idx(true, true);
                    //Czytaj_dat(false, true, null);

                    string text;
                    int x = 0;
                    for (x = 1; x <= indeks.GetUpperBound(0); x++)
                    {
                        string str1 = "", str2 = "";
                        str1 = indeks[x].name;
                        str2 = Oblicz_date(indeks[x].czas);

                        text = indeks[x].id_rozm.ToString();

                        ListViewItem LVI_L = new ListViewItem(text);
                        LVI_L.SubItems.Add(str1);
                        LVI_L.SubItems.Add(str2);
                        listView_ListaRozm.Items.Add(LVI_L);
                    }
                }


            }

        }

        private void zamknijArchiwumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (plk_idx_strm != null)
            {
                plk_idx_strm.Close();
            }
            if (plk_dat_strm != null)
            {
                plk_dat_strm.Close();
            }
            if (sms_dat_strm != null)
            {
                sms_dat_strm.Close();
            }
            if (sms_idx_strm != null)
            {
                sms_idx_strm.Close();
            }
            listView_ListaRozm.Items.Clear();
            richTextBox_Wypowiedź.Clear();

            Array.Resize(ref indeks, 1);
            //Array.Resize(ref rozmowy, 1);
            exportujArchiwumToolStripMenuItem.Enabled = false;
            this.eksportujCałeArchiwumToolStripMenuItem.Enabled = false;
            this.eksportujCałeArchSMSToolStripMenuItem.Enabled = false;
            del_chat = false;
            //contextMenuStrip1.Enabled = false;
        }

        private void oProgramieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            O_Programie About = new O_Programie();
            About.ShowDialog();
        }

        private int Przesz_tab(int id)
        {
            int x = 0;
            for (x = 0; x < indeks.Length; x++)
            {
                if (indeks[x].id_rozm == id)
                {
                    return 1;
                }


            }
            return 0;

        }

        private void Czytaj_dat(Boolean idx, Boolean init, Char[] name)
        {
            int chk = 0;
            

            Encoding ascii = Encoding.GetEncoding(1250);
            Encoding unicode = Encoding.Unicode;
            Byte[] asciibyte;
            Byte[] unibyte;
            

            Int32 curNum = 0;
            if (init == false)
            {
                richTextBox_Wypowiedź.Clear();
                String curSel = "0";

                ListView.SelectedListViewItemCollection LV_SEL = listView_ListaRozm.SelectedItems;
                foreach (ListViewItem ITM in LV_SEL)
                {

                    curSel = ITM.Text;
                }


                curNum = Convert.ToInt32(curSel);
            }


            BinaryReader binr = new BinaryReader(plk_dat_strm, ascii);
            plk_dat_strm.Seek(0, SeekOrigin.Begin);
            long offset = 0;
            if (init == false)
            {
                offset = indeks[curNum].offset;
            }
            while (offset < plk_dat_strm.Length)
            {
                plk_dat_strm.Seek(offset, SeekOrigin.Begin);
                cht.time = binr.ReadDouble();
                cht.flags = binr.ReadInt32();
                cht.size = binr.ReadInt32();
                cht.ID = binr.ReadInt32();
                cht.unknown = binr.ReadInt32();
                

                if (init == false)
                {
                    String kto = "";


                    if (idx == false)
                    {

                        if (cht.ID == curNum)
                        {
                            asciibyte = binr.ReadBytes(cht.size);
                            unibyte = Encoding.Convert(ascii, unicode, asciibyte);
                            cht.msg = unicode.GetString(unibyte);

                            //if ((cht.flags == 1088618497) || (cht.flags == 1179649))
                            if (Test_JA(cht.flags) == true)
                            {
                                kto = "JA";
                            }
                            else
                            {
                                kto = "NIE-JA";
                            }
                            //kto = "Nieznany".ToCharArray(); 
                            
                            if (richTextBox_Wypowiedź.Text == "")
                            {
                                richTextBox_Wypowiedź.Text = "->" + kto + " " + Oblicz_date(cht.time) + "\n" + cht.msg;
                            }
                            else
                            {
                                richTextBox_Wypowiedź.Text = richTextBox_Wypowiedź.Text + "\n" + "\n" + "->" + kto + " " + Oblicz_date(cht.time) + "\n" + cht.msg;
                            }

                        }
                    }
                    else if (idx == true)
                    {
                        if (cht.ID == curNum)
                        {
                            asciibyte = binr.ReadBytes(cht.size);
                            unibyte = Encoding.Convert(ascii, unicode, asciibyte);
                            cht.msg = unicode.GetString(unibyte);
                            //if (cht.flags == 1088618497)
                            if (Test_JA(cht.flags) == true)
                            {
                                kto = "JA";

                            }
                            else
                            {
                                int x = 0;
                                for (x = 0; x < indeks.Length; x++)
                                {
                                    if (cht.ID == indeks[x].id_rozm)
                                    {
                                        kto = indeks[x].name;
                                    }
                                }
                            }
                            if (richTextBox_Wypowiedź.Text == "")
                            {
                                richTextBox_Wypowiedź.Text = "->" + kto + " " + Oblicz_date(cht.time) + "\n" + cht.msg;
                            }
                            else
                            {
                                richTextBox_Wypowiedź.Text = richTextBox_Wypowiedź.Text + "\n" + "\n" + "->" + kto + " " + Oblicz_date(cht.time) + "\n" + cht.msg;
                            }



                        }
                    }
                }
                else if (init == true)
                {
                    if (idx == false)
                    {

                        chk = Przesz_tab(cht.ID);
                        if (chk == 0)
                        {
                            Array.Resize(ref indeks, indeks.Length + 1);

                            indeks[indeks.GetUpperBound(0)].id_rozm = cht.ID;
                            indeks[indeks.GetUpperBound(0)].name = "nieznany";
                            indeks[indeks.GetUpperBound(0)].czas = cht.time;
                            indeks[indeks.GetUpperBound(0)].offset = Convert.ToInt32(offset);
                        }
                    }
                }
                offset = offset + 24 + cht.size;


            }
            
        }

        private void Czytaj_idx(Boolean idx, Boolean init)
        {

            int chk = 0;
            Char[] exclude = { ' ', '\0' };

            Encoding ascii = Encoding.GetEncoding(1250);
            Encoding unicode = Encoding.Unicode;

            Byte[] asciibyte;
            Byte[] unibyte;


            BinaryReader bin_idx = new BinaryReader(plk_idx_strm, ascii);
            plk_idx_strm.Seek(0, SeekOrigin.Begin);
            long offset = 0;
            while (offset < plk_idx_strm.Length)
            {
                plk_idx_strm.Seek(offset, SeekOrigin.Begin);

                asciibyte = bin_idx.ReadBytes(26);
                unibyte = Encoding.Convert(ascii, unicode, asciibyte);
                cht_idx.name = unicode.GetString(unibyte);



                asciibyte = bin_idx.ReadBytes(6);
                unibyte = Encoding.Convert(ascii, unicode, asciibyte);
                cht_idx.network = unicode.GetString(unibyte);



                cht_idx.time = bin_idx.ReadDouble();
                cht_idx.flags = bin_idx.ReadInt32();
                cht_idx.offset = bin_idx.ReadInt32();
                cht_idx.count = bin_idx.ReadInt32();
                cht_idx.ID_r = bin_idx.ReadInt32();

                if (init == true)
                {
                    chk = Przesz_tab(cht_idx.ID_r);
                    if (chk == 0)
                    {
                        Array.Resize(ref indeks, indeks.Length + 1);

                        indeks[indeks.GetUpperBound(0)].id_rozm = cht_idx.ID_r;
                        indeks[indeks.GetUpperBound(0)].name = cht_idx.name.Trim(exclude);
                        indeks[indeks.GetUpperBound(0)].czas = cht_idx.time;
                        indeks[indeks.GetUpperBound(0)].offset = cht_idx.offset;
                    }
                }

                offset = offset + 56;

            }


        }

        private string Konwer(Char[] chr)
        {
            StringBuilder sb = new StringBuilder();
            String str = "";
            sb.Append(chr);
            str = sb.ToString();
            sb.Remove(0, sb.Length);
            return str;

        }

        private void listView_ListaRozm_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox_Wypowiedź.Clear();
            if (plk_dat_strm != null)
            {
                if (plk_idx_strm == null)
                {
                    Czytaj_dat(false, false, null);
                }
                else
                {
                    Czytaj_dat(true, false, null);
                }
            }
            else if (sms_idx_strm != null && sms_dat_strm != null)
            {
                Czytaj_SMS(false);

            }
            else
            {
                MessageBox.Show("Wystąpił błąd - strumień pliku = null!!");
            }
        }

        private string Oblicz_date(double Bd)
        {

            string ret = "";
            DateTime start, temp;
            start = DateTime.Parse("1970-01-01 00:00:00 GMT");
            Double tmp;
            if (Bd != 0)
            {
                tmp = Math.Round((Bd - 25569.0) * 86400);


                TimeSpan interval = new TimeSpan(0, 0, 0, Convert.ToInt32(tmp), 0);

                temp = start.Add(interval);

                ret = temp.ToString();
            }
            else if (Bd == 0)
            {
                ret = "nieustalony";
            }
            return ret;
        }

        private void usunięteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog FBD = new FolderBrowserDialog();
            FBD.ShowNewFolderButton = false;

            String foldername, path_dat;
            DialogResult result;
            result = FBD.ShowDialog();
            if (result == DialogResult.OK)
            {
                foldername = FBD.SelectedPath;
                path_dat = foldername + "\\chats.dat";


                if (File.Exists(path_dat))
                {


                    if (plk_dat_strm == null)
                    {
                        plk_dat_strm = File.OpenRead(path_dat);
                    }
                    else if (plk_dat_strm != null)
                    {
                        plk_dat_strm.Close();
                        plk_dat_strm = File.OpenRead(path_dat);


                    }

                }

                Czytaj_plik(true);
                exportujArchiwumToolStripMenuItem.Enabled = true;
                contextMenuStrip1.Enabled = true;
                this.eksportujCałeArchiwumToolStripMenuItem.Enabled = true;
                del_chat = true;


            }
        }

        private void nieusunięteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog FBD = new FolderBrowserDialog();
            FBD.ShowNewFolderButton = false;

            String foldername, path_idx, path_dat;
            DialogResult result;
            result = FBD.ShowDialog();
            if (result == DialogResult.OK)
            {
                foldername = FBD.SelectedPath;
                path_dat = foldername + "\\chats.dat";
                path_idx = foldername + "\\chats.idx";

                if (File.Exists(path_idx))
                {

                    if (plk_idx_strm == null)
                    {

                        plk_idx_strm = File.OpenRead(path_idx);
                    }
                    else if (plk_idx_strm != null)
                    {
                        plk_idx_strm.Close();
                        plk_idx_strm = File.OpenRead(path_idx);
                    }

                }


                if (File.Exists(path_dat))
                {


                    if (plk_dat_strm == null)
                    {
                        plk_dat_strm = File.OpenRead(path_dat);

                    }
                    else if (plk_dat_strm != null)
                    {
                        plk_dat_strm.Close();
                        plk_dat_strm = File.OpenRead(path_dat);


                    }
                }

                Czytaj_plik(false);
                exportujArchiwumToolStripMenuItem.Enabled = true;
                contextMenuStrip1.Enabled = true;
                this.eksportujCałeArchiwumToolStripMenuItem.Enabled = true;
                del_chat = false;

            }
        }

        private Boolean Test_JA(int flag)
        {
            string test, tmp;

            test = flag.ToString();
            tmp = test[test.Length - 1].ToString();
            if ((tmp == "1") || (tmp == "3") || (tmp == "5") || (tmp == "7") || (tmp == "9"))
            {
                return true;
            }
            else return false;


        }

        private void koniecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Exportuj_rozm_Click(object sender, EventArgs e)
        {
            StreamWriter rozm;
            Int32 csv_sel = 0;
            String file_nam, tekst, file_ext;
            String[] text_rozm = new String[1];
            StringBuilder sb = new StringBuilder();

            Encoding ascii = Encoding.GetEncoding(1250);
            Encoding unicode = Encoding.Unicode;
            Byte[] asciibyte;
            Byte[] unibyte;

            Int32 curNum = 0;
            String curSel = "0";
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "txt files (*.txt)|*.txt|csv files (*.csv)|*.csv";
            sfd.CheckFileExists = false;
            sfd.CheckPathExists = true;
            sfd.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                file_nam = sfd.FileName;
                file_ext = file_nam[file_nam.Length - 3].ToString();
                file_ext = file_ext + file_nam[file_nam.Length - 2].ToString();
                file_ext = file_ext + file_nam[file_nam.Length - 1].ToString();

                if (file_ext == "csv")
                {
                    if (MessageBox.Show("Czy dane mają być rozdzielone przecinkiem ?. Jeśli nie, zostaną rozdzielone tabulatorem.", "Tlen Reader Net", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        csv_sel = 1; // comma
                    }
                    else
                    {
                        csv_sel = 2; // tab
                    }
                }
                else if (file_ext == "txt")
                {
                    csv_sel = 0; // txt
                }

                ListView.SelectedListViewItemCollection LV_SEL = listView_ListaRozm.SelectedItems;
                foreach (ListViewItem ITM in LV_SEL)
                {

                    curSel = ITM.Text;
                }


                curNum = Convert.ToInt32(curSel);


                if (plk_dat_strm != null)
                {


                    BinaryReader binr = new BinaryReader(plk_dat_strm, ascii);
                    plk_dat_strm.Seek(0, SeekOrigin.Begin);
                    long offset = 0;
                    while (offset < plk_dat_strm.Length)
                    {
                        plk_dat_strm.Seek(offset, SeekOrigin.Begin);

                        cht.time = binr.ReadDouble();
                        cht.flags = binr.ReadInt32();
                        cht.size = binr.ReadInt32();
                        cht.ID = binr.ReadInt32();
                        cht.unknown = binr.ReadInt32();
                        asciibyte = binr.ReadBytes(cht.size);
                        unibyte = Encoding.Convert(ascii, unicode, asciibyte);
                        cht.msg = unicode.GetString(unibyte);

                        Char[] kto = new Char[26];

                        if (cht.ID == curNum)
                        {
                            int x = 0;
                            for (x = 0; x < indeks.Length; x++)
                            {
                                if (cht.ID == indeks[x].id_rozm)
                                {
                                    if (csv_sel == 0)
                                    {
                                        if (Test_JA(cht.flags) == false)
                                        {
                                            sb.Append(indeks[x].name);
                                        }
                                        else
                                        {
                                            sb.Append("JA");

                                        }
                                        sb.Append(" - ");
                                        sb.Append(Oblicz_date(cht.time));
                                        sb.Append(" - ");
                                        sb.Append(cht.msg);
                                        tekst = sb.ToString();
                                        sb.Remove(0, sb.Length);
                                        Array.Resize(ref text_rozm, text_rozm.Length + 1);
                                        text_rozm[text_rozm.GetUpperBound(0)] = tekst;
                                    }
                                    else if (csv_sel == 1)
                                    {
                                        sb.Append("\"");
                                        if (Test_JA(cht.flags) == false)
                                        {
                                            sb.Append(indeks[x].name);
                                        }
                                        else
                                        {
                                            sb.Append("JA");

                                        }
                                        sb.Append("\"");
                                        sb.Append(",");
                                        sb.Append("\"");
                                        sb.Append(Oblicz_date(cht.time));
                                        sb.Append("\"");
                                        sb.Append(",");
                                        sb.Append("\"");
                                        sb.Append(cht.msg);
                                        sb.Append("\"");
                                        tekst = sb.ToString();
                                        sb.Remove(0, sb.Length);
                                        Array.Resize(ref text_rozm, text_rozm.Length + 1);
                                        text_rozm[text_rozm.GetUpperBound(0)] = tekst;
                                     }
                                    else if (csv_sel == 2)
                                    {
                                        sb.Append("\"");
                                        if (Test_JA(cht.flags) == false)
                                        {
                                            sb.Append(indeks[x].name);
                                        }
                                        else
                                        {
                                            sb.Append("JA");

                                        }
                                        sb.Append("\"");
                                        sb.Append("\t");
                                        sb.Append("\"");
                                        sb.Append(Oblicz_date(cht.time));
                                        sb.Append("\"");
                                        sb.Append("\t");
                                        sb.Append("\"");
                                        sb.Append(cht.msg);
                                        sb.Append("\"");
                                        tekst = sb.ToString();
                                        sb.Remove(0, sb.Length);
                                        Array.Resize(ref text_rozm, text_rozm.Length + 1);
                                        text_rozm[text_rozm.GetUpperBound(0)] = tekst;

                                    }
                                    else
                                    {
                                        return;
                                    }

                                }
                            }
                        }

                        offset = offset + 24 + cht.size;
                    }
                   
                    for (Int32 i = 0; i < indeks.Length; i++)
                    {
                        if (indeks[i].id_rozm == curNum)
                        { 
                            rozm = File.CreateText(file_nam);
                            for (Int32 z = 0; z < text_rozm.Length; z++)
                            {
                                rozm.WriteLine(text_rozm[z]);
                            }
                            rozm.Close();
                        }
                    }
                    
                    
                }
            }

        }

       

        private void exportujArchiwumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Int32 csv_sel = 0;
            StreamWriter rozm;
            String file_nam;
            String file_ext;
            String tekst;
            String[] text_rozm = new String[1];
            StringBuilder sb = new StringBuilder();


            Encoding ascii = Encoding.GetEncoding(1250);
            Encoding unicode = Encoding.Unicode;
            Byte[] asciibyte;
            Byte[] unibyte;

            Int32 curNum = 0;
            String curSel = "0";

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "txt files (*.txt)|*.txt|csv files (*.csv)|*.csv";
            sfd.CheckFileExists = false;
            sfd.CheckPathExists = true;
            sfd.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                file_nam = sfd.FileName;
                file_ext = file_nam[file_nam.Length - 3].ToString();
                file_ext = file_ext + file_nam[file_nam.Length - 2].ToString();
                file_ext = file_ext + file_nam[file_nam.Length - 1].ToString();

                if (file_ext == "csv")
                {
                    if (MessageBox.Show("Czy dane mają być rozdzielone przecinkiem ?. Jeśli nie, zostaną rozdzielone tabulatorem.", "Tlen Reader Net", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        csv_sel = 1; // comma
                    }
                    else
                    {
                        csv_sel = 2; // tab
                    }
                }
                else if (file_ext == "txt")
                {
                    csv_sel = 0; // txt
                }

                ListView.SelectedListViewItemCollection LV_SEL = listView_ListaRozm.SelectedItems;
                foreach (ListViewItem ITM in LV_SEL)
                {

                    curSel = ITM.Text;
                }


                curNum = Convert.ToInt32(curSel);


                if (plk_dat_strm != null)
                {


                    BinaryReader binr = new BinaryReader(plk_dat_strm, ascii);
                    plk_dat_strm.Seek(0, SeekOrigin.Begin);
                    long offset = 0;
                    while (offset < plk_dat_strm.Length)
                    {
                        plk_dat_strm.Seek(offset, SeekOrigin.Begin);

                        cht.time = binr.ReadDouble();
                        cht.flags = binr.ReadInt32();
                        cht.size = binr.ReadInt32();
                        cht.ID = binr.ReadInt32();
                        cht.unknown = binr.ReadInt32();
                        asciibyte = binr.ReadBytes(cht.size);
                        unibyte = Encoding.Convert(ascii, unicode, asciibyte);

                        cht.msg = unicode.GetString(unibyte);

                        Char[] kto = new Char[26];

                        if (cht.ID == curNum)
                        {
                            int x = 0;
                            for (x = 0; x < indeks.Length; x++)
                            {
                                if (cht.ID == indeks[x].id_rozm)
                                {
                                    if (csv_sel == 0)
                                    {
                                        if (Test_JA(cht.flags) == false)
                                        {
                                            sb.Append(indeks[x].name);
                                        }
                                        else
                                        {
                                            sb.Append("JA");

                                        }
                                        sb.Append(" - ");
                                        sb.Append(Oblicz_date(cht.time));
                                        sb.Append(" - ");
                                        sb.Append(cht.msg);
                                        tekst = sb.ToString();
                                        sb.Remove(0, sb.Length);
                                        Array.Resize(ref text_rozm, text_rozm.Length + 1);
                                        text_rozm[text_rozm.GetUpperBound(0)] = tekst;
                                    }
                                    else if (csv_sel == 1)
                                    {
                                        sb.Append("\"");
                                        if (Test_JA(cht.flags) == false)
                                        {
                                            sb.Append(indeks[x].name);
                                        }
                                        else
                                        {
                                            sb.Append("JA");

                                        }
                                        sb.Append("\"");
                                        sb.Append(",");
                                        sb.Append("\"");
                                        sb.Append(Oblicz_date(cht.time));
                                        sb.Append("\"");
                                        sb.Append(",");
                                        sb.Append("\"");
                                        sb.Append(cht.msg);
                                        sb.Append("\"");
                                        tekst = sb.ToString();
                                        sb.Remove(0, sb.Length);
                                        Array.Resize(ref text_rozm, text_rozm.Length + 1);
                                        text_rozm[text_rozm.GetUpperBound(0)] = tekst;
                                    }
                                    else if (csv_sel == 2)
                                    {
                                        sb.Append("\"");
                                        if (Test_JA(cht.flags) == false)
                                        {
                                            sb.Append(indeks[x].name);
                                        }
                                        else
                                        {
                                            sb.Append("JA");

                                        }
                                        sb.Append("\"");
                                        sb.Append("\t");
                                        sb.Append("\"");
                                        sb.Append(Oblicz_date(cht.time));
                                        sb.Append("\"");
                                        sb.Append("\t");
                                        sb.Append("\"");
                                        sb.Append(cht.msg);
                                        sb.Append("\"");
                                        tekst = sb.ToString();
                                        sb.Remove(0, sb.Length);
                                        Array.Resize(ref text_rozm, text_rozm.Length + 1);
                                        text_rozm[text_rozm.GetUpperBound(0)] = tekst;
                                    }
                                    else
                                    {
                                        return;
                                    }

                                }
                            }
                        }

                        offset = offset + 24 + cht.size;
                    }
                    for (Int32 i = 0; i < indeks.Length; i++)
                    {
                        if (indeks[i].id_rozm == curNum)
                        {
                            
                            rozm = File.CreateText(file_nam);
                            for (Int32 z = 0; z < text_rozm.Length; z++)
                            {
                                rozm.WriteLine(text_rozm[z]);
                            }
                            rozm.Close();
                        }
                    }

                }
            }
        }

        private void TlenReaderNET_Load(object sender, EventArgs e)
        {
            String myPath = Environment.CurrentDirectory;
            Process ps = new Process();
            const int ERROR_FILE_NOT_FOUND = 2;
            const int ERROR_ACCESS_DENIED = 5;
            try
            {
                ps.StartInfo.FileName = myPath + "\\" + "MK_AUTOUPDATE.exe";
                ps.Start();
            }
            catch (Win32Exception ex)
            {
                if (ex.NativeErrorCode == ERROR_FILE_NOT_FOUND)
                {
                    MessageBox.Show(ex.Message + ". Sprawdź ścieżkę.", "Tlen Reader Net", MessageBoxButtons.OK);
                }

                else if (ex.NativeErrorCode == ERROR_ACCESS_DENIED)
                {

                    MessageBox.Show(ex.Message + ". Nie masz uprawnień aby uruchomić updatera.", "Tlen Reader Net", MessageBoxButtons.OK);
                }
            }
        }

        private void eksportujCałeArchiwumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (plk_dat_strm != null)
            {


                long offset = 0;
                Encoding ascii = Encoding.GetEncoding(1250);
                Encoding unicode = Encoding.Unicode;
                Byte[] asciibyte;
                Byte[] unibyte;

                StreamWriter rozm;
                Int32 csv_sel = 0;
                String file_nam, tekst, file_ext;
                String[] text_rozm = new String[1];
                StringBuilder sb = new StringBuilder();
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "txt files (*.txt)|*.txt|csv files (*.csv)|*.csv";
                sfd.CheckFileExists = false;
                sfd.CheckPathExists = true;
                sfd.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    file_nam = sfd.FileName;
                    file_ext = file_nam[file_nam.Length - 3].ToString();
                    file_ext = file_ext + file_nam[file_nam.Length - 2].ToString();
                    file_ext = file_ext + file_nam[file_nam.Length - 1].ToString();
                    if (file_ext == "csv")
                    {
                        if (MessageBox.Show("Czy dane mają być rozdzielone przecinkiem ?. Jeśli nie, zostaną rozdzielone tabulatorem.", "Tlen Reader Net", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            csv_sel = 1; // comma
                        }
                        else
                        {
                            csv_sel = 2; // tab
                        }
                    }
                    else if (file_ext == "txt")
                    {
                        csv_sel = 0; // txt
                    }


                    BinaryReader binr = new BinaryReader(plk_dat_strm, ascii);
                    plk_dat_strm.Seek(0, SeekOrigin.Begin);

                    for (int x = 1; x < indeks.Length; x++)
                    {
                        offset = indeks[x].offset;
                        while (offset < plk_dat_strm.Length)
                        {
                            plk_dat_strm.Seek(offset, SeekOrigin.Begin);

                            cht.time = binr.ReadDouble();
                            cht.flags = binr.ReadInt32();
                            cht.size = binr.ReadInt32();
                            cht.ID = binr.ReadInt32();
                            cht.unknown = binr.ReadInt32();
                            asciibyte = binr.ReadBytes(cht.size);
                            unibyte = Encoding.Convert(ascii, unicode, asciibyte);
                            cht.msg = unicode.GetString(unibyte);

                            if (indeks[x].id_rozm == cht.ID)
                            {
                                if (csv_sel == 0)
                                {
                                    if (Test_JA(cht.flags) == false)
                                    {
                                        sb.Append(indeks[x].name);
                                    }
                                    else
                                    {
                                        sb.Append("JA");

                                    }
                                    sb.Append(" - ");
                                    sb.Append(Oblicz_date(cht.time));
                                    sb.Append(" - ");
                                    sb.Append(cht.msg);
                                    tekst = sb.ToString();
                                    sb.Remove(0, sb.Length);
                                    Array.Resize(ref text_rozm, text_rozm.Length + 1);
                                    text_rozm[text_rozm.GetUpperBound(0)] = tekst;
                                }
                                else if (csv_sel == 1)
                                {
                                    
                                    sb.Append("\"");
                                    if (Test_JA(cht.flags) == false)
                                    {
                                        sb.Append(indeks[x].name);
                                    }
                                    else
                                    {
                                        sb.Append("JA");

                                    }
                                    sb.Append("\"");
                                    sb.Append(",");
                                    sb.Append("\"");
                                    sb.Append(Oblicz_date(cht.time));
                                    sb.Append("\"");
                                    sb.Append(",");
                                    sb.Append("\"");
                                    sb.Append(cht.msg);
                                    sb.Append("\"");
                                    tekst = sb.ToString();
                                    sb.Remove(0, sb.Length);
                                    Array.Resize(ref text_rozm, text_rozm.Length + 1);
                                    text_rozm[text_rozm.GetUpperBound(0)] = tekst;
                                }
                                    
                                else if (csv_sel == 2)
                                {
                                    sb.Append("\"");
                                    if (Test_JA(cht.flags) == false)
                                    {
                                        sb.Append(indeks[x].name);
                                    }
                                    else
                                    {
                                        sb.Append("JA");

                                    }
                                    sb.Append("\"");
                                    sb.Append("\t");
                                    sb.Append("\"");
                                    sb.Append(Oblicz_date(cht.time));
                                    sb.Append("\"");
                                    sb.Append("\t");
                                    sb.Append("\"");
                                    sb.Append(cht.msg);
                                    sb.Append("\"");
                                    tekst = sb.ToString();
                                    sb.Remove(0, sb.Length);
                                    Array.Resize(ref text_rozm, text_rozm.Length + 1);
                                    text_rozm[text_rozm.GetUpperBound(0)] = tekst;
                                }                                                                  
                                else
                                {
                                    return;
                                }

                            }

                            offset = offset + 24 + cht.size;
                        }

                    }
                    
                    rozm = File.CreateText(file_nam);
                    for (Int32 z = 0; z < text_rozm.Length; z++)
                    {
                        rozm.WriteLine(text_rozm[z]);
                    }
                    rozm.Close();
                }





            }

        }

        private void otwórzArchSMSTlen6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            FBD.ShowNewFolderButton = false;

            String foldername, pathsms_idx, pathsms_dat;
            DialogResult result;
            result = FBD.ShowDialog();
            if (result == DialogResult.OK)
            {
                foldername = FBD.SelectedPath;
                pathsms_dat = foldername + "\\sms.dat";
                pathsms_idx = foldername + "\\sms.idx";

                if (File.Exists(pathsms_idx))
                {

                    if (sms_idx_strm == null)
                    {

                        sms_idx_strm = File.OpenRead(pathsms_idx);
                    }
                    else if (sms_idx_strm != null)
                    {
                        sms_idx_strm.Close();
                        sms_idx_strm = File.OpenRead(pathsms_idx);
                    }

                }


                if (File.Exists(pathsms_dat))
                {


                    if (sms_dat_strm == null)
                    {
                        sms_dat_strm = File.OpenRead(pathsms_dat);

                    }
                    else if (sms_dat_strm != null)
                    {
                        sms_dat_strm.Close();
                        sms_dat_strm = File.OpenRead(pathsms_dat);


                    }
                }
                Czytaj_SMS(true);
                eksportujCałeArchSMSToolStripMenuItem.Enabled = true;

            }
        }
        private void Czytaj_SMS(Boolean init)
        {
            indeks[0].id_rozm = 0;
            indeks[0].czas = 0;
            indeks[0].name = "nieznany";

            Encoding unicode = Encoding.Unicode;
            Encoding ascii = Encoding.GetEncoding(1250);

            Byte[] asciibyte;
            Byte[] unibyte;

            if (init == true)
            {

                Array.Resize(ref indeks, 1);

                if (sms_dat_strm != null)
                {
                    if (sms_idx_strm != null)
                    {
                        BinaryReader binr = new BinaryReader(sms_idx_strm, Encoding.GetEncoding(1250));
                        sms_idx_strm.Seek(0, SeekOrigin.Begin);
                        for (long offset = 0; offset < sms_idx_strm.Length; )
                        {
                            sms_idx_strm.Seek(offset, SeekOrigin.Begin);
                            
                            asciibyte = binr.ReadBytes(12);
                            unibyte = Encoding.Convert(ascii, unicode, asciibyte);
                            sms_idx.tel = unicode.GetString(unibyte);

                            sms_idx.unknown = binr.ReadInt32();
                            sms_idx.time = binr.ReadDouble();
                            sms_idx.flags = binr.ReadInt32();
                            sms_idx.offset = binr.ReadInt32();
                            sms_idx.size = binr.ReadInt16();
                            sms_idx.recvd = binr.ReadInt16();
                            sms_idx.unknown2 = binr.ReadInt32();

                            if (!((sms_idx.time == 0.0) && (sms_idx.size == -1))) // sprawdź czy nie usunięte
                            {

                                Array.Resize(ref indeks, indeks.Length + 1);
                                indeks[indeks.GetUpperBound(0)].name = sms_idx.tel;
                                indeks[indeks.GetUpperBound(0)].czas = sms_idx.time;
                                indeks[indeks.GetUpperBound(0)].offset = sms_idx.offset;
                                indeks[indeks.GetUpperBound(0)].size_sms = sms_idx.size;

                                ListViewItem LVI = new ListViewItem("0");
                                LVI.SubItems.Add(indeks[indeks.GetUpperBound(0)].name);
                                LVI.SubItems.Add(Oblicz_date(indeks[indeks.GetUpperBound(0)].czas));
                                listView_ListaRozm.Items.Add(LVI);
                            }

                            offset = offset + 40;

                        }

                    }
                }
            }
            else if (init == false)
            {
                Int32 curNum = 0;
                String curSel = "0";
                String msg;

               

                ListView.SelectedListViewItemCollection LV_SEL = listView_ListaRozm.SelectedItems;
                foreach (ListViewItem ITM in LV_SEL)
                {

                    curSel = ITM.Text;
                }


                curNum = Convert.ToInt32(curSel);

                BinaryReader binr = new BinaryReader(sms_dat_strm, Encoding.GetEncoding(1250));
                sms_dat_strm.Seek(indeks[curNum+1].offset,SeekOrigin.Begin);
                asciibyte = binr.ReadBytes(indeks[curNum + 1].size_sms);
                unibyte = Encoding.Convert(ascii, unicode, asciibyte);
                msg = unicode.GetString(unibyte);

                richTextBox_Wypowiedź.Text = msg;



            }

        



        }

        private void eksportujCałeArchSMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Encoding ascii = Encoding.GetEncoding(1250);
            Encoding unicode = Encoding.Unicode;
            Byte[] asciibyte;
            Byte[] unibyte;

            StreamWriter rozm;
            Int32 csv_sel = 0;
            String file_nam, tekst, msg,file_ext;
            String[] text_rozm = new String[1];
            StringBuilder sb = new StringBuilder();
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "txt files (*.txt)|*.txt|csv files (*.csv)|*.csv";
            sfd.CheckFileExists = false;
            sfd.CheckPathExists = true;
            sfd.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                file_nam = sfd.FileName;
                file_ext = file_nam[file_nam.Length - 3].ToString();
                file_ext = file_ext + file_nam[file_nam.Length - 2].ToString();
                file_ext = file_ext + file_nam[file_nam.Length - 1].ToString();
                if (file_ext == "csv")
                {
                    if (MessageBox.Show("Czy dane mają być rozdzielone przecinkiem ?. Jeśli nie, zostaną rozdzielone tabulatorem.", "Tlen Reader Net", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        csv_sel = 1; // comma
                    }
                    else
                    {
                        csv_sel = 2; // tab
                    }
                }
                else if (file_ext == "txt")
                {
                    csv_sel = 0; // txt
                }

                BinaryReader binr = new BinaryReader(sms_dat_strm, ascii);

                for (int x = 1; x < indeks.Length; x++)
                {
                    sms_dat_strm.Seek(indeks[x].offset, SeekOrigin.Begin);

                    asciibyte = binr.ReadBytes(indeks[x].size_sms);
                    unibyte = Encoding.Convert(ascii, unicode, asciibyte);
                    msg = unicode.GetString(unibyte);

                    if (csv_sel == 0)
                    {

                        sb.Append(indeks[x].name);
                        sb.Append(" - ");
                        sb.Append(Oblicz_date(indeks[x].czas));
                        sb.Append(" - ");
                        sb.Append(msg);
                        tekst = sb.ToString();
                        sb.Remove(0, sb.Length);
                        Array.Resize(ref text_rozm, text_rozm.Length + 1);
                        text_rozm[text_rozm.GetUpperBound(0)] = tekst;
                    }
                    else if (csv_sel == 1)
                    {
                    
                        sb.Append("\"");
                        sb.Append(indeks[x].name);
                        sb.Append("\"");
                        sb.Append(",");
                        sb.Append("\"");
                        sb.Append(Oblicz_date(indeks[x].czas));
                        sb.Append("\"");
                        sb.Append(",");
                        sb.Append("\"");
                        sb.Append(msg);
                        sb.Append("\"");
                        tekst = sb.ToString();
                        sb.Remove(0, sb.Length);
                        Array.Resize(ref text_rozm, text_rozm.Length + 1);
                        text_rozm[text_rozm.GetUpperBound(0)] = tekst;
                    }
                    else if (csv_sel == 2)
                    {
                        sb.Append("\"");
                        sb.Append(indeks[x].name);
                        sb.Append("\"");
                        sb.Append("\t");
                        sb.Append("\"");
                        sb.Append(Oblicz_date(indeks[x].czas));
                        sb.Append("\"");
                        sb.Append("\t");
                        sb.Append("\"");
                        sb.Append(msg);
                        sb.Append("\"");
                        tekst = sb.ToString();
                        sb.Remove(0, sb.Length);
                        Array.Resize(ref text_rozm, text_rozm.Length + 1);
                        text_rozm[text_rozm.GetUpperBound(0)] = tekst;
                    }
                    else
                    {
                        return;
                    }

                }

                rozm = File.CreateText(file_nam);
                for (Int32 z = 0; z < text_rozm.Length; z++)
                {
                    rozm.WriteLine(text_rozm[z]);
                }
                rozm.Close();
            }


        }
        /*
        private void otwórzArchiwumTlen7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.Filter = "Archiwum Tlen 7|*.db";
            ofd.Title = "Otwórz plik archiwum Tlen 7";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                System.Data.SQLite.SQLiteConnectionStringBuilder sqlbld = new SQLiteConnectionStringBuilder();
                sqlbld.DataSource = ofd.FileName;
                sqlconn.ConnectionString = sqlbld.ConnectionString;
                sqlconn.Open();
                sqlda.SelectCommand = new System.Data.SQLite.SQLiteCommand("SELECT * FROM Chats, Messages, Users", sqlconn);
                sqlda.Fill(ds);
           


                this.radioButton_T7Rozm.Enabled = true;
                this.radioButton_T7SMS.Enabled = true;
                this.radioButton_T7Czaty.Enabled = true;
                this.radioButton_T7Konf.Enabled = true;


            }

        }
        */
        

        




    }
}
