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
        Storage storage = new Storage();
        bool ctrlpressed = false;
        public Form1()
        {
            InitializeComponent();
        }

       private void FormMouseClick(object sender, MouseEventArgs e)
        {
            bool newc = true;
            for (storage.firstItem(); !storage.isEoL(); storage.nextItem())
                if (storage.curItem().isthere(e.X, e.Y) == true) { 
                    newc = false;
                    if (ctrlpressed) storage.curItem().setsel(true);
                    else
                    {
                        Circle Csel = storage.removeC();
                        for (storage.firstItem(); !storage.isEoL(); storage.nextItem()) storage.curItem().setsel(false);
                        Csel.setsel(true);
                        storage.add(Csel);
                    }
                    storage.lastItem();
                }
            if (newc == true)
            {
                Circle C = new Circle(e.X, e.Y);
                C.setsel(true);
                for (storage.firstItem(); !storage.isEoL(); storage.nextItem()) storage.curItem().setsel(false);
                storage.add(C);
            }
            Controls.Clear();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control) ctrlpressed = true;
            if (e.KeyCode == Keys.Delete)
                for (storage.firstItem(); !storage.isEoL(); storage.nextItem())
                    if (storage.curItem().getsel() == true)
                    {
                        Circle Cdel = storage.removeC();
                    }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control) ctrlpressed = false;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (storage != null)
                for (storage.firstItem(); !storage.isEoL(); storage.nextItem()) storage.curItem().draw(e);
        }
    }
}
