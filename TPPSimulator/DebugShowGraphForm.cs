﻿using System;
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
            Pen edgePen = new Pen(Color.Red, 8);
            edgePen.EndCap = LineCap.ArrowAnchor;
            g.FillRectangle(Brushes.Black, new Rectangle(Point.Empty, bmp.Size));

            foreach (Edge<Point> edge in graph.AllEdges) {
                Point start = TranslateGraphPoint(edge.StartNode.Data);
                Point end = TranslateGraphPoint(edge.EndNode.Data);
                g.DrawLine(edgePen, start, end);
            }

            foreach (Node<Point> node in graph.AllNodes) {
                Point pt = TranslateGraphPoint(node.Data);
                g.FillEllipse(Brushes.Lime, pt.X - 8, pt.Y - 8, 16, 16);
            }

            DebugShowGraphForm form = new DebugShowGraphForm();
            form.image.Image = bmp;
            form.ShowDialog();
        }
    }
}
