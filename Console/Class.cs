namespace console
{
    public class SwimmingPool
    {
        public double Length, Width, Depth;
        double _Amount;
        public delegate void OverflowingHandler(SwimmingPool sender, EventArgs e);
        public event OverflowingHandler Overflowing;

        public SwimmingPool() { }
        public SwimmingPool(double length, double width, double depth, double amount = 0)
        {
            (Length, Width, Depth, Amount) = (length, width, depth, amount);
        }
        public double Volume => Length * Width * Depth;
        public double Amount
        {
            get => _Amount;
            set
            {
                bool ShouldInvokeEvent = _Amount <= Volume && value > Volume;
                _Amount = value;
                if (ShouldInvokeEvent) { Overflowing?.Invoke(this, EventArgs.Empty); }
            }
        }
    }
}
