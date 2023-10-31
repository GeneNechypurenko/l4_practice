using System.Reflection;
using System.Runtime.Versioning;
using System.Windows.Forms;

namespace l4_practice
{

    public partial class ImageCollection : Form
    {
        FlowLayoutPanel flowLayoutPanel;
        PictureBox pictureBox;
        int formHeight = 400;
        int formWidth = 420;
        int pictureBoxHeight = 62;
        int pictureBoxWidth = 125;

        public ImageCollection()
        {
            this.Load += ImageCollection_Load;
            InitializeComponent();
        }

        private void ImageCollection_Load(object? sender, EventArgs e)
        {
            this.Text = "Image Collection";
            this.Height = formHeight;
            this.Width = formWidth;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            flowLayoutPanel = new FlowLayoutPanel();
            AddFlowLayoutPanel(this);
            AddPictureBox(flowLayoutPanel);

            foreach (PictureBox el in flowLayoutPanel.Controls.OfType<PictureBox>())
            {
                el.Click += (s, a) =>
                {
                    ShowImageInDialog(el.Image);
                };
            }
        }

        private void ShowImageInDialog(Image image)
        {
            Form imageDialog = new Form();
            imageDialog.Text = "Image View";
            imageDialog.StartPosition = FormStartPosition.CenterScreen;
            imageDialog.Size = new Size(800, 600);

            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = image;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Dock = DockStyle.Fill;

            imageDialog.Controls.Add(pictureBox);
            imageDialog.ShowDialog();
        }

        private void AddPictureBox(FlowLayoutPanel flowLayoutPanel)
        {
            int row = flowLayoutPanel.Height / pictureBoxHeight;
            int col = flowLayoutPanel.Width / pictureBoxWidth;

            for (int i = 0; i < row; ++i)
            {
                for (int j = 0; j < col; ++j)
                {
                    pictureBox = new PictureBox();

                    pictureBox.Height = pictureBoxHeight;
                    pictureBox.Width = pictureBoxWidth;
                    pictureBox.BorderStyle = BorderStyle.FixedSingle;
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                    AddImage(pictureBox, i, j);

                    flowLayoutPanel.Controls.Add(pictureBox);
                }
            }
        }
        private void AddImage(PictureBox pictureBox, int i, int j)
        {
            string resourceName = $"{i}{j}";
            pictureBox.Image = Properties.Resources.ResourceManager.GetObject(resourceName) as Image;
        }
        private void AddFlowLayoutPanel(ImageCollection imageCollection)
        {
            this.Controls.Add(flowLayoutPanel);
            flowLayoutPanel.GetType().GetProperty("Dock").SetValue(flowLayoutPanel, DockStyle.Fill);
        }
    }
}