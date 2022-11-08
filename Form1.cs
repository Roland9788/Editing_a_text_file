namespace Редактирование_текстового_файла
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Редактирование текстового файла";
            textBox1.ScrollBars = ScrollBars.Both;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form dialog = new Form();
            dialog.Text = "Путь к файлу";
            TextBox filepath = new TextBox();
            Button btaccept = new Button();
            btaccept.Text = "Подтвердить ";
            btaccept.Location = new Point(150, 200);
            btaccept.Size = new Size(100, 35);
            btaccept.Click += Btaccept_Click;
            void Btaccept_Click(object? sender, EventArgs e)
            {
                TextinFile(filepath.Text);
                dialog.Close();
            }
            filepath.Location = new Point(50,100);
            filepath.Size = new Size(200, 20);
            filepath.Text = "Введите путь к файлу";
            filepath.ForeColor = Color.Gray;
            filepath.Enter += Filepath_Enter;
            filepath.Leave += Filepath_Leave;
            void Filepath_Enter(object? sender, EventArgs e)
            {
                filepath.Text = null;
                filepath.ForeColor = Color.Black;
            }
            void Filepath_Leave(object? sender, EventArgs e)
            {
                if (filepath.Text == "")
                {
                    filepath.Text = "Введите путь к файлу";
                    filepath.ForeColor = Color.Gray;
                }
            }
            dialog.Controls.Add(filepath);
            dialog.Controls.Add(btaccept);
            dialog.ShowDialog();
        }

        private void TextinFile(string Path)
        {
            try
            {
                using (StreamReader reader = new StreamReader(Path))
                {
                    textBox1.Text = reader.ReadToEnd();
                }
                button2.Enabled = true;
            }
            catch
            {
                MessageBox.Show("ERROR 'Возможно не верный путь к файлу'");
            }

        }

        private void InitForm2()
        {
            Form form2 = new Form();
            TextBox editText = new TextBox();
            Button btSave = new Button(), btCancel = new Button();
            form2.Text = "Редактирование";
            form2.Size = this.Size;

            editText.Location = this.textBox1.Location;
            editText.Size = this.textBox1.Size;
            editText.Multiline = true;
            editText.ScrollBars = ScrollBars.Both;
            editText.Text = this.textBox1.Text;

            btSave.Location = this.button1.Location;
            btSave.Size = this.button1.Size;
            btSave.Text = "Сохранить";
            btSave.Click += BtSave_Click;
            void BtSave_Click(object? sender, EventArgs e)
            {
                this.textBox1.Text = editText.Text;
            }

            btCancel.Location = this.button2.Location;
            btCancel.Size = this.button2.Size;
            btCancel.Text = "Отменить";
            btCancel.Click += BtCancel_Click;
            void BtCancel_Click(object? sender, EventArgs e)
            {
                form2.Close();
            }

            form2.Controls.Add(editText);
            form2.Controls.Add(btSave);
            form2.Controls.Add(btCancel);
            form2.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            InitForm2();
        }
    }
}