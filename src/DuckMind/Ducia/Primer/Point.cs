using System;

namespace Ducia.Primer {
    public struct Point {
        public readonly int X;
        public readonly int Y;

        public Point(int v) : this(v, v) { }

        public Point(int x, int y) {
            this.X = x;
            this.Y = y;
        }

        public static Point operator +(Point p1, Point p2) {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }

        public static Point operator -(Point p1, Point p2) {
            return new Point(p1.X - p2.X, p1.Y - p2.Y);
        }

        /// <summary>
        /// Manhattan distance
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static int mhDist(Point p1, Point p2) {
            return Math.Abs(p1.X - p2.X) + Math.Abs(p1.Y - p2.Y);
        }

        /// <summary>
        /// Chebyshev distance
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static int chDist(Point p1, Point p2) {
            return Math.Max(Math.Abs(p1.X - p2.X), Math.Abs(p1.Y - p2.Y));
        }

        public override bool Equals(object obj) {
            if (obj == null || GetType() != obj.GetType())
                return false;

            return equalTo((Point) obj);
        }

        public override int GetHashCode() {
            unchecked // Overflow is fine, just wrap
            {
                var hash = 17;
                hash = hash * 23 + X.GetHashCode();
                hash = hash * 23 + Y.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(Point lhs, Point rhs) {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Point lhs, Point rhs) {
            return !lhs.Equals(rhs);
        }

        private bool equalTo(Point p) => (X == p.X) && (Y == p.Y);

        public override string ToString() => $"({X}, {Y})";
    }
}