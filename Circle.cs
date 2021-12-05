using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime;

namespace bless_n_keep4._1
{
    class Circle
    {
        private int x;
        private int y;
        private int R;
        private bool sel;
        public Circle(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        /*public int getx() { return x; }
        public int gety() { return y; }*/
        /*public void setC(int _x,int _y)
        {
            x = _x;
            y = _y;
        }*/
        public void setR(int _R)
        {
            R = _R;
        }
        public int getR() { return R; }
        public bool getsel() { return sel; }
        public void setsel(bool b) { sel = b; }
        public void draw(PaintEventArgs e)
        {
            Pen pen;
            if(this.sel==false) pen = new Pen(Color.Black, 3);
            else pen = new Pen(Color.Green, 3);
            e.Graphics.DrawEllipse(pen, x, y, 2*R, 2*R);
        }
        public bool isthere(int _x, int _y)
        {
            if (((x - _x) * (x - _x)+ (y - _y) * (y - _y)) <= R*R) return true;
            else return false;
        }
    }
}
