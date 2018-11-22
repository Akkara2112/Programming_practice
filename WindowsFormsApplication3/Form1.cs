using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            if (File.Exists("president.dat"))
            {
                desirealizated();
            }
            else
            {
                spisok = new List<president>();
            }
        }
        List<president> spisok;
        int index;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bool fl = true;
                foreach (var c in spisok)
                {
                    if (int.Parse(comboBox1.Text) == c.Okrug & comboBox2.Text == c.Name & dateTimePicker1.Value == c.Date & textBox1.Text == c.Prof)
                        fl = false;
                }
                if (fl)
                    if (textBox1.Text != "" & comboBox1.Text != "" & comboBox2.Text != "" & dateTimePicker1.Value.Year < 1995)
                    {
                        president c = new president(int.Parse(comboBox1.Text), comboBox2.Text, dateTimePicker1.Value, textBox1.Text);
                        spisok.Add(c);
                        visible();
                        pusto();
                        MessageBox.Show("Данные успешно добавлены!");
                    }
                    else
                    {
                        MessageBox.Show("Проверьте данные!!!");
                    }
                else
                {
                    MessageBox.Show("Такой кандидат уже присутствует!!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pusto()
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox1.Text = "";
            dateTimePicker1.Value = DateTime.Now;
        }

        private void visible()
        {
            dataGridView1.RowCount = 1;
            foreach (var c in spisok)
            {
                dataGridView1.Rows.Add(c.Okrug, c.Name, c.Date, c.Prof, c.Date_create);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) 
        {
            try
            {
                comboBox1.Text = spisok[e.RowIndex].Okrug.ToString();
                comboBox2.Text = spisok[e.RowIndex].Name;
                dateTimePicker1.Value = spisok[e.RowIndex].Date;
                textBox1.Text = spisok[e.RowIndex].Prof;
                index = e.RowIndex;
            }
            catch (Exception ex) { }
        }

        private void загрзуитьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog c = new OpenFileDialog();
            c.Filter = "txt file | *.txt";
            if (c.ShowDialog() == DialogResult.OK)
            {
                Open(c.FileName);
            }
        }

        private void сохранитьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog c = new SaveFileDialog();
            c.Filter = "text file | *.txt";
            if (c.ShowDialog() == DialogResult.OK)
            {
                Save(c.FileName);
            }
        }

        private void сериализироватьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            serialization();
        }

        private void десиреализироватьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            desirealizated();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            serialization();
        }

        private void Open(string name)
        {
            int z = 0;
            try
            {
                string[] text;
                using (StreamReader read = new StreamReader(name, Encoding.Default))
                {
                    string[] split = new string[] { "\r\n" };
                    text = read.ReadToEnd().Split(split, StringSplitOptions.None);
                }
                spisok = new List<president>();

                for (int i = 0; i < text.Length / 5; i++)
                {
                    try
                    {
                        president c = new president();
                        c.Okrug = int.Parse(text[z++].ToString());
                        c.Name = text[z++].ToString();
                        c.Date = DateTime.Parse(text[z++].ToString());
                        c.Prof = text[z++].ToString();
                        c.Date_create = DateTime.Parse(text[z++].ToString());
                        spisok.Add(c);
                    }
                    catch (Exception ex)
                    {
                        z ++;
                        MessageBox.Show(ex.Message + "\nСтрока номер: " + z.ToString());
                        z = i * 5;
                    }

                }
                visible();
                
            }
            finally { MessageBox.Show("Данные успешно загружены!"); }

             
        }

        private void Save(string name)
        {
            try
            {                
                using (StreamWriter write = new StreamWriter(name, false, Encoding.Default))
                {
                    foreach (var c in spisok)
                    {
                        write.WriteLine(c.Okrug.ToString());
                        write.WriteLine(c.Name.ToString());
                        write.WriteLine(c.Date.ToString());
                        write.WriteLine(c.Prof.ToString());
                        write.WriteLine(c.Date_create.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void serialization()
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                using (FileStream fs = new FileStream("president.dat", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, spisok);
                    MessageBox.Show("данные сериализованы");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void desirealizated()
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream("president.dat", FileMode.OpenOrCreate))
                {
                    spisok = (List<president>)formatter.Deserialize(fs);
                    MessageBox.Show("данные десиреализованы");
                }
                File.Delete("president.dat");
                for (int i = 0; i < spisok.Count; i++)
                    spisok[i].Date_create = DateTime.Now;
                visible();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                spisok[index].Date = dateTimePicker1.Value;
                spisok[index].Name = comboBox2.Text;
                spisok[index].Okrug = int.Parse(comboBox1.Text);
                spisok[index].Prof = textBox1.Text;
                visible();
                pusto();
            }
            catch
            {
                MessageBox.Show("Не было выделено, что исправить!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int sch_p1 = 0, sch_p2 = 0, sch_p3 = 0, sch_p4 = 0, god;
            string v1, v2,v3,v4;
            double sr_v1 = 0, sr_v2 = 0, sr_v3 = 0, sr_v4 = 0;
            Regex r = new Regex (@"\d{4}");
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells[1].Value.ToString().ToLower() == "Первая партия".ToLower())
                {
                    god = 0;
                    sch_p1++;
                    v1 = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value);
                    Match srv1 = r.Match(v1);
                    god = 2016 - int.Parse(srv1.ToString());
                    sr_v1 += Convert.ToDouble(god);
                }
                if (dataGridView1.Rows[i].Cells[1].Value.ToString().ToLower() == "Вторая партия".ToLower())
                {
                    god = 0;
                    sch_p2++;
                    v2 = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value);
                    Match srv2 = r.Match(v2);
                    god = 2016 - int.Parse(srv2.ToString());
                    sr_v2 += Convert.ToDouble(god);
                }
                if (dataGridView1.Rows[i].Cells[1].Value.ToString().ToLower() == "Третья партия".ToLower())
                {
                    god = 0;
                    sch_p3++;
                    v3 = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value);
                    Match srv3 = r.Match(v3);
                    god = 2016 - int.Parse(srv3.ToString());
                    sr_v3 += Convert.ToDouble(god);
                }
                if (dataGridView1.Rows[i].Cells[1].Value.ToString().ToLower() == "Четвертая партия".ToLower())
                {
                    god = 0;
                    sch_p4++;
                    v4 = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value);
                    Match srv4 = r.Match(v4);
                    god = 2016 - int.Parse(srv4.ToString());
                    sr_v4 += Convert.ToDouble(god);
                }
            }
             
            string[] profess1 = new string[sch_p1];
            string[] profess2 = new string[sch_p2];
            string[] profess3 = new string[sch_p3];
            string[] profess4 = new string[sch_p4];
            int[] sch_prof1 = new int[sch_p1];
            int[] sch_prof2 = new int[sch_p2];
            int[] sch_prof3 = new int[sch_p3];
            int[] sch_prof4 = new int[sch_p4];
            int j1 = 0, j2 = 0, j3 = 0, j4 = 0;
 
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells[1].Value.ToString().ToLower() == "Первая партия".ToLower())
                {
                    profess1[j1] = dataGridView1.Rows[i].Cells[3].Value.ToString().ToLower();
                    j1++;
                    continue;
                }
                if (dataGridView1.Rows[i].Cells[1].Value.ToString().ToLower() == "Вторая партия".ToLower())
                {
                    profess2[j2] = dataGridView1.Rows[i].Cells[3].Value.ToString().ToLower();
                    j2++;
                    continue;
                }
                if (dataGridView1.Rows[i].Cells[1].Value.ToString().ToLower() == "Третья партия".ToLower())
                {
                    profess3[j3] = dataGridView1.Rows[i].Cells[3].Value.ToString().ToLower();
                    j3++;
                    continue;
                }
                if (dataGridView1.Rows[i].Cells[1].Value.ToString().ToLower() == "Четвертая партия".ToLower())
                {
                    profess4[j4] = dataGridView1.Rows[i].Cells[3].Value.ToString().ToLower();
                    j4++;
                    continue;
                }

            }

            int j11 = 0, j22 = 0, j33 = 0, j44 = 0, max1 = 0, max2 = 0, max3 = 0, max4 = 0;

            for (j11 = 0; j11 < j1; j11++)
            for (int i = 0; i < j1; i++)
                    if (profess1[j11] == profess1[i])
                        sch_prof1[j11]++;
            for (j22 = 0; j22 <j2; j22++)
                for (int i = 0; i < j2; i++)
                    if (profess2[j22] == profess2[i])
                        sch_prof2[j22]++;
            for (j33 = 0; j33 < j3; j33++)
                for (int i = 0; i < j3; i++)
                    if (profess3[j33] == profess3[i])
                        sch_prof3[j33]++;
            for (j44 = 0; j44 < j4; j44++)
                for (int i = 0; i < j4; i++)
                    if (profess4[j44] == profess4[i])
                        sch_prof4[j44]++;


            for (int i = 0; i < j1; i++)
            {
                if (max1 < sch_prof1[i])
                    max1 = i;
            }
            for (int i = 0; i < j2; i++)
            {
                if (max2 < sch_prof2[i])
                    max2 = i;
            }
            for (int i = 0; i < j3; i++)
            {
                if (max3 < sch_prof3[i])
                    max3 = i;
            }
            for (int i = 0; i < j4; i++)
            {
                if (max4 < sch_prof4[i])
                    max4 = i;
            }

                if (sr_v1 < 0)
                    sr_v1 /= sch_p1;
                if (sr_v2 < 0)
                    sr_v2 /= sch_p2;
                if (sr_v3 < 0)
                    sr_v3 /= sch_p3;
                if (sr_v4 < 0)
                    sr_v4 /= sch_p4;
           textBox2.Text = "Количество поданых заявлений от Первой партии (средний возраст): " + sch_p1 + "(" + sr_v1 + ")" + Environment.NewLine +
                           "Количество поданых заявлений от Второй партии (средний возраст): " + sch_p2 + " (" + sr_v2 + ")" + Environment.NewLine +
                           "Количество поданых заявлений от Третьей партии (средний возраст): " + sch_p3 + " (" + sr_v3 + ")" + Environment.NewLine +
                           "Количество поданых заявлений от Четвертой партии (средний возраст): " + sch_p4 + " (" + sr_v4 + ")" + Environment.NewLine + 
                           "Преобладающая профессия от Первой партии: " + profess1[max1] + Environment.NewLine +
                           "Преобладающая профессия от Второй партии: " + profess2[max2] + Environment.NewLine +
                           "Преобладающая профессия от Третьей партии: " + profess3[max3] + Environment.NewLine +
                           "Преобладающая профессия от Четвертой партии: " + profess4[max4] + Environment.NewLine;
                
                System.IO.StreamWriter udal = new System.IO.StreamWriter("sved.txt", false);
                { udal.Write(""); udal.Close(); }
                System.IO.StreamWriter zapis = new System.IO.StreamWriter("sved.txt", true, Encoding.Default);
                zapis.Write(textBox2.Text);
                zapis.Close();
            

        }


        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                index = dataGridView1.CurrentRow.Index;
                spisok.RemoveAt(index);
                visible();
                pusto();
            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }       
    }
}