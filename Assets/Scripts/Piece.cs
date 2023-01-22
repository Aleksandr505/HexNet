using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public Material currentMaterial;
    public Material otherMaterial;

    public void swapMaterial()
    {
        Material tmp = currentMaterial;
        currentMaterial = otherMaterial;
        otherMaterial = tmp;

        GetComponent<Renderer>().material = currentMaterial;
    }
}
