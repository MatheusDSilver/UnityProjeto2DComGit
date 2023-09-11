using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovBala : MonoBehaviour
{
    float vel;
    // Start is called before the first frame update
    void Start()
    {
        vel = 10;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(vel * Time.deltaTime, 0));
    }
}
