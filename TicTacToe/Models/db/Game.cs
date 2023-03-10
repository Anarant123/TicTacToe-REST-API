using System;
using System.Collections.Generic;

namespace TicTacToe.Models.db;

public partial class Game
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? CountOfMoves { get; set; }

    public string? LustMove { get; set; }

    public string? _1 { get; set; }

    public string? _2 { get; set; }

    public string? _3 { get; set; }

    public string? _4 { get; set; }

    public string? _5 { get; set; }

    public string? _6 { get; set; }

    public string? _7 { get; set; }

    public string? _8 { get; set; }

    public string? _9 { get; set; }

    public string? Winner { get; set; }

    public Game(string? name)
    {
        this.Name = name;
        this.CountOfMoves = 0;
        this.LustMove = " ";
        this._1 = " ";
        this._2 = " ";
        this._3 = " ";
        this._4 = " ";
        this._5 = " ";
        this._6 = " ";
        this._7 = " ";
        this._8 = " ";
        this._9 = " ";
        this.Winner = " ";
    }
}
