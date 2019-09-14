using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDesign
{
    public class EllipseButton : Control
    {
        Rectangle rect;

        private bool MouseEntered = false;
        private bool MousePressed = false;

#pragma warning disable CS0114 // Член скрывает унаследованный член: отсутствует ключевое слово переопределения
        public Color BackColor { get; set; } = Color.FromArgb(29, 29, 29);
#pragma warning restore CS0114 // Член скрывает унаследованный член: отсутствует ключевое слово переопределения

        private StringFormat SF = new StringFormat();

        public EllipseButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            DoubleBuffered = true;

            Size = new Size(100, 30);

            rect = new Rectangle(1, 1, Width - 3, Height - 3);

        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
           
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            // Size = new Size(100, 30); //фиксация размера
            rect = new Rectangle(1, 1, Width - 3, Height - 3);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graph = e.Graphics;
            graph.SmoothingMode = SmoothingMode.HighQuality;
            graph.Clear(Parent.BackColor);

            Pen TSPen = new Pen(BackColor, 3);

            GraphicsPath rectGP = RoundedRectangle(rect, rect.Height);          

            graph.DrawPath(TSPen, rectGP);
            graph.FillPath(new SolidBrush(BackColor), rectGP);

            graph.DrawEllipse(TSPen, rect);
            graph.FillEllipse(new SolidBrush(BackColor), rect);

            if(MouseEntered)
            {
                graph.DrawPath(TSPen, rectGP);
                graph.FillPath(new SolidBrush(Color.FromArgb(30, Color.White)), rectGP);
            }

            if (MousePressed)
            {
                graph.DrawPath(TSPen, rectGP);
                graph.FillPath(new SolidBrush(Color.FromArgb(30, Color.Black)), rectGP);
            }

            var size = graph.MeasureString(Text, Font);
            var x = Width / 2 - size.Width / 2;
            var y = Height / 2 - size.Height / 2;
                      
            graph.DrawString(Text, Font, new SolidBrush(ForeColor), x, y);
            
        }


        private GraphicsPath RoundedRectangle(Rectangle rect, int RoundSize)
        {
            GraphicsPath gp = new GraphicsPath();

            gp.AddArc(rect.X, rect.Y, RoundSize, RoundSize, 180, 90);
            gp.AddArc(rect.X + rect.Width - RoundSize, rect.Y, RoundSize, RoundSize, 270, 90);
            gp.AddArc(rect.X + rect.Width - RoundSize, rect.Y + rect.Height - RoundSize, RoundSize, RoundSize, 0, 90);
            gp.AddArc(rect.X, rect.Y + rect.Height - RoundSize, RoundSize, RoundSize, 90, 90);

            gp.CloseFigure();

            return gp;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            MouseEntered = true;

            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            MouseEntered = false;

            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            MousePressed = true;

            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            MousePressed = false;

            Invalidate();
        }

    }
}