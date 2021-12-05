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
        const int r = 20;
        public Form1()
        {
            InitializeComponent();
        }
        private void FormMouseClick(object sender, MouseEventArgs e)
        {
            bool newc = true;
            for (storage.firstItem(); !storage.isEoL(); storage.nextItem())
                if (storage.curItem().isthere(e.X-r, e.Y-r) == true) { 
                    newc = false;
                    if (ctrlpressed==true) storage.curItem().setsel(true);
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
                Circle C = new Circle(e.X-r, e.Y-r);
                C.setR(r);
                C.setsel(true);
                for (storage.firstItem(); !storage.isEoL(); storage.nextItem()) storage.curItem().setsel(false);
                storage.add(C);
            }
            Controls.Clear();
            Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) ctrlpressed = true;
            if (e.KeyCode == Keys.ShiftKey)
            {
                storage.firstItem();
                while (!storage.isEoL())
                {
                    if (storage.curItem().getsel() == true)
                    {
                        if (storage.count() == 1)
                        {
                            Circle _Cdel = storage.removeC();
                            break;
                        }
                        Circle Cdel = storage.removeC();
                    }
                    else storage.nextItem();
                }
                Controls.Clear();
                Invalidate();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control) ctrlpressed = false;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (storage.firstItem(); !storage.isEoL(); storage.nextItem()) storage.curItem().draw(e);
        }
    }
}
