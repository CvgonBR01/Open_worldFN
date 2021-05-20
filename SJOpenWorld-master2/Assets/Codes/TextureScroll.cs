using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScroll : MonoBehaviour
{
    public float X = 0.005f;
    public float Y = 0.005f;

     void Update()
    {
        float OffsetX = Time.time * X;
        float OffsetY = Time.time * Y;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(OffsetX, OffsetY);
       
    }
}
