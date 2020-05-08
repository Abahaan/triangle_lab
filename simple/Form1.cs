using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace simple
{
    public partial class Form1 : Form
    {
        public List<PointF> point = new List<PointF>();
        public Form1()
        {
            InitializeComponent();
        }
        private void ClearColor(PaintEventArgs e)
        {
            // Clear screen with teal background.
            e.Graphics.Clear(Color.Teal);
        }
        
        private async void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            
            if (point.Count > 4)
            {
                point.Clear();
                


            }
            Graphics g = Graphics.FromHwnd(this.Handle);
            Pen redBrush = new Pen(Color.Red);
            g.DrawRectangle(redBrush, e.X, e.Y, 1, 1);
            point.Add(e.Location);
            if (point.Count == 4)
            {
                
                PointF temp = new PointF(point.Last().X, point.Last().Y);
                
                await Task.Run(() => { PaintTriangle(temp); });
            }
            
        }
        Random rnd = new Random();
        Pen redBrush = new Pen(Color.Red);

        private void PaintTriangle( PointF temp)
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            while (point.Count == 4)
            {   
                Graphics g = Graphics.FromHwnd(this.Handle);
                int value = rnd.Next() % 3;
                temp.X = (point[value].X + temp.X) / 2;
                temp.Y = (point[value].Y + temp.Y) / 2;
                g.DrawRectangle(redBrush, temp.X, temp.Y, 1, 1);
            }
               
        }

        private void button1_Click(object sender, EventArgs e)
        {
            point.Clear();
            
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            return;
        }
    }
}
