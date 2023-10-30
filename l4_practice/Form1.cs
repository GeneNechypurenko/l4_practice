using System.Windows.Forms;

namespace l4_practice
{

    //—оздайте Windows Forms приложение, которое отображает коллекцию
    //    изображений в FlowLayoutPanel.ѕользователи смогут выбирать 
    //    изображени€ и просматривать их в приложении.
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (PictureBox pictureBox in flowLayoutPanel1.Controls.OfType<PictureBox>())
            {
                pictureBox.Click += (sender, ev) =>
                {
                    ShowImage(pictureBox.Image);
                };
            }
        }

        private void ShowImage(Image image)
        {
            Form imageForm = new Form();

            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = image;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Dock = DockStyle.Fill;

            imageForm.Controls.Add(pictureBox);
            imageForm.ShowDialog();
        }
    }
}