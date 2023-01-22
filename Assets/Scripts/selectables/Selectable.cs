using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{

    public Material baseMaterial;
    public Material selectableMaterial;

    public void Select()
    {
        GetComponent<Renderer>().material = selectableMaterial;
    }

    public void Deselect()
    {
        GetComponent<Renderer>().material = baseMaterial;
    }
}
