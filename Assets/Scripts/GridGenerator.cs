using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] private Vector2Int _gridSize;
    [SerializeField] private CellField _cellForField;
    [SerializeField] private CellBase _cellForBase;
    [SerializeField] private CellPoint _cellForPoints;
    [SerializeField] private CellSourceBase _cellForSourceBase;
    [SerializeField] private float _offset;
    [SerializeField] private Transform _parent;
    [SerializeField] private HexBase _hexBase;

   
    public List<Cell> GenerateGrid()
    {
        List<Cell> cells = new List<Cell>();
        var cellsize = _cellForField.GetComponent<MeshRenderer>().bounds.size;
        float difference = _gridSize.y - _gridSize.x;
        float strNumber_z = 0;
        float strNumber_x = 0;

        int hexInLine = (int) difference;
        for (int x = 0; x < _gridSize.y; x++)
        {
            float coordinate_x = strNumber_x;

            if (x < difference)
            {
                hexInLine++;
                float coordinate_z = strNumber_z;
                for (int z = 0; z < hexInLine; z++)
                {
                    var position = new Vector3(coordinate_x * (cellsize.x + _offset), 0, coordinate_z * (cellsize.z + _offset));
                    // if дл€ клеток базы не гибкие работают под стандартное поле
                    //базы
                    Cell cell;
                    if (x == 0 && z == 0)
                    {
                        cell = Instantiate(_cellForBase, position, Quaternion.Euler(-90, 0, 0), _parent);
                        cell.name = $"Base: 1";
                        cell.type = CellType.Base;
                    }
                    else if (x == 0 && z == 4)
                    {
                        cell = Instantiate(_cellForBase, position, Quaternion.Euler(-90, 0, 0), _parent);
                        cell.name = $"Base: 2";
                        cell.type = CellType.Base;
                    }
                    //клетки дл€ очков
                    else if (x == 2 && z == 2)
                    {
                        cell = Instantiate(_cellForPoints, position, Quaternion.Euler(-90, 0, 0), _parent);
                        cell.name = $"Points Cell: 1";
                        cell.type = CellType.Point;
                    }
                    else if (x == 2 && z == 4)
                    {
                        cell = Instantiate(_cellForPoints, position, Quaternion.Euler(-90, 0, 0), _parent);
                        cell.name = $"Points Cell: 2";
                        cell.type = CellType.Point;
                    }
                    else
                    {
                        if (x == 0 && z == 2)
                        {
                            cell = Instantiate(_cellForSourceBase, position, Quaternion.Euler(-90, 0, 0), _parent);
                            cell.name = $"South source base X: {x} Z: {z}";
                            cell.type = CellType.SourceBase;
                            GameManager.instance.currentPlayer.sourceBase = cell;
                            generateSourceBase("South player base", cell);
                        } else
                        {
                            cell = Instantiate(_cellForField, position, Quaternion.Euler(-90, 0, 0), _parent);
                            cell.name = $"Field X: {x} Z: {z}";
                            cell.type = CellType.Field;
                        }                        
                        
                    }
                    cell.x = x;
                    cell.z = z;
                    cells.Add(cell);

                    coordinate_z -= 0.90f;
                }
                strNumber_z += 0.46f;
            }

            //Debug.Log("ƒл€ x = " + x + ", w = " + hexInLine);

            if (x >= difference && x < _gridSize.y)
            {
                float coordinate_z = strNumber_z;

                int coordinateCounterZ = 0;

                for (int z = hexInLine; z >= 0; z--)
                {
                    var position = new Vector3(coordinate_x * (cellsize.x + _offset), 0, coordinate_z * (cellsize.z + _offset));

                    Cell cell;
                    //базы
                    if (x == 4 && z == 0)
                    {
                        cell = Instantiate(_cellForBase, position, Quaternion.Euler(-90, 0, 0), _parent);
                        cell.name = $"Base: 3";
                        cell.type = CellType.Base;
                    }
                    else if (x == 4 && z == 8)
                    {
                        cell = Instantiate(_cellForBase, position, Quaternion.Euler(-90, 0, 0), _parent);
                        cell.name = $"Base: 4";
                        cell.type = CellType.Base;
                    }
                    else if (x == 8 && z == 0)
                    {
                        cell = Instantiate(_cellForBase, position, Quaternion.Euler(-90, 0, 0), _parent);
                        cell.name = $"Base: 6";
                        cell.type = CellType.Base;
                    }
                    else if (x == 8 && z == 4)
                    {
                        cell = Instantiate(_cellForBase, position, Quaternion.Euler(-90, 0, 0), _parent);
                        cell.name = $"Base: 5";
                        cell.type = CellType.Base;
                    }
                    //клетки дл€ очков
                    else if (x == 4 && z == 2)
                    {
                        cell = Instantiate(_cellForPoints, position, Quaternion.Euler(-90, 0, 0), _parent);
                        cell.name = $"Points Cell: 3";
                        cell.type = CellType.Point;
                    }
                    else if (x == 4 && z == 6)
                    {
                        cell = Instantiate(_cellForPoints, position, Quaternion.Euler(-90, 0, 0), _parent);
                        cell.name = $"Points Cell: 4";
                        cell.type = CellType.Point;
                    }
                    else if (x == 6 && z == 2)
                    {
                        cell = Instantiate(_cellForPoints, position, Quaternion.Euler(-90, 0, 0), _parent);
                        cell.name = $"Points Cell: 5";
                        cell.type = CellType.Point;
                    }
                    else if (x == 6 && z == 4)
                    {
                        cell = Instantiate(_cellForPoints, position, Quaternion.Euler(-90, 0, 0), _parent);
                        cell.name = $"Points Cell: 6";
                        cell.type = CellType.Point;
                    }
                    else
                    {
                        if (x == 8 && z == 2)
                        {
                            cell = Instantiate(_cellForSourceBase, position, Quaternion.Euler(-90, 0, 0), _parent);
                            cell.name = $"North source base X: {x} Z: {z}";
                            cell.type = CellType.SourceBase;
                            GameManager.instance.otherPlayer.sourceBase = cell;
                            generateSourceBase("North player base", cell);
                        } else
                        {
                            cell = Instantiate(_cellForField, position, Quaternion.Euler(-90, 0, 0), _parent);
                            cell.name = $"Field X: {x} Z: {z}";
                            cell.type = CellType.Field;
                        }
                        
                        
                    }
                    cell.x = x;
                    cell.z = z;
                    cells.Add(cell);

                    coordinateCounterZ++;

                    coordinate_z -= 0.90f;

                }
                hexInLine--;
                strNumber_z -= 0.46f;
            }
            strNumber_x += 0.75f;
        }
        return cells;
    }

    public void generateSourceBase(string name, Cell parent)
    {
        HexBase hexBase = Instantiate(_hexBase, parent.transform.position, Quaternion.Euler(-90, 0, 0), gameObject.transform.parent);
        hexBase.name = name;               
    }
}