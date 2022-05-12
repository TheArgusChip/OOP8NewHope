namespace OOP8.Model
{
    internal class Drawing
    {
        private IFigure _type;
        private Pen _pen;
        private Tuple<Point, Point> _points;
        private SolidBrush _solidBrush;
        private Graphics _graphics;

        public Drawing(Tuple<Point, Point> points, SolidBrush brush, Pen pen, IFigure figure, Graphics graphics)
        {
            _points = points;
            _solidBrush = brush;
            _pen = pen;
            _type = figure;
            _graphics = graphics;
        }

        public Color BrushColor => _solidBrush.Color;
        public Color PenColor => _pen.Color;
        public IFigure Type => _type;

        public void Draw()
        {
            _type.Draw(_graphics, _pen, _points, _solidBrush);
        }

        internal bool Consist(Point point)
        {
            var minX = Math.Min(_points.Item1.X, _points.Item2.X);
            var maxX = Math.Max(_points.Item1.X, _points.Item2.X);

            var minY = Math.Min(_points.Item1.Y, _points.Item2.Y);
            var maxY = Math.Max(_points.Item1.Y, _points.Item2.Y);

            return point.X >= minX && point.X <= maxX && point.Y >= minY && point.Y <= maxY;
        }

        internal void SetBrush(SolidBrush brush)
        {
            _solidBrush = brush;
        }
    }
}
