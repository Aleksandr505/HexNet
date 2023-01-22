using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CellType { Base, Field, Point, SourceBase };

public abstract class Cell : MonoBehaviour
{
    public int x;
    public int z;
    public CellType type;
    public Piece piece;
  
}
