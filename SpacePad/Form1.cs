using System;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;
namespace SpacePad
{
    /*
     * Coded by TheSpaceCowboy
     * Date 17/08/17
     * 
     * 
     * 
     */
    public partial class Form1 : Form
    {
        private bool iswraptrue = true;//boolean for keeping track of text word wrapping

        public Form1()
        {

            InitializeComponent();
            this.Text = "Untitled - SpacePad";//intitalizes the title for the program

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {

                if (openFileDialog1.ShowDialog() == DialogResult.OK)//if a file is returned by the open file dialog
                {

                    StreamReader sr = new StreamReader(openFileDialog1.FileName);

                    textBox1.Text = sr.ReadToEnd();//read file to end
                    this.Text = Path.GetFileName(openFileDialog1.FileName) + " - SpacePad";//changes title accordingly

                }
                else if (openFileDialog1.ShowDialog() == DialogResult.None)
                {

                    MessageBox.Show("Sorry file not found, please try again!");//if no file is returned alert user to this.

                }

            }
            catch (Exception)
            {

                MessageBox.Show("File couldn't be opened");

            }
           

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

            openFileDialog1.Dispose();//clears the data from both save and open
            openFileDialog1.Dispose();

            textBox1.Text = "";//clears textbox

            if(saveFileDialog1.ShowDialog() == DialogResult.OK)//stores new  if dialog returns ok
            {

                File.Create(saveFileDialog1.FileName);
                this.Text = Path.GetFileName(saveFileDialog1.FileName) + " - SpacePad";

            }
            else
            {

                MessageBox.Show("Something went wrong when creating the file, try again!");//tell the user something went wrong

            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string name = "";//creates an blank(not empty) string

            if (openFileDialog1.FileName != "openFileDialog1")//if the file dialog is not empty
            {

                name = openFileDialog1.FileName;//use this name

            }
            else if(saveFileDialog1.FileName != "saveFileDialog1")//if the save dialog is not empty
            {

                name = saveFileDialog1.FileName;//use this name

            }
            else
            {
                //create a new file if there isnt already one
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    name = saveFileDialog1.FileName;

                    File.Create(name);
                    this.Text = Path.GetFileName(saveFileDialog1.FileName) + " - SpacePad";

                }

            }

            File.WriteAllText(name, textBox1.Text);//write the file
            MessageBox.Show("Saved!");
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)//save file as specified file
            {

                string name = Path.GetFileName(saveFileDialog1.FileName);

                this.Text = name + " - SpacePad";
                File.WriteAllText(name, textBox1.Text);

            }
           
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Close();

        }

        private void undoCTRLZToolStripMenuItem_Click(object sender, EventArgs e)
        {

            textBox1.Undo();

        }

        private void cutCTRLXToolStripMenuItem_Click(object sender, EventArgs e)
        {

            textBox1.Cut();

        }

        private void copyCTRLCToolStripMenuItem_Click(object sender, EventArgs e)
        {

            textBox1.Copy();

        }

        private void pasteCTRLVToolStripMenuItem_Click(object sender, EventArgs e)
        {

            textBox1.Paste();

        }

        private void deleteDelToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if(textBox1.SelectionStart != 0 && textBox1.SelectionLength != 0)//if the some text has been selected delete it
            {

                textBox1.Text = textBox1.Text.Replace(textBox1.Text.Substring(textBox1.SelectionStart, textBox1.SelectionLength), "");

            }else if(textBox1.SelectionLength == textBox1.Text.Length)
            {
                textBox1.Text = "";
            }

        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string replacee = "";
            string replace = "";

            try
            {

                replacee = Interaction.InputBox("Replace?", "Replace", "hello");//get the text to replace
                replace = Interaction.InputBox("Replace with?", "Replace", "hello");//text to replace with
                
            }
            catch (Exception)
            {

                MessageBox.Show("Please fill in all boxes!");//if there is an error tell the user to fill in the boxes

            }
            if (textBox1.Text.Length <= 0 || replace.Length <=0 || replacee.Length <=0)//if exception handling for whatever reason fails(happened during testing) this will prevent crashing
            {

                MessageBox.Show("Cannot replace empty!");

            }
            else
            {

                textBox1.Text = textBox1.Text.Replace(replacee, replace);//replace text

            }


        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            iswraptrue = !iswraptrue;//wrap text when it hits edge of textbox
            textBox1.WordWrap = iswraptrue;
            
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (fontDialog1.ShowDialog() == DialogResult.OK)//if the font dialog returns true then font is set to fontdialog
                {

                    textBox1.Font = fontDialog1.Font;

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Font format not available");
            }


        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            MessageBox.Show("This is a notepad clone coded by TheSpaceCowboy:\nhttps://github.com/TheSpaceCowboy42534");//lil message from me

        }
    }
}
