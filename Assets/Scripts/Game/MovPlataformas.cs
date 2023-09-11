using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlataformas : MonoBehaviour
{
    public float vel;
    public bool IsRight;
    public float Movement;
    public Rigidbody2D rb;
    public Vector3 PosicoesIniciais;

    public bool TravaPlatataforma = true;

    // Start is called before the first frame update
    void Start()
    {
        PosicoesIniciais = transform.position;
        vel = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsRight) {
            Movement = Input.GetAxisRaw("Vertical 2");
        }
        else {
            Movement = Input.GetAxisRaw("Vertical");
        }

        if(TravaPlatataforma == false) {
            rb.velocity = new Vector2(0, Movement * vel);
        }

    }

    public void Restart() {
        transform.position = PosicoesIniciais;
        rb.velocity = Vector2.zero;
        TravaPlatataforma = true;
    }

    public void Comecar() {
        TravaPlatataforma = false;
    }

}
