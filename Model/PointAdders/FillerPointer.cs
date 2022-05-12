namespace OOP8.Model.PointAdders
{
    internal class FillerPointer : PointSetter
    {
        public FillerPointer(Drawer drawer) : base(drawer) { }
        public override void PointCreate(Point point)
        {
            Draw.FillFigure(point);
        }
    }
}
