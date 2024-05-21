using System.Drawing.Imaging;
using System.Windows.Forms;
using ImagePuzzlerLibrary;
namespace ImagePuzzler
{
    public partial class Main : Form
    {
        private PictureBox previewPictureBox; // Declare a PictureBox for the preview image
        private int numberOfPieces; // Number of pieces in the puzzle


        public Main()
        {
            InitializeComponent();

            patternTextBox.Text = "Pattern: 613524"; // Placeholder text for pattern input
            patternTextBox.ForeColor = SystemColors.GrayText; // Set color to gray for placeholder text
            patternTextBox.GotFocus += RemovePlaceholder; // Add event handler for focus event
            patternTextBox.LostFocus += AddPlaceholder; // Add event handler for lost focus event
            this.Controls.Add(patternTextBox); // Add patternTextBox to the form controls
        }
        private void RemovePlaceholder(object sender, EventArgs e)
        {
            // Remove placeholder text when the patternTextBox gains focus
            if (patternTextBox.Text == "Pattern: 613524")
            {
                patternTextBox.Text = "";
                patternTextBox.ForeColor = SystemColors.ControlText; // Reset color to default
            }
        }

        private void AddPlaceholder(object sender, EventArgs e)
        {
            // Add placeholder text if patternTextBox is empty or whitespace when it loses focus
            if (string.IsNullOrWhiteSpace(patternTextBox.Text))
            {
                patternTextBox.Text = "Pattern: 613524";
                patternTextBox.ForeColor = SystemColors.GrayText; // Set color to gray for placeholder text
            }
        }
        private void loadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

            // Show the OpenFileDialog and load the selected image
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = openFileDialog.FileName;
                Bitmap originalImage = new Bitmap(selectedFileName);
                pictureBox1.Image = originalImage; // Display the loaded image in pictureBox1
            }

            shuffleResolve.Enabled = true; // Enable the shuffle button
            resolvebtn.Enabled = true; // Enable the resolve button
            patternTextBox.Enabled = true; // Enable the pattern text box
        }

        private void shuffle_Click(object sender, EventArgs e)
        {
            // Shuffle the image based on the pattern input
            if (patternTextBox.Text != "Pattern: 613524" && !string.IsNullOrWhiteSpace(patternTextBox.Text))
            {
                string patternInput = patternTextBox.Text;
                int[] pattern = ParsePattern(patternInput); // Parse the pattern input

                if (pattern == null)
                {
                    MessageBox.Show("Invalid pattern. Please enter a valid pattern.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                numberOfPieces = pattern.Length;

                try
                {
                    // Create the image puzzle based on the parsed pattern
                    Bitmap imagePuzzle = ImagePuzzlerLibrary.ImagePuzzler.CreatePuzzle((Bitmap)pictureBox1.Image, pattern, numberOfPieces);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; // Set image size mode to stretch
                    pictureBox1.Image = imagePuzzle; // Display the puzzle image

                    shuffleResolve.Enabled = false; // Disable the shuffle button
                    resolvebtn.Enabled = true; // Enable the resolve button
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Show error message
                }
            }
            else
            {
                MessageBox.Show("Please enter a pattern.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Show error message if pattern is not entered
            }
        }

        private void resolveBtn_Click(object sender, EventArgs e)
        {
            // Resolve the shuffled image based on the pattern input
            if (patternTextBox.Text != "Pattern: 613524" && !string.IsNullOrWhiteSpace(patternTextBox.Text))
            {
                string patternInput = patternTextBox.Text;
                int[] pattern = ParsePattern(patternInput); // Parse the pattern input

                if (pattern == null)
                {
                    MessageBox.Show("Invalid pattern. Please enter a valid pattern.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (pattern.Length != numberOfPieces)
                {
                    MessageBox.Show("Pattern length does not match the number of pieces.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    // Resolve the image puzzle based on the parsed pattern
                    Bitmap imagePuzzle = ImagePuzzlerLibrary.ImagePuzzler.ResolvePuzzle((Bitmap)pictureBox1.Image, pattern, numberOfPieces);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; // Set image size mode to stretch
                    pictureBox1.Image = imagePuzzle; // Display the resolved puzzle image

                    resolvebtn.Enabled = false; // Disable the resolve button
                    shuffleResolve.Enabled = true; // Enable the shuffle button
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Show error message
                }
            }
            else
            {
                MessageBox.Show("Please enter a pattern.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Show error message if pattern is not entered
            }
        }
        
        private void downloadImage_Click(object sender, EventArgs e)
        {
            // Save the displayed image
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("No image loaded to download.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Show error message if no image is loaded
                return;
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "JPEG Image|*.jpg|Bitmap Image|*.bmp|PNG Image|*.png";
                saveFileDialog.Title = "Save Image";
                saveFileDialog.FileName = "puzzle_image"; // Default file name

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ImageFormat format = ImageFormat.Jpeg;
                    switch (saveFileDialog.FilterIndex)
                    {
                        case 2:
                            format = ImageFormat.Bmp;
                            break;
                        case 3:
                            format = ImageFormat.Png;
                            break;
                    }

                    pictureBox1.Image.Save(saveFileDialog.FileName, format); // Save the image in the selected format
                }
            }

            
        }

        private void resetFields_Click(object sender, EventArgs e)
        {
            // Reset the form fields to their initial state
            pictureBox1.Image = null;
            shuffleResolve.Enabled = false; // Disable the shuffle button
            resolvebtn.Enabled = false; // Disable the resolve button
            patternTextBox.Text = "Pattern: 613524"; // Reset pattern text box to placeholder text
            patternTextBox.ForeColor = SystemColors.GrayText; // Set color to gray for placeholder text
            patternTextBox.Enabled = false; // Disable the pattern text box
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void ShowPreviewImage()
        {
            // Create a new form to display the preview image
            Form previewForm = new Form();
            previewForm.Text = "Preview";
            previewForm.WindowState = FormWindowState.Maximized; // Maximize the preview form

            // Create a PictureBox to display the enlarged image
            previewPictureBox = new PictureBox();
            previewPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            previewPictureBox.Dock = DockStyle.Fill;
            previewPictureBox.Image = pictureBox1.Image; // Set the image to previewPictureBox

            // Add the PictureBox to the form
            previewForm.Controls.Add(previewPictureBox);

            // Show the preview form
            previewForm.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Show preview image when pictureBox1 is clicked
            if (pictureBox1.Image != null)
            {
                ShowPreviewImage();
            }
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            // Show tooltip on hover if pictureBox1 has an image
            if (pictureBox1.Image != null)
            {
                ToolTip toolTip = new ToolTip();
                toolTip.SetToolTip(pictureBox1, "Click to preview the image");
            }
        }

        private int[] ParsePattern(string patternInput)
        {
            try
            {
                // Parse the pattern input string to an array of integers
                if (patternInput.Contains(","))
                {
                    return Array.ConvertAll(patternInput.Split(','), int.Parse); // Parse comma-separated values
                }
                else
                {
                    return patternInput.Select(ch => int.Parse(ch.ToString())).ToArray(); // Parse individual characters
                }
            }
            catch
            {
                return null; // Return null if parsing fails
            }
        }
    }
}
