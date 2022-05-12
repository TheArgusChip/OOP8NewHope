using OOP8.Model.Figures;

namespace OOP8.Model
{
    internal class FiguresHIstory
    {
        private List<Drawing> _drawings = new List<Drawing>();
        private Form1 _form;

        public FiguresHIstory(Form1 form)
        {
            _form = form;
        }

        internal void Add(Tuple<Point, Point> points, SolidBrush brush, Pen pen, IFigure figure, Graphics graphics)
        {
            Drawing drawing = new Drawing(points, brush, pen, figure, graphics);

            _drawings.Add(drawing);
            _form.UpdateHistory();
        }

        public List<Drawing> Drawings => _drawings;

        public void Draw()
        {
            foreach (var drawing in _drawings)
            {
                drawing.Draw();
            }
        }

        internal Drawing Find(Point point)
        {
            return _drawings.ToArray().Reverse().Where(drawing => drawing.Type != typeof(Line)).FirstOrDefault(drawing => drawing.Consist(point));
        }

        internal void Remove(int index)
        {
            _drawings.RemoveAt(index);
            _form.UpdateHistory();
        }
    }
}
