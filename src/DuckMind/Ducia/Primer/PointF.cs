using System;

namespace Ducia.Primer; 

public struct PointF {
    public readonly float X;
    public readonly float Y;

    public PointF(float x, float y) {
        X = x;
        Y = y;
    }

    public static PointF operator +(PointF p1, PointF p2) {
        return new PointF(p1.X + p2.X, p1.Y + p2.Y);
    }

    public static PointF operator -(PointF p1, PointF p2) {
        return new PointF(p1.X - p2.X, p1.Y - p2.Y);
    }

    public override bool Equals(object obj) {
        if (obj == null || GetType() != obj.GetType())
            return false;

        return equalTo((PointF)obj);
    }

    public Point round() {
        return new Point(Mathf.roundToInt(X), Mathf.roundToInt(Y));
    }

    public static implicit operator PointF(Point point) {
        return new PointF(point.X, point.Y);
    }

    public static float dist(PointF p1, PointF p2) {
        return (float)Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
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

    public bool equalTo(PointF p) {
        return Math.Abs(X - p.X) < float.Epsilon && Math.Abs(Y - p.Y) < float.Epsilon;
    }

    public override string ToString() {
        return $"({X}, {Y})";
    }
}