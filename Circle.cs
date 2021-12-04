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
    class Circle
    {
        private int x;
        private int y;
        private int R=10;

        public Circle(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int getx() { return x; }
        public int gety() { return y; }
        public int getR() { return R; }
        public void setC(int _x,int _y)
        {
            x = _x;
            y = _y;
        }
        public void setR(int _R)
        {
            R = _R;
        }
        public void draw(MouseEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 3);
            e.Graphics.DrawEllipse(blackPen, x, y, 2*R, 2*R);
        }
    }
}
