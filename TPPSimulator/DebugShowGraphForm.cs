using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphUtils;

namespace TPPSimulator
{
    public partial class DebugShowGraphForm : Form
    {
        public DebugShowGraphForm()
        {
            InitializeComponent();
        }

        private void DebugShowGraphForm_Load(object sender, EventArgs e)
        {

        }

        private static Point TranslateGraphPoint(Point point)
        {
            return new Point(64 * (1 + point.X), 64 * (1 + point.Y));
        }

        public static void DisplayGraph(Graph<Point> graph, int cols, int rows)
        {
            Bitmap bmp = new Bitmap(64 * (cols + 1), 64 * (rows + 1));
            Graphics g = Graphics.FromImage(bmp);
            Pen edgePen = new Pen(Color.Lime, 8.0f);
            edgePen.EndCap = LineCap.ArrowAnchor;
            g.FillRectangle(Brushes.Black, new Rectangle(Point.Empty, bmp.Size));

            foreach (Edge<Point> edge in graph.AllEdges) {
                Point start = TranslateGraphPoint(edge.StartNode.Data);
                Point end = TranslateGraphPoint(edge.EndNode.Data);
                g.DrawLine(edgePen, start, end);
            }

            foreach (Node<Point> node in graph.AllNodes) {
                Point pt = TranslateGraphPoint(node.Data);
                int colorValue = 16 * (int)node.PathDistance;
                if (colorValue < 0) colorValue = 0; if (colorValue > 255) colorValue = 255;
                Brush br = new SolidBrush(Color.FromArgb(255 - colorValue, 0, colorValue));
                g.FillEllipse(br, pt.X - 8, pt.Y - 8, 16, 16);
            }

            Font distanceFont = new Font("Impact", 24.0f, FontStyle.Regular, GraphicsUnit.Point); //Fixedsys didn't work for some reason
            Brush distanceBrush = new SolidBrush(Color.FromArgb(64, 255, 255, 255));
            Pen predecessorPen = new Pen(Color.Yellow, 2.0f);
            predecessorPen.EndCap = LineCap.Custom;
            predecessorPen.CustomEndCap = new AdjustableArrowCap(6.0f, 8.0f);
            foreach (Node<Point> node in graph.AllNodes) {
                if (node.PathPredecessor != null) {
                    Point start = TranslateGraphPoint(node.Data);
                    Point end = TranslateGraphPoint(node.PathPredecessor.Data);
                    Point mid;
                    if (start.X == end.X) {
                        mid = new Point(start.X + 16, (start.Y + end.Y) / 2);
                    } else {
                        mid = new Point((start.X + end.X) / 2, start.Y - 16);
                    }
                    g.DrawCurve(predecessorPen, new Point[] { start, mid, end }, 1.0f);
                }

                g.DrawString((node.PathDistance == Int64.MaxValue ? "Inf" : node.PathDistance.ToString()), distanceFont, distanceBrush, TranslateGraphPoint(node.Data));
            }

            DebugShowGraphForm form = new DebugShowGraphForm();
            form.image.Image = bmp;
            form.ShowDialog();
        }
    }
}
