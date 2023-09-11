using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlatarforma1 : MonoBehaviour
{
    public float vel = 1;
    public bool IsRight;
    public float Movement;
    public Rigidbody2D rb;
    public Vector3 PosicoesIniciais;

    // Start is called before the first frame update
    void Start()
    {
        PosicoesIniciais = transform.position;
        vel = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        Movement = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(0, Movement * vel);

    }

    public void Restart() {
        transform.position = PosicoesIniciais;
        rb.velocity = Vector2.zero;
    }

        
}
