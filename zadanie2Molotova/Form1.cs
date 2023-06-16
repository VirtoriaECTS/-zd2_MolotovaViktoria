using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace zadanie2
{
    public partial class Form1 :Form
    {
        Contact contact = new Contact();
        PhoneBook phone;
        public Form1 ()
        {
            InitializeComponent();
            phone = new PhoneBook(listBox1);
        }

        private void Form1_Load (object sender, EventArgs e)
        {

        }


        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void addBut_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Не все поля заполнены", "Ошибка");
                return;
            }
            foreach (var line in textBox1.Text)
            {
                if (char.IsDigit(line))
                {
                    MessageBox.Show("Имя не может состоять из цифр", "Ошибка");
                    return;
                }
            }
            foreach (var line in textBox2.Text)
            {
                if (char.IsLetter(line))
                {
                    MessageBox.Show("Номер может состоять только из цифр", "Ошибка");
                    return;
                }
            }
            if (textBox2.Text.Length < 14 || textBox2.Text.Length > 14)
            {
                MessageBox.Show("Длина номера телефона должна состовлять 14 символов", "Ошибка");
                return;

            }
            contact.name = textBox1.Text;
            contact.phone = textBox2.Text;
            if (contact.sc == true)
            {
                phone.Add(contact.name, contact.phone);
                listBox1.Items.Clear();
                phone.GetAllContacts();
                MessageBox.Show("Контакт добавлен");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void changeBut_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                phone.Search(textBox3.Text);
                phone.GetAllContacts();
            }
            else MessageBox.Show("Поле не заполнено", "Ошибка");
            foreach (var line in textBox3.Text)
            {
                if (char.IsDigit(line))
                {
                    MessageBox.Show("Имя не может состоять из цифр", "Ошибка");
                    return;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                listBox1.Items.Clear();
                phone.Delete(textBox4.Text);
                listBox1.Items.Clear();
                phone.GetAllContacts();
            }
            else MessageBox.Show("Поле не заполнено", "Ошибка");
            foreach (var line in textBox4.Text)
            {
                if (char.IsLetter(line))
                {
                    MessageBox.Show("Номер может состоять только из цифр", "Ошибка");
                    return;
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                listBox1.Items.Clear();
                phone.Delete(textBox4.Text);
                listBox1.Items.Clear();
                phone.GetAllContacts();
            }
            else MessageBox.Show("Поле не заполнено", "Ошибка");
            foreach (var line in textBox4.Text)
            {
                if (char.IsLetter(line))
                {
                    MessageBox.Show("Номер может состоять только из цифр", "Ошибка");
                    return;
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                PhoneBookLoader.Load(phone, file);
                listBox1.Items.Clear();
                phone.GetAllContacts();
                MessageBox.Show("Выбран файл: " + file);
            }
            else
            {
                MessageBox.Show("Файл не выбран");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (StreamWriter wr = new StreamWriter("phone.txt"))
            {
                foreach (var item in listBox1.Items)
                {
                    wr.WriteLine(item.ToString());
                }
            }
            MessageBox.Show("Список контактов сохранен в файл phone.txt");
        }
    }
}
