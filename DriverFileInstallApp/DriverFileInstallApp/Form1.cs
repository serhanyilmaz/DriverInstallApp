﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriverFileInstallApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="serhan" && textBox2.Text=="123")
            {
                MessageBox.Show("Giriş başarılı","BİLGİ PENCERESİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Giriş başarısız", "BİLGİ PENCERESİ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
