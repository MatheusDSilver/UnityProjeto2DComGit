using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageScroll : MonoBehaviour
{
    public Renderer Quad;
    public float vel = 0.1f;
    public int a = 10;
    //public Vector2 Scroll;
    

    // Start is called before the first frame update
    public void Start()
    {
        //Scroll = new Vector2(vel * Time.deltaTime, 0);
    }

    // Update is called once per frame
    public void Update()
    {
        Vector2 Scroll = new Vector2(vel * Time.deltaTime, 0);
        Quad.material.mainTextureOffset += Scroll;
    }
}
