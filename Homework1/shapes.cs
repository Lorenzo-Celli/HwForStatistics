using System;
using System.Drawing;
using System.Windows.Forms;

class DrawingForm : Form
{
    public DrawingForm()
    {
        // Set the form size and title
        this.Size = new Size(400, 400);
        this.Text = "Shapes";

   
        this.Paint += new PaintEventHandler(DrawingForm_Paint);
    }

    private void DrawingForm_Paint(object sender, PaintEventArgs e)
    {

        Graphics graphics = e.Graphics;

        //line
        Pen linePen = new Pen(Color.Black, 2);
        Point startPoint = new Point(50, 50);
        Point endPoint = new Point(200, 50);
        graphics.DrawLine(linePen, startPoint, endPoint);

        //point
        SolidBrush pointBrush = new SolidBrush(Color.Black);
        Point pointLocation = new Point(100, 100);
        graphics.FillEllipse(pointBrush, pointLocation.X - 2, pointLocation.Y - 2, 4, 4);

        //circle
        Pen circlePen = new Pen(Color.Black, 2);
        Rectangle circleRect = new Rectangle(50, 150, 100, 100);
        graphics.DrawEllipse(circlePen, circleRect);

        //rectangle
        Pen rectanglePen = new Pen(Color.Black, 2);
        Rectangle rectangleRect = new Rectangle(200, 150, 100, 80);
        graphics.DrawRectangle(rectanglePen, rectangleRect);
    }

    public static void Main()
    {
        Application.Run(new DrawingForm());
    }
}
