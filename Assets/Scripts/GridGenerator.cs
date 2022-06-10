using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] private Vector2Int _gridSize;
    [SerializeField] private Cell _prefab;
    [SerializeField] private CellForBase _cellForBase;
    [SerializeField] private CellForPoints _cellForPoints;
    [SerializeField] private float _offset;
    [SerializeField] private Transform _parent;

    [ContextMenu("Generate grid")]
    public void GenerateGrid()
    {
        var cellsize = _prefab.GetComponent<MeshRenderer>().bounds.size;
        float difference = _gridSize.y - _gridSize.x;
        float strNumber_z = 0;
        float strNumber_x = 0;

        float hexInLine = difference;
        for (int x = 0; x < _gridSize.y; x++)
        {
            float coordinate_x = strNumber_x;

            if (x < difference)
            {
                hexInLine++;
                float coordinate_z = strNumber_z;
                for (float z = 0; z < hexInLine; z++)
                {
                    var position = new Vector3(coordinate_x * (cellsize.x + _offset), 0, coordinate_z * (cellsize.z + _offset));
                    // if дл€ клеток базы не гибкие работают под стандартное поле
                    //базы
                    if (x == 0 && z == 0)
                    {
                        var _base = Instantiate(_cellForBase, position, Quaternion.Euler(-90, 0, 0), _parent);
                        _base.name = $"Base: 1";
                    }
                    else if (x == 0 && z == 4)
                    {
                        var _base = Instantiate(_cellForBase, position, Quaternion.Euler(-90, 0, 0), _parent);
                        _base.name = $"Base: 2";
                    }
                    //клетки дл€ очков
                    else if (x == 2 && z == 2)
                    {
                        var _base = Instantiate(_cellForPoints, position, Quaternion.Euler(-90, 0, 0), _parent);
                        _base.name = $"Points Cell: 1";
                    }
                    else if (x == 2 && z == 4)
                    {
                        var _base = Instantiate(_cellForPoints, position, Quaternion.Euler(-90, 0, 0), _parent);
                        _base.name = $"Points Cell: 2";
                    }
                    else
                    {
                        var cell = Instantiate(_prefab, position, Quaternion.Euler(-90, 0, 0), _parent);
                        cell.name = $"Cell X: {x} Z: {z}";
                    }
                    coordinate_z -= 0.90f;
                }
                strNumber_z += 0.46f;
            }

            Debug.Log("ƒл€ x = " + x + ", w = " + hexInLine);

            if (x >= difference && x < _gridSize.y)
            {
                float coordinate_z = strNumber_z;

                int coordinateCounterZ = 0;

                for (float z = hexInLine; z >= 0; z--)
                {
                    var position = new Vector3(coordinate_x * (cellsize.x + _offset), 0, coordinate_z * (cellsize.z + _offset));


                    //базы
                    if (x == 4 && z == 0)
                    {
                        var _base = Instantiate(_cellForBase, position, Quaternion.Euler(-90, 0, 0), _parent);
                        _base.name = $"Base: 3";
                    }
                    else if (x == 4 && z == 8)
                    {
                        var _base = Instantiate(_cellForBase, position, Quaternion.Euler(-90, 0, 0), _parent);
                        _base.name = $"Base: 4";
                    }
                    else if (x == 8 && z == 0)
                    {
                        var _base = Instantiate(_cellForBase, position, Quaternion.Euler(-90, 0, 0), _parent);
                        _base.name = $"Base: 6";
                    }
                    else if (x == 8 && z == 4)
                    {
                        var _base = Instantiate(_cellForBase, position, Quaternion.Euler(-90, 0, 0), _parent);
                        _base.name = $"Base: 5";
                    }
                    //клетки дл€ очков
                    else if (x == 4 && z == 2)
                    {
                        var _base = Instantiate(_cellForPoints, position, Quaternion.Euler(-90, 0, 0), _parent);
                        _base.name = $"Points Cell: 3";
                    }
                    else if (x == 4 && z == 6)
                    {
                        var _base = Instantiate(_cellForPoints, position, Quaternion.Euler(-90, 0, 0), _parent);
                        _base.name = $"Points Cell: 4";
                    }
                    else if (x == 6 && z == 2)
                    {
                        var _base = Instantiate(_cellForPoints, position, Quaternion.Euler(-90, 0, 0), _parent);
                        _base.name = $"Points Cell: 5";
                    }
                    else if (x == 6 && z == 4)
                    {
                        var _base = Instantiate(_cellForPoints, position, Quaternion.Euler(-90, 0, 0), _parent);
                        _base.name = $"Points Cell: 6";
                    }

                    else
                    {
                        var cell = Instantiate(_prefab, position, Quaternion.Euler(-90, 0, 0), _parent);
                        cell.name = $"Cell X: {x} Z: {coordinateCounterZ}";
                    }
                    coordinateCounterZ++;

                    coordinate_z -= 0.90f;

                }
                hexInLine--;
                strNumber_z -= 0.46f;
            }
            strNumber_x += 0.75f;
        }
    }
}