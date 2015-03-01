using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPPSimulator.PieChart
{
    public class PieSliceCollection : ICollection<PieSlice>
    {
        private List<PieSlice> list;
        private PieChart pieChart;

        public PieSliceCollection(PieChart pieChart)
        {
            list = new List<PieSlice>();
            this.pieChart = pieChart;
        }

        private void item_Changed(object sender, EventArgs e)
        {
            pieChart.Invalidate();
        }

        public void Add(PieSlice item)
        {
            list.Add(item);
            item.Changed += item_Changed;
            pieChart.Invalidate();
        }

        public PieSlice Add(double value, System.Drawing.Color fillColor)
        {
            PieSlice slice = new PieSlice() { Value = value, FillColor = fillColor };
            Add(slice);
            return slice;
        }

        public void Clear()
        {
            foreach (PieSlice slice in list) {
                list.Remove(slice); //to remove event handlers
            }
        }

        public bool Contains(PieSlice item)
        {
            return list.Contains(item);
        }

        public void CopyTo(PieSlice[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return list.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(PieSlice item)
        {
            item.Changed -= item_Changed;
            bool result = list.Remove(item);
            pieChart.Invalidate();
            return result;
        }

        public IEnumerator<PieSlice> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public PieSlice this[int index]
        {
            get { return list[index]; }
            set { list[index] = value; }
        }
    }
}
