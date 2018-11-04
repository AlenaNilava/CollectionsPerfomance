using System.Collections;

namespace Collections
{
    public class CustomEllipseComparer : IComparer
    {
		Ellipse x;
		Ellipse y;

		public int Compare(object x, object y)
        {
            this.x = (Ellipse)x;
			this.y = (Ellipse)y;            

            if (this.x.X.CompareTo(this.y.X) != 0)
            {
                return this.x.X.CompareTo(this.y.X);
            }
            else if (this.x.Y.CompareTo(this.y.Y) != 0)
            {
                return this.x.Y.CompareTo(this.y.Y);
            }
            else if (this.x.Radius.CompareTo(this.y.Radius) != 0)
            {
                return this.x.Radius.CompareTo(this.y.Radius);
            }
            else
            {
                return 0;
            }                
        }
    }
}
