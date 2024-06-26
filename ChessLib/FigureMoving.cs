﻿using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    class FigureMoving
    {
        public Figure figure { get; private set; }
        public Square from { get; private set; }
        public Square to { get; private set; }
        public Figure promotion { get; set; }
        public FigureMoving(FigureOnSquare fs, Square to, Figure promotion = Figure.none) {
            this.figure = fs.figure;
            this.from = fs.square;
            this.to = to;
            this.promotion = promotion;
        }
        public FigureMoving(string move) //Pe2r4 Pe7e8Q
        {
            this.figure = (Figure)move[0];
            this.from = new Square(move.Substring(1, 2));
            this.to = new Square(move.Substring(3, 2));
            this.promotion = (move.Length == 6) ? (Figure)move[5] : Figure.none;
        }

        public int DeltaX { get { return to.x - from.x; } }
        public int DeltaY { get { return to.y - from.y; } }
        public int AbsDeltaX { get { return Math.Abs(DeltaX); } }
        public int AbsDeltaY { get { return Math.Abs(DeltaY); } }
        public int SignDeltaX { get { return Math.Sign(DeltaX); } }
        public int SignDeltaY { get { return Math.Sign(DeltaY); } }
        public override string ToString()
        {
            string text = (char)figure + from.Name + to.Name;
            if(promotion != Figure.none)
            {
                text += (char)promotion;
            }
            return text;
        }
    }
}
