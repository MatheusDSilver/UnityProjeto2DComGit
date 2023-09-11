using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public Vector3 PosicoesIniciais;

    public GameObject P1MovP1;
    public GameObject P2MovP2;


    // Start is called before the first frame update
    void Start()
    {
        PosicoesIniciais = transform.position;


        // float x =  Random.Range(0, 2) == 0 ? 1 : -1;
        // float y =  Random.Range(0, 2) == 0 ? 1 : -1;

       
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space)) {
        Comecar();
        P1MovP1.GetComponent<MovPlataformas>().Comecar();
        P2MovP2.GetComponent<MovPlataformas>().Comecar();

       }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Goal 1")) {
            Restart();
            P1MovP1.GetComponent<MovPlataformas>().Restart();
            P2MovP2.GetComponent<MovPlataformas>().Restart();

        }
        if(other.gameObject.CompareTag("Goal 2")) {
            Restart();
            P1MovP1.GetComponent<MovPlataformas>().Restart();
            P2MovP2.GetComponent<MovPlataformas>().Restart();
        }
    }

    public void Comecar() {
        float x =  Random.Range(0, 2) == 0 ? 1 : -1;
        float y =  Random.Range(0, 2) == 0 ? 1 : -1;

        speed = 10;

        rb.velocity = new Vector2(x * speed, y * speed);
        Debug.Log($"X = {x} \n Y = {y} ");
    }


    public void Restart() {
        transform.position = PosicoesIniciais;
        rb.velocity = Vector2.zero;
    }

}
