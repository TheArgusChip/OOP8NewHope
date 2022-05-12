namespace OOP8.Model.PointAdders
{
    internal class DrawerPointer : PointSetter
    {
        public DrawerPointer(Drawer drawer) : base(drawer) { }

        public override void PointCreate(Point point)
        {
            Draw.CreateNewPoint(point);
        }
    }
}
