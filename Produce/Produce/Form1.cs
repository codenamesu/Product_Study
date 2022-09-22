using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Produce
{

    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {

        MaterialDate materialDate = new MaterialDate();

        public Form1()
        {
            InitializeComponent();
           
            
        }
        private void Load_Form1(object sender, EventArgs e)
        {
            
        }
        
        private void add_Click(object sender, EventArgs e)
        {
            materialDate.Show();
        }
    }
}