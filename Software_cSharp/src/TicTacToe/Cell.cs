using System;
namespace TicTacToe {
    public enum Cell {
        Empty,
        Circle,
        Cross
    }

    public static class CellMethods {
        public static void Draw(this Cell cell) {
            switch (cell) {
            case Cell.Empty:
                Console.Write(' ');
                break;
            case Cell.Circle:
                Console.Write('o');
                break;
            case Cell.Cross:
                Console.Write('x');
                break;
            }
        }
    }
}