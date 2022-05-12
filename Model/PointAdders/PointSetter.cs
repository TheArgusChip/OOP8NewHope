namespace OOP8.Model.PointAdders
{
    internal abstract class PointSetter
    {
        protected Drawer Draw;

        public PointSetter(Drawer draw)
        {
            Draw = draw;
        }
        public abstract void PointCreate(Point point);
    }
}
