using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villain : MonoBehaviour
{
    //Transform do GameObject Hero
    public Transform Hero;

    //Distancia entre o Vilao e o Heroi
    public float Distancia;

    //Velocidade do vilao
    public float Vel;

    //Liberar para o vilao perseguir o heroi
    public bool ReleaseChase = false;

    //Usado para armazenar a escala do vilao, permitindo assim que ele gire
    public Vector3 Scale;

    //Dita o lado que o vilao esta olhando. true é direita, false esquerda
    public bool Face = true;

    public Animator VillainA;



    // Start is called before the first frame update
    void Start()
    {
        Vel = 1f;

        VillainA = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Distancia = Vector2.Distance(this.transform.position, Hero.transform.position);


        //Virar vilão para esquerda e direita
        if(this.transform.position.x > Hero.transform.position.x && !Face)
        {
            Flip();
        }
        else if (this.transform.position.x < Hero.transform.position.x && Face)
        {
            Flip();
        }


        //Faz com que o vilao persiga o heroi
        if (Distancia > 2f && ReleaseChase)
        {
            if (Hero.transform.position.x > this.transform.position.x)
            {
                transform.Translate(new Vector2(Vel * Time.deltaTime, 0));
                VillainA.SetBool("EnemyIdle", false);
                VillainA.SetBool("EnemyWalking", true);
            }
            else if (Hero.transform.position.x < this.transform.position.x)
            {
                transform.Translate(new Vector2(-Vel * Time.deltaTime, 0));
                VillainA.SetBool("EnemyIdle", false);
                VillainA.SetBool("EnemyWalking", true);
            }
        }
        else
        {
            VillainA.SetBool("EnemyWalking", false);
            VillainA.SetBool("EnemyIdle", true);
        }


        //if(ReleaseChase)
        //{
        //    VillainA.SetBool("EnemyIdle", false);
        //    VillainA.SetBool("EnemyWalking", true);
        //}
        //else
        //{
        //    VillainA.SetBool("EnemyWalking", false);
        //    VillainA.SetBool("EnemyIdle", true);
        //}
    }

    //Funcao para girar Vilao esquerda e direita
    public void Flip()
    {
        Face = !Face;
        Scale = this.transform.localScale;
        Scale.x *= -1;
        this.transform.localScale = Scale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            ReleaseChase = true;
            Debug.Log("Encostou");
        }
      

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ReleaseChase = false;
        }
    }
}
