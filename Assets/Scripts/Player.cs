using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{

    public string name;
    public int points;
    public int availableMoves;
    public Cell sourceBase;    
    public List<Piece> pieces;
    

    public Player(string name)
    {
        this.name = name;
        this.points = 0;
        this.availableMoves = 1;
        pieces = new List<Piece>();
    }
}
