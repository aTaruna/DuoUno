using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorHandler : MonoBehaviour
{

    public Renderer TintRend;
    public int TintMater;

    public void SetColor(Color c)
    {
        var prop = new MaterialPropertyBlock();
        prop.SetColor("_BaseColor", c);
        TintRend.SetPropertyBlock(prop, TintMater);
    }
}
