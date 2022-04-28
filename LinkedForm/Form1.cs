using System;
using System.Windows.Forms;
using LinkedStructure;

namespace LinkedForm
{
    public partial class Form1 : Form
    {
        static ILinkedStructure<int> structure;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SelectedStructure.SelectedItem = "Односвязный список";
        }

        private void SelectedStructure_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = SelectedStructure.SelectedItem.ToString();
            SelectedStructure.Text = "";
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
        void Reffresh()
        {
            CurrentStructure.Text = "";
            foreach(var temp in structure)
            {
                CurrentStructure.Text += $"{temp.Value} -> ";
            }
            //CurrentStructure.Text = CurrentStructure.Text.Substring(0, CurrentStructure.Text.Length - 4);
        }

        private void вНачалоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string i = "0";
            if (structure != null && ShowInputDialog(ref i) == DialogResult.OK)
            {
                structure.AddFirst(Convert.ToInt32(i));
                Reffresh();
            }
        } 
        
        private void вКонецToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string i = "0";
            if (structure != null && ShowInputDialog(ref i) == DialogResult.OK)
            {
                structure.AddLast(Convert.ToInt32(i));
                Reffresh();
            }
        }
        
        private void сНачалаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (structure != null && structure.Count > 0)
            {
                structure.RemoveFirst();
                Reffresh();
            }
        }
        
        private void сКонцаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (structure != null && structure.Count > 0)
            {
                structure.RemoveLast();
                Reffresh();
            }
        }

        private static DialogResult ShowInputDialog(ref string s)
        {
            System.Drawing.Size size = new System.Drawing.Size(200, 70);
            TextBox textBox = new TextBox
            {
                Size = new System.Drawing.Size(size.Width - 10, 23),
                Location = new System.Drawing.Point(5, 5),
            };
            Button okButton = new Button
            {
                DialogResult = DialogResult.OK,
                Name = "okButton",
                Size = new System.Drawing.Size(75, 23),
                Text = "&OK",
                Location = new System.Drawing.Point(size.Width - 80 - 80, 39)
            };
            Button cancelButton = new Button
            {
                DialogResult = DialogResult.Cancel,
                Name = "cancelButton",
                Size = new System.Drawing.Size(75, 23),
                Text = "&Cancel",
                Location = new System.Drawing.Point(size.Width - 80, 39)
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
    }
}
