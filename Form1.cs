using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bless_n_keep4._1
{
    public partial class Form1 : Form
    {
        Storage storage;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            bool newc = true;
            for (storage.firstItem(); !storage.isEoL(); storage.nextItem())
                if (storage.curItem().isthere(e.X, e.Y) == true) { 
                    newc = false; 

                }
            if (newc == true)
            {
                Circle C = new Circle(e.X, e.Y);
                C.setsel(true);
                for (storage.firstItem(); !storage.isEoL(); storage.nextItem()) storage.curItem().setsel(false);
                storage.add(C);
            }
            else
        }
    }
}
