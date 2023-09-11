using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovForce : MonoBehaviour
{
    public float Forca = 500f;
    public Rigidbody2D Bola;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Bola.AddForce(new Vector2(0, Forca * Time.fixedDeltaTime), ForceMode2D.Impulse);
            //fixedDeltaTime
        }
    }
}
