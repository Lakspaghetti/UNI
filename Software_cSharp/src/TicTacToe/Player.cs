﻿using System;

namespace TicTacToe {
    public abstract class Player {
        public abstract bool Move(int key);

        public abstract Player Play();

        public abstract void DrawHelp();
    }

    public class Circle : Player {
        private static Circle s_instance = new Circle();

        private Circle() {
            // This is just to make this a singleton.
        }

        public static Circle GetInstance { get; } = Circle.s_instance;


        // THIS IS WHERE YOU IMPLEMENT MOVE
        public override bool Move(int key) {
            Cursor c = Game.GetInstance.Cursor;

            if (key == 'i' || key == 'j' || key == 'k' || key == 'l') {
                return true;
            }
            else {
                return false;
            }
        }


        public override Player Play() {
            var b = Game.GetInstance.Board;
            var c = Game.GetInstance.Cursor;

            if (b.PlayCircle(c)) {
                return Cross.GetInstance;
            } else {
                return this;
            }
        }

        public override void DrawHelp() {
            Console.WriteLine("Circle has the turn.");
            Console.WriteLine("Use <i>, <j>, <k>, and <l> to move.");
            Console.WriteLine("Press <space> to insert circle.\n");
        }
    }

    public class Cross : Player {
        private static Cross s_instance = new Cross();

        private Cross() {
            // This is just to make this a singleton.
        }

        public static Cross GetInstance { get; } = Cross.s_instance;


        // THIS IS WHERE YOU IMPLEMENT MOVE
        public override bool Move(int key) {
            Cursor c = Game.GetInstance.Cursor;

	        if (key == 'w' || key == 'a' || key == 's' || key == 'd') {
                return true;
            }
            else {
                return false;
            }
        }


        public override Player Play() {
            var b = Game.GetInstance.Board;
            var c = Game.GetInstance.Cursor;

            if (b.PlayCross(c)) {
                return Circle.GetInstance;
            } else {
                return this;
            }
        }

        public override void DrawHelp() {
            Console.WriteLine("Cross has the turn.");
            Console.WriteLine("Use <w>, <a>, <s>, and <d> to move.");
            Console.WriteLine("Press <space> to insert cross.\n");
        }
    }
}