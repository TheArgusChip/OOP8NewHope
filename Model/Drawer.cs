using OOP8.Model.Figures;
using OOP8.Model.PointAdders;

namespace OOP8.Model
{
    internal class Drawer
    {
        private IFigure[] _figures;
        private Pen _pen;
        private Tuple<Point, Point> _points;
        private SolidBrush _brush;
        private Graphics _graphics;
        private int _choice;
        private FiguresHIstory _figuresHistory;
        private PointSetter[] _pointSetters;
        private PointSetter _option;

        public Drawer(Graphics graphics, FiguresHIstory figuresHIstory)
        {
            _graphics = graphics;
            _points = new Tuple<Point, Point>(Point.Empty, Point.Empty);
            _figures = new IFigure[]
            {
                new Line(),
                new Ellipse(),
                new Figures.Rectangle(),
            };

            _figuresHistory = figuresHIstory;

            _pointSetters = new PointSetter[]
            {
                new DrawerPointer(this),
                new FillerPointer(this)
            };
        }


        internal void FillFigure(Point point)
        {
            var figureToChangeColor = _figuresHistory.Find(point);
            if (figureToChangeColor == null)
            {
                return;
            }
            figureToChangeColor.SetBrush(_brush);
            _figuresHistory.Draw();
        }

        public void SetPenColor(object item)
        {
            var color = (Color)item;
            _pen = new Pen(color, 3);
        }

        public void DoOption(Point location)
        {
            _option.PointCreate(location);
        }
        
        public void CreateNewPoint(Point location)
        {
            if (_points.Item1.IsEmpty)
            {
                _points = new Tuple<Point, Point>(location, Point.Empty);
            }
            else
            {
                _points = new Tuple<Point, Point>(_points.Item1, location);
                _figures[_choice].Draw(_graphics, _pen, _points, _brush);

                _figuresHistory.Add(_points, _brush, _pen, _figures[_choice], _graphics);
                _points = new Tuple<Point, Point>(Point.Empty, Point.Empty);
            }
        }

        internal void SetFigure(int index)
        {
            if (index < 0)
            {
                _choice = 0;
            }
            else
            {
                _choice = index;
            }

        }

        internal void SetBrush(object selectedItem)
        {
            var color = (Color)selectedItem;
            _brush = new SolidBrush(color);
        }

        internal void SetOption(int index)
        {
            _option = _pointSetters[index];
        }
    }
}
