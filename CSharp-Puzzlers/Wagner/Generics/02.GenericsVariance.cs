using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Puzzlers.Wagner.Generics
{
    public class Point2D
    {
		public int X { get; set; }
		public int Y { get; set; }
    }

    public class Point3D : Point2D {
        public int Z { get; set; }
    }

    public class Plotter {
        public static void Scale(Point2D[] values, int scaleFactor) {
            for (int i = 0; i < values.Length; i++) {
                values[i] = new Point2D() {
                    X = values[i].X * scaleFactor,
                    Y = values[i].Y * scaleFactor
                };
            }
        }

        #region Fix
        public static IEnumerable<Point2D> ScaleSafe(Point2D[] values, int scaleFactor)
        {
            foreach (var value in values) {
                yield return new Point2D()
                {
                    X = value.X * scaleFactor,
                    Y = value.Y * scaleFactor
                };
            }            
        }
        #endregion
    }

    public class Program {
        public static void Test() {
            var storage = new Point3D[] {
                new Point3D() {X = 1, Y = 2, Z = 3},
                new Point3D() {X = 4, Y = 5, Z = 6}
            };
			Plotter.Scale(storage, 2);
        }
    }
}
