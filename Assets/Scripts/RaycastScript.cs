using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastScript : MonoBehaviour
{

    public Selectable CurrentSelectable;

    [SerializeField] private HexBase hexBase;


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
        if (gameObject.GetComponent<CellForBase>())
        {
            var _hexBase = Instantiate(hexBase, gameObject.transform.position, Quaternion.Euler(-90, 0, 0), gameObject.transform.parent);
            _hexBase.name = "Character hex base";
        }
    }
}
