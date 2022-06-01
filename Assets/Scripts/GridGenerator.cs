using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] private Vector2Int _gridSize;
    [SerializeField] private Cell _prefab;
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

                    var cell = Instantiate(_prefab, position, Quaternion.Euler(-90, 0, 0), _parent);

                    cell.name = $"X: {x} Z: {z}";

                    coordinate_z -= 0.90f;
                }
                strNumber_z += 0.46f;
            }

            Debug.Log("Äëÿ x = " + x + ", w = " + hexInLine);

            if (x >= difference && x < _gridSize.y)
            {
                float coordinate_z = strNumber_z;

                int coordinateCounterZ = 0;

                for (float z = hexInLine; z >= 0; z--)
                {


                    var position = new Vector3(coordinate_x * (cellsize.x + _offset), 0, coordinate_z * (cellsize.z + _offset));

                    var cell = Instantiate(_prefab, position, Quaternion.Euler(-90, 0, 0), _parent);

                    cell.name = $"X: {x} Z: {coordinateCounterZ}";

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