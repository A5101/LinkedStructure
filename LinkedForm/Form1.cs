﻿using System;
using System.Windows.Forms;
using System.IO;
using LinkedStructure;
using System.Drawing;

namespace LinkedForm
{
    public partial class Form1 : Form
    {
        static ILinkedStructure<int> structure;
        int count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SelectedStructure.SelectedItem = "Односвязный список";
            structure = new SinglyLinkedList<int>();
        }

        private void SelectedStructure_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = SelectedStructure.SelectedItem.ToString();
            Panel.Controls.Clear();
            Panel.Paint += new PaintEventHandler(Panel_Paint);
            count = 0;
            Panel.Refresh();
            switch (s)
            {
                case "Односвязный список": structure = new SinglyLinkedList<int>(); break;
                case "Двусвязный список": structure = new DoublyLinkedList<int>(); break;
                case "Стек": structure = new Stack<int>(); break;
                case "Очередь": structure = new Queue<int>(); break;
                case "Дек": structure = new Deque<int>(); break;
                case "Список": structure = new List<int>(); break;
            }
        }

        private void вНачалоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string i = "0";
            if (structure != null && ShowInputDialog(ref i) == DialogResult.OK)
            {
                structure.AddFirst(Convert.ToInt32(i));
                
                Reffresh();
                count++;
            }
        }

        private void вКонецToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string i = "0";
            if (structure != null && ShowInputDialog(ref i) == DialogResult.OK)
            {
                structure.AddLast(Convert.ToInt32(i));
                
                Reffresh();
                count++;
            }
        }

        private void сНачалаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveFirst();
        }
        
        private void первыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveFirst();
        }

        private void последнийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveLast();
        }
        
        private void сКонцаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveLast();
        }

        void RemoveFirst()
        {
            if (structure != null && structure.Count > 0)
            {
                structure.RemoveFirst();
                
                Reffresh();count--;
                
            }
        }

        void RemoveLast()
        {
            if (structure != null && structure.Count > 0)
            {
                structure.RemoveLast();
                
                Reffresh();
                count--;
            }
        }

        

        private static DialogResult ShowInputDialog(ref string s)
        {
            Size size = new Size(200, 70);
            TextBox textBox = new TextBox
            {
                Size = new Size(size.Width - 10, 23),
                Location = new Point(5, 5),
            };
            Button okButton = new Button
            {
                DialogResult = DialogResult.OK,
                Name = "okButton",
                Size = new Size(75, 23),
                Text = "&OK",
                Location = new Point(size.Width - 80 - 80, 39)
            };
            Button cancelButton = new Button
            {
                DialogResult = DialogResult.Cancel,
                Name = "cancelButton",
                Size = new Size(75, 23),
                Text = "&Cancel",
                Location = new Point(size.Width - 80, 39)
            };
            Form inputBox = new Form
            {
                FormBorderStyle = FormBorderStyle.FixedDialog,
                ClientSize = size,
                Text = "Ввод",
                AcceptButton = okButton,
                CancelButton = cancelButton,
                StartPosition = FormStartPosition.CenterParent
            };
            inputBox.Controls.Add(textBox);
            inputBox.Controls.Add(okButton);
            inputBox.Controls.Add(cancelButton);
            DialogResult result = inputBox.ShowDialog();
            s = textBox.Text;
            return result;
        }

        private void открытьФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            structure.Clear();
            OpenFileDialog open = new OpenFileDialog
            {
                Filter = "Файл набора данных(*.datab)|*.datab"
            };
            if (open.ShowDialog() != DialogResult.OK)
            { return; }
            StreamReader read = new StreamReader(open.FileName);
            string s = read.ReadToEnd();
            while (s != "")
            {
                int i = s.IndexOf(",");
                structure.AddLast(Convert.ToInt32(s.Substring(0, i)));
                s = s.Remove(0, i + 1);
            }
            read.Close();
            Reffresh();
            count = structure.Count;
        }

        private void сохранитьФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog
            {
                Filter = "Файл набора данных(*.datab)|*.datab"
            };
            if (save.ShowDialog() != DialogResult.OK)
            { return; }
            StreamWriter write = new StreamWriter(save.FileName);
            foreach (var s in structure)
            {
                write.Write(s.Value + ",");
            }
            write.Close();
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            structure.Clear();
            Reffresh();
            count = 0;
        }

        void Reffresh()
        {
            Panel.Controls.Clear();
            int i = 0;
            foreach (var temp in structure)
            {
                Point point;
                if (i / 8 % 2 == 0)
                {
                    point = new Point(5 + 60 * (i % 8), 20 + 40 * (i / 8));
                }
                else point = new Point(5 + 420 - 60 * (i % 8), 20 + 40 * (i / 8));
                Button l = new Button
                {
                    Text = temp.Value.ToString(),
                    Location = point,
                    FlatStyle = FlatStyle.Flat,
                    Width = DefaultSize.Width >> 3,
                    ContextMenuStrip = contextMenuStrip1,
                    Tag = i,
                    BackColor = Color.Gainsboro,

                };
                l.MouseClick += Button1_Click;
                Panel.Controls.Add(l);
                i++;

            }
            Panel.Paint += new PaintEventHandler(Panel_Paint);
            Panel.Refresh();
        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            //if (count != Panel.Controls.Count)
           // {
                e.Graphics.Clear(Panel.BackColor);
                Pen pen = new Pen(Color.Black);
                for (int i = 0; i < Panel.Controls.Count - 1; i++)
                {
                    var a = Panel.Controls[i];
                    var b = Panel.Controls[i + 1];
                    if (i / 8 % 2 == 0 && i % 8 != 7)
                    {
                        e.Graphics.DrawLine(pen, a.Location.X + a.Width, a.Location.Y + a.Height / 2, b.Location.X, b.Location.Y + b.Height / 2);
                    }
                    else
                    {
                        if (i % 8 == 7)
                            e.Graphics.DrawLine(pen, a.Location.X + a.Width / 2, a.Location.Y + a.Height, b.Location.X + b.Width / 2, b.Location.Y);
                        else e.Graphics.DrawLine(pen, a.Location.X, a.Location.Y + a.Height / 2, b.Location.X + b.Width, b.Location.Y + b.Height / 2);
                    }
                }
           // }
        }

        

        void Button1_Click(object sender, MouseEventArgs e)
        {
            Button b = (Button)sender;
            if (Convert.ToInt16(b.Tag) == 0)
            {
                RemoveFirst();
            }else if(Convert.ToInt16(b.Tag) == count - 1)
            {
                RemoveLast();
            }
        }
    }
}