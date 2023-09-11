using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Rigidbody2D Bola;
    public bool TravaJump = false;
    public float Forca;
    public int Duplo;

    // Start is called before the first frame update
    void Start()
    {
        Forca = 400f;
        Duplo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            Sair();
        }
        
        if (Input.GetKeyDown(KeyCode.Space) & TravaJump == true)
        {
            Duplo ++;
            Bola.AddForce(new Vector2(0, Forca * Time.fixedDeltaTime), ForceMode2D.Impulse);

            if(Duplo == 2)
            {
                TravaJump = false;
            }
            //fixedDeltaTime
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("chao"))
        {
            TravaJump = true;
            Duplo = 0;
        }
    }

    public void Sair() {
        Debug.Log("Calling Sair");
        Application.Quit();
    }

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if(collision.gameObject.CompareTag("chao"))
    //    {
    //        TravaJump = false;
    //    }
    //}
}
