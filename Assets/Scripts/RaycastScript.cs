using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastScript : MonoBehaviour
{

    public Selectable CurrentSelectable;

    [SerializeField] private HexBase hexBase;
    [SerializeField] private GamePiece gamePiece;


    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(transform.position, transform.forward * 100f, Color.yellow);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Selectable selectable = hit.collider.gameObject.GetComponent<Selectable>();
            if (selectable)
            {
                if (CurrentSelectable && CurrentSelectable != selectable)
                {
                    CurrentSelectable.Deselect();
                }
                CurrentSelectable = selectable;
                hit.collider.gameObject.GetComponent<Selectable>().Select();

                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("Вы попали в гекс с именем: " + CurrentSelectable.name);
                    createBase(hit);
                    createGamePiece(hit);
                }
            }
            else
            {
                if (CurrentSelectable)
                {
                    CurrentSelectable.Deselect();
                    CurrentSelectable = null;
                }
            }


            //Debug.Log("Вы попали в гекс с координатами: " + hit.transform.position);
        }
        else
        {
            if (CurrentSelectable)
            {
                CurrentSelectable.Deselect();
                CurrentSelectable = null;
            }
        }
       
    }

    void createBase(RaycastHit hit)
    {
        GameObject gameObject = hit.collider.gameObject;
        CellForBase cellForBase = gameObject.GetComponent<CellForBase>();
        if (cellForBase && cellForBase.hexBase == null)
        {
            var _hexBase = Instantiate(hexBase, gameObject.transform.position, Quaternion.Euler(-90, 0, 0), gameObject.transform.parent);
            _hexBase.name = "Character hex base for " + cellForBase.name;
            cellForBase.hexBase = _hexBase;
        }
    }

    void createGamePiece(RaycastHit hit)
    {
        GameObject gameObject = hit.collider.gameObject;
        PlayableField playableField = gameObject.GetComponent<PlayableField>();
        if (playableField && playableField.gamePiece == null)
        {
            var _gamePiece = Instantiate(gamePiece, gameObject.transform.position, Quaternion.Euler(-90, 0, 0), gameObject.transform.parent);
            _gamePiece.name = "Game piece for " + playableField.name;
            playableField.gamePiece = _gamePiece;
        }
    }
}
