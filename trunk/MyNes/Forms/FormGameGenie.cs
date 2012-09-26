﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using MyNes.Core;
using MyNes.Core.GameGenie;
namespace MyNes
{
    public partial class FormGameGenie : Form
    {
        public FormGameGenie()
        {
            InitializeComponent();
            if (!Nes.ON)
            {
                MessageBox.Show("Nes Is Off");
                Close();
                return;
            }
            gameGenie = new GameGenie();
            textBox2.SelectAll();
            //load list if found
            if (Nes.Board.GameGenieCodes != null)
            {
                foreach (GameGenieCode code in Nes.Board.GameGenieCodes)
                {
                    listView1.Items.Add(code.Name);
                    listView1.Items[listView1.Items.Count - 1].Checked = code.Enabled;
                    listView1.Items[listView1.Items.Count - 1].SubItems.Add(code.Descreption);
                }
            }
            checkBox1.Checked = Nes.Board.IsGameGenieActive;
        }
        GameGenie gameGenie;
        void ShowValues()
        {
            if (textBox2.Text.Length == 6)
            {
                textBox_address.Text = string.Format("{0:X4}", gameGenie.GetGGAddress(gameGenie.GetCodeAsHEX(textBox2.Text), 6));
                textBox_value.Text = string.Format("{0:X2}", gameGenie.GetGGValue(gameGenie.GetCodeAsHEX(textBox2.Text), 6));
                textBox1.Text = "00";
            }
            else if (textBox2.Text.Length == 8)//8 code length
            {
                textBox_address.Text = string.Format("{0:X4}", gameGenie.GetGGAddress(gameGenie.GetCodeAsHEX(textBox2.Text), 8));
                textBox_value.Text = string.Format("{0:X2}", gameGenie.GetGGValue(gameGenie.GetCodeAsHEX(textBox2.Text), 8));
                textBox1.Text = string.Format("{0:X2}", gameGenie.GetGGCompareValue(gameGenie.GetCodeAsHEX(textBox2.Text)));
            }
            else//code incomplete
            {
                textBox_address.Text = "ERROR";
                textBox_value.Text = textBox1.Text = "ERROR";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + button2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + button3.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + button4.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + button5.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + button6.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + button9.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + button8.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + button7.Text;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + button10.Text;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + button12.Text;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + button14.Text;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + button16.Text;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + button17.Text;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + button15.Text;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + button13.Text;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + button11.Text;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0)
                textBox2.Text = textBox2.Text.Substring(0, textBox2.Text.Length - 1);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label_error.Visible = false;
            textBox2.Text = textBox2.Text.ToUpper();
            textBox2.Text.Replace(" ", "A");
            textBox2.Text.Replace("B", "A");
            textBox2.Text.Replace("C", "A");
            textBox2.Text.Replace("D", "A");
            textBox2.Text.Replace("F", "A");
            textBox2.Text.Replace("H", "A");
            textBox2.Text.Replace("J", "A");
            textBox2.Text.Replace("M", "A");
            textBox2.Text.Replace("Q", "A");
            textBox2.Text.Replace("R", "A");
            textBox2.Text.Replace("W", "A");
            textBox2.Text.Replace("Z", "A");
            if (textBox2.Text.Length > 8)
                textBox2.Text = textBox2.Text.Substring(0, 8);
            textBox2.SelectionStart = textBox2.Text.Length;
            ShowValues();
        }
        //add code
        private void button20_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length != 6 && textBox2.Text.Length != 8)
            {
                label_error.Visible = true;
                return;
            }
            if (textBox2.Text.Contains(" "))
            {
                label_error.Visible = true;
                return;
            }
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Text == textBox2.Text)
                {
                    MessageBox.Show("Code already exist in the list");
                    return;
                }
            }
            EnterNameForm comment = new EnterNameForm("Enter comment", "Game Genie Code", true, false);
            if (comment.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                listView1.Items.Add(textBox2.Text);
                listView1.Items[listView1.Items.Count - 1].Checked = true;
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(comment.EnteredName);
            }
        }
        //remove selected
        private void button24_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 1)
                return;
            if (MessageBox.Show("Are you sure ?", "Remove code", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == System.Windows.Forms.DialogResult.Yes)
            {
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
        }

        private void FormGameGenie_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode & Keys.Control) == Keys.Control && (e.KeyCode & Keys.C) == Keys.C)
            {
                textBox2.Copy();
            }
            if ((e.KeyCode & Keys.Control) == Keys.Control && (e.KeyCode & Keys.V) == Keys.V)
            {
                textBox2.Paste();
            }
        }
        //save list as
        private void button22_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("Code already exist in the list");
                return;
            }
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "XML (*.xml)|*.xml";
            save.FileName = System.IO.Path.GetFileNameWithoutExtension(Nes.RomInfo.Path) + ".xml";
            if (save.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                XmlWriterSettings sett = new XmlWriterSettings();
                sett.Indent = true;
                XmlWriter XMLwrt = XmlWriter.Create(save.FileName, sett);
                XMLwrt.WriteStartElement("MyNesGameGenieCodesList");//header
                foreach (ListViewItem item in listView1.Items)
                {
                    XMLwrt.WriteStartElement("Code");
                    XMLwrt.WriteAttributeString("code", item.Text);
                    XMLwrt.WriteAttributeString("comment", item.SubItems[1].Text);
                    XMLwrt.WriteEndElement();//Code end
                }
                XMLwrt.WriteEndElement();//header end
                XMLwrt.Flush();
                XMLwrt.Close();
            }
        }
        //load list
        private void button21_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "XML (*.xml)|*.xml";
            if (op.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                XmlReaderSettings sett = new XmlReaderSettings();
                sett.DtdProcessing = DtdProcessing.Ignore;
                sett.IgnoreWhitespace = true;
                XmlReader XMLread = XmlReader.Create(op.FileName, sett);
                XMLread.Read();//Reads the XML definition <XML>
                XMLread.Read();//Reads the header
                if (XMLread.Name != "MyNesGameGenieCodesList")
                {
                    MessageBox.Show("This file is not My Nes Game Genie codes list file");
                    XMLread.Close();
                    return;
                }
                listView1.Items.Clear();
                while (XMLread.Read())
                {
                    if (XMLread.Name == "Code")
                    {
                        XMLread.MoveToAttribute("code");
                        listView1.Items.Add(XMLread.Value.ToString());
                        listView1.Items[listView1.Items.Count - 1].Checked = true;
                        XMLread.MoveToAttribute("comment");
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(XMLread.Value);
                    }
                }
                XMLread.Close();
            }
        }
        //ok
        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
            {
                MessageBox.Show("There is no code in the list.");
                return;
            }
            Nes.Board.IsGameGenieActive = checkBox1.Checked;
            List<GameGenieCode> codes = new List<GameGenieCode>();
            gameGenie = new GameGenie();
            foreach (ListViewItem item in listView1.Items)
            {
                GameGenieCode code = new GameGenieCode();
                code.Enabled = item.Checked;
                code.Name = item.Text;
                code.Descreption = item.SubItems[1].Text;
                if (item.Text.Length == 6)
                {
                    code.Address = gameGenie.GetGGAddress(gameGenie.GetCodeAsHEX(textBox2.Text), 6) | 0x8000;
                    code.Value = gameGenie.GetGGValue(gameGenie.GetCodeAsHEX(textBox2.Text), 6);
                    code.IsCompare = false;
                }
                else
                {
                    code.Address = gameGenie.GetGGAddress(gameGenie.GetCodeAsHEX(textBox2.Text), 8) | 0x8000;
                    code.Value = gameGenie.GetGGValue(gameGenie.GetCodeAsHEX(textBox2.Text), 8);
                    code.Compare = gameGenie.GetGGCompareValue(gameGenie.GetCodeAsHEX(textBox2.Text));
                    code.IsCompare = true;
                }
                //add to active list
                codes.Add(code);
            }
            Nes.Board.GameGenieCodes = codes.ToArray();
            this.Close();
        }
    }
}