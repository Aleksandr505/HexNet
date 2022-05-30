using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject AddPiece(GameObject hex, int col, int row)
    {
        /* var results = []
 for each - N ≤ dx ≤ N:
     for each - N ≤ dy ≤ N:
         for each - N ≤ dz ≤ N:
             if dx + dy + dz = 0:
                 results.append(cube_add(center, Cube(dx, dy, dz)))*/

        /*Vector2Int gridPoint = Geometry.GridPoint(col, row);
        GameObject newPiece = Instantiate(hex, Geometry.PointFromGrid(gridPoint), Quaternion.identity, gameObject.transform);
        GameObject newPiece1 = Instantiate(hex);
        return newPiece;*/
        return hex;
    }
}
