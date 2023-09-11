using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovGetAxis : MonoBehaviour
{
    public float H;
    public float V;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        H = Input.GetAxis("Mouse X");
        V = Input.GetAxis("Mouse Y");

        transform.Translate(new Vector3(H * Time.deltaTime, V * Time.deltaTime, 0));
    }
}
