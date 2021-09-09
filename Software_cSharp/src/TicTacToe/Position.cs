namespace TicTacToe {
    public struct Position {
        public Position(int x, int y) {
            X = x;
            Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public override string ToString() {
            return string.Format("({0}, {1})", X, Y);
        }

        public static bool operator ==(Position p, Position q) {
            return p.X == q.X && p.Y == q.Y;
        }

        public static bool operator !=(Position p, Position q) {
            return !(p == q);
        }

        public override bool Equals(object obj) {
            if (obj == null || !(obj is Position)) {
                return false;
            }

            return this == (Position) obj;
        }

        public override int GetHashCode() {
            // Source: http://stackoverflow.com/a/263416/5801152
            unchecked // Overflow is fine, just wrap
            {
                var hash = 17;
                hash = hash * 23 + X.GetHashCode();
                hash = hash * 23 + Y.GetHashCode();
                return hash;
            }
        }
    }
}