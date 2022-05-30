using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField] private Color _standartColor;
    [SerializeField] private Color _hoverColor;
    [SerializeField] private MeshRenderer _meshRenderer;

    private void OnMouseEnter()
    {
        ChangeColor(_hoverColor);
    }

    private void OnMouseExit()
    {
        ChangeColor(_standartColor);
    }

    private void ChangeColor(Color color)
    {
        _meshRenderer.material.color = color;
    }
}