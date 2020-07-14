using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inl2
{
    public partial class Form1 : Form
    {
        String fileName = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void openFile_Click(object sender, EventArgs e)
        { int value = 0;
            value = checkSaved();

            if (value == 0)
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "Text Files (*.txt)|*.txt|All Files (*)|*";
                var result = dlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    var text = File.ReadAllText(dlg.FileName);
                    textBox.Text = text;
                    fileName = dlg.FileName;
                }
                else
                {
                    MessageBox.Show("You pressed cancel");
                }
            }
            else
            { 
            }
        
           
        }

      

        private void saveBtn_Click(object sender, EventArgs e)
        {

            if (fileName == "")
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Text Files (*.txt)|*.txt|All Files (*)|*";
                var result = dlg.ShowDialog();

                if (result == DialogResult.OK)
                {
                    File.WriteAllText(dlg.FileName, textBox.Text);
                    MessageBox.Show("File Saved!");
                    fileName = dlg.FileName;

                }
                else
                {
                    MessageBox.Show("You pressed cancel");
                }
            }
            else
            {
                File.WriteAllText(fileName, textBox.Text); ;
                MessageBox.Show("File Saved!");
             
            }

            
        } 

        private void saveAsBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Text Files (*.txt)|*.txt|All Files (*)|*";
            var result = dlg.ShowDialog();

            if (result == DialogResult.OK)
            {
                File.WriteAllText(dlg.FileName, textBox.Text);
                MessageBox.Show("File Saved!");
                fileName = dlg.FileName;

            }
            else
            {
                MessageBox.Show("You pressed cancel");
            }
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            int value = 0;
            value = checkSaved();
            if (value == 0)
            {
                textBox.Clear();
                fileName = "";
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            int value = 0;
            value = checkSaved();

            if (value == 1)
            {

            }
            else if (fileName == "" && ((textBox.Text).Length > 0))
            {
                var result = MessageBox.Show("Close Program?", "dok1.txt", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                    Close();

            }
            else if (fileName.Length > 0)
            {
                var result = MessageBox.Show("Close Program?", fileName.Substring(48), MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                    Close();
            }
            
        }

        public int checkSaved()
        {
            String text = textBox.Text;
            String fileText = null;
            int returnValue = 0;

            if (fileName != "")
            {
                fileText = File.ReadAllText(fileName);
              
            }

            if (text.Length > 0 && fileName == "")
            {
                var result = MessageBox.Show("Save Program?", "dok1.txt*", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
             
                if (result == DialogResult.Cancel)
                    returnValue = 1;
                else if (result == DialogResult.Yes)
                {
                    SaveFileDialog dlg = new SaveFileDialog();
                    dlg.Filter = "Text Files (*.txt)|*.txt|All Files (*)|*";
                    var dialogResult = dlg.ShowDialog();

                    if (dialogResult == DialogResult.OK)
                    {
                        File.WriteAllText(dlg.FileName, textBox.Text);
                        MessageBox.Show("File Saved!");

                    }
                    else
                    {
                        MessageBox.Show("You pressed cancel");
                    }
                   
                }
            }
            
            else if ( (fileText != (textBox.Text).ToString()) && fileName.Length > 0 )
            {
                var result = MessageBox.Show("Save Program?", (fileName.Substring(48)+"*"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                if (result == DialogResult.Cancel)
                    returnValue = 1;
                else if (result == DialogResult.Yes)
                {
                    File.WriteAllText(fileName, textBox.Text); ;
                    MessageBox.Show("File Saved!");
                  
                }
                
            }

            return returnValue;
           
        }

    }
}
