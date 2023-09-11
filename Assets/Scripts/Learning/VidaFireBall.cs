using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaFireBall : MonoBehaviour
{
    public float Vida;
    // Start is called before the first frame update
    void Start()
    {
        Vida = 6;
    }

    // Update is called once per frame
    void Update()
    {
        Vida -= Time.deltaTime;
        if(Vida <= 0) {
            Destroy(this.gameObject);
        }
    }
}
