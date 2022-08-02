using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorGradient : MonoBehaviour
{
    [SerializeField] Material material;
    public Color emissionColor;
    public float _RValue;
    public float _GValue;
    public float _BValue;
    public float speed = 1f;


    private void Start()
    {
        emissionColor = material.GetColor("_EmissionColor");


    }

    private void Update()
    {
      
        ChangeCOlors();

    }
    public void ChangeCOlors()
    {
        _RValue = (_RValue < 255f) ? _RValue++ : _RValue++;
        emissionColor.r = _RValue/255f;
         _GValue = _GValue > 255f ? _GValue-- : _GValue++;
        emissionColor.g = _GValue / 255f;
        _BValue = _BValue > 255f ? _BValue-- : _BValue++;
        emissionColor.b = _BValue/255f;
        material.SetColor("_EmissionColor", emissionColor);
    }
}
