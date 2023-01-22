using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //TODO Сделать смену сторон, разделить фигуры на 2 фракции по игрокам, добавить счётчики для очков и доп баз,
    // добавить случайное удаление фигур

    public static GameManager instance;

    public GridGenerator gridGenerator;

    public List<Cell> cells;    

    public Player currentPlayer;
    public Player otherPlayer;

    public int turn = 1;    

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentPlayer = new Player("South");
        otherPlayer = new Player("North");

        cells = gridGenerator.GenerateGrid();               
    }

    public void createGamePiece(RaycastHit hit, Piece _prefab)
    {
        GameObject gameObject = hit.collider.gameObject;
        Cell cell = gameObject.GetComponent<Cell>();
        PlayableField playableField = gameObject.GetComponent<PlayableField>();

        if (playableField && playableField.gamePiece == null)
        {
            var _gamePiece = Instantiate(_prefab, gameObject.transform.position, Quaternion.Euler(-90, 0, 0), gameObject.transform.parent);
            _gamePiece.name = "Game piece for " + playableField.name;
            playableField.gamePiece = _gamePiece;
            cell.piece = _gamePiece;
            currentPlayer.pieces.Add(_gamePiece);
        }

        if (turn % 2 == 0)
        {
            cell.piece.swapMaterial();
        }

        currentPlayer.availableMoves--;
        if (!checkPlayerMoves())
        {
            addPoints();
            isVictory();
            currentPlayer.availableMoves = countBases();
            NextPlayer();            
            turn++;
            Debug.Log("Теперь ходит игрок: " + currentPlayer.name + ". Ход " + turn);
        }

        if (turn % 2 == 1 && turn != 1)
        {
            randomHorizontalDestroy();
        }
    }

    public void randomHorizontalDestroy()
    {
        int randonX = Random.Range(0, 8);
        foreach (Cell cell in cells)
        {
            if (cell.x == randonX && cell.piece != null) 
            {
                Piece piece = cell.piece;
                if (currentPlayer.pieces.Contains(piece))
                {
                    currentPlayer.pieces.Remove(piece);
                } else
                {
                    otherPlayer.pieces.Remove(piece);
                }
                cell.piece = null;
                Destroy(GameObject.Find(piece.name));
                Debug.Log("Фигура уничтожена с координатой: x = " + cell.x + ", z = " + cell.z);
                //Debug.Log("Фигуры уничтожены на клетках с координатой: x = " + cell.x);
            }
        }
    }

    public void randomVerticalDestroy()
    {

    }

    public void addPoints()
    {
        foreach (Cell cell in cells) {
            if (cell.type == CellType.Point && currentPlayer.pieces.Contains(cell.piece))
            {
                currentPlayer.points++;
            }
        }
        Debug.Log(currentPlayer.name + " have points: " + currentPlayer.points);
    }


    public bool checkCell(RaycastHit hit)
    {
        GameObject gameObject = hit.collider.gameObject;
        Cell cell = gameObject.GetComponent<Cell>();
        foreach (Cell otherCell in cells)
        {
            int x = Mathf.Abs(cell.x - otherCell.x);
            int z = Mathf.Abs(cell.z - otherCell.z);
            //Debug.Log(x + " " + z);
            if (x == 1 && z == 1 || x == 1 && z == 0 || x == 0 && z == 1)
            {
                if ((otherCell.piece != null && currentPlayer.pieces.Contains(otherCell.piece)) || (otherCell.type == CellType.SourceBase && otherCell == currentPlayer.sourceBase))
                {
                    return true;                 
                }                   
            }
        }
        return false;
    }

    public bool checkPlayerMoves()
    {        
        if (currentPlayer.availableMoves == 0)
        {
            return false;
        }
        return true;
    }

    public int countBases()
    {
        int count = 1;
        foreach (Cell cell in cells) {
            if (cell.type == CellType.Base && currentPlayer.pieces.Contains(cell.piece))
            {
                count++;
            }
        }
        return count;
    }

    public bool doesPieceBelongToCurrentPlayer(Piece piece)
    {
        return currentPlayer.pieces.Contains(piece);
    }

    public void isVictory()
    {
        if (currentPlayer.points >= 50)
        {
            Debug.Log(currentPlayer.name + " wins!");
        }        
    }

    

    public void NextPlayer()
    {
        Player tempPlayer = currentPlayer;
        currentPlayer = otherPlayer;
        otherPlayer = tempPlayer;
    }
}
