using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaFireBallSound : MonoBehaviour
{
    public float Vida;
    // Start is called before the first frame update
    void Start()
    {
        Vida = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Vida = Vida - Time.deltaTime;
        if(Vida <= 0) {
            Destroy(this.gameObject);
        }
    }
}
