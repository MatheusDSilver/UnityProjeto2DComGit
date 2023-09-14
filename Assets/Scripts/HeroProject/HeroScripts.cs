using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HeroScripts : MonoBehaviour
{
    
    public Transform HeroiT;
    public Rigidbody2D HeroiRg;
    public Animator HeroiA;

    //Se for true, a face do heroi esta virada para a direita; false para a esquerda
    public bool Face = true;

    //Define a velocidade da caminhada
    public float Vel = 3f;

    //Define a velocidade de corrida
    public float RunVel;

    //Define a força do pulo
    public float forca;

    //Verifica se o heroi esta caminhando

    public bool Alive;



    //Verifica se o heroi esta pulando
    public bool LiberaPulo;

    public Transform Check;

    public float Raio = 0.2f;

    public LayerMask oqEChao;


    public float CoinCount;
    //public Text CoinTxt;

    public TMP_Text CoinTMP;

    public RawImage rImg;



    // Start is called before the first frame update
    void Start()
    {
        HeroiT = GetComponent<Transform>();
        HeroiRg = GetComponent<Rigidbody2D>();
        HeroiA = GetComponent<Animator>();
        Alive = true;

        forca = 6f;

        LiberaPulo = true;

        RunVel = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        //RawImage
        Rect temp = new Rect(rImg.uvRect);
        temp.x += 0.3f * Time.deltaTime;
        rImg.uvRect = temp;

        //uvRect é do tipo Rect, por isso ele precisa receber um rect. Lembra: int recebe int, double recebe double...
        //Fim

        if (Alive)
        {
            //Virar o personagem para a esquerda e direita
            if (Input.GetKey(KeyCode.RightArrow) && !Face)
            {
                Flip();
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && Face)
            {
                Flip();
            }
        }

   
        if(Alive)
        {

            LiberaPulo = Physics2D.OverlapCircle(Check.position, Raio, oqEChao);
            Debug.Log(LiberaPulo);

            //Correr
            if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftShift) && LiberaPulo)
            {
                transform.Translate(new Vector2(RunVel * Time.deltaTime, 0));
                HeroiA.SetBool("Idle", false);
                HeroiA.SetBool("Walk", false);
                HeroiA.SetBool("Run", true);
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.LeftShift) && LiberaPulo)
            {
                transform.Translate(new Vector2(-RunVel * Time.deltaTime, 0));
                HeroiA.SetBool("Idle", false);
                HeroiA.SetBool("Walk", false);
                HeroiA.SetBool("Run", true);

            }
            //Andar
            else if (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftShift) && LiberaPulo)
            {
                
                transform.Translate(new Vector2(Vel * Time.deltaTime, 0));
                HeroiA.SetBool("Idle", false);
                HeroiA.SetBool("Walk", true);
                HeroiA.SetBool("Run", false);
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.LeftShift) && LiberaPulo)
            {

                transform.Translate(new Vector2(-Vel * Time.deltaTime, 0));
                HeroiA.SetBool("Idle", false);
                HeroiA.SetBool("Walk", true);
                HeroiA.SetBool("Run", false);
            }
            //Ocioso
            else if(!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
            {
                HeroiA.SetBool("Idle", true);
                HeroiA.SetBool("Walk", false);
                HeroiA.SetBool("Run", false);
            }

            //Pular Correndo
            if(Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.Space) && LiberaPulo)
            {
                
                HeroiRg.velocity = new Vector2(10, 6);
                Pular();
                HeroiA.SetBool("Run", false);
                HeroiA.SetBool("SideJump", true);
            }
            else if(Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.LeftShift) && LiberaPulo)
            {
               
                HeroiRg.velocity = new Vector2(-10, 6);
                Pular();
                HeroiA.SetBool("Run", false);
                HeroiA.SetBool("SideJump", true);
            }
            //Pular Andando
            else if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftShift) && LiberaPulo)
            {
         
                HeroiRg.velocity = new Vector2(3, 6);
                Pular();
                HeroiA.SetBool("Walk", false);
                HeroiA.SetBool("SideJump", true);
            }
            else if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.LeftShift) && LiberaPulo)
            {
                
                HeroiRg.velocity = new Vector2(-3, 6);
                Pular();
                HeroiA.SetBool("Walk", false);
                HeroiA.SetBool("SideJump", true);
            }
            //Pular Parado
            else if (Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.LeftShift) && LiberaPulo)
            {
                
                HeroiRg.velocity = new Vector2(0, 6);
                Pular();
                HeroiA.SetBool("SideJump", true);
                HeroiA.SetBool("Idle", false);
            }
            //else if (!Jumping)
            //{
            //    HeroiA.SetBool("SideJump", false);
            //}

        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {

            HeroiA.SetBool("SideJump", false);
            HeroiA.SetBool("Idle", true);

            //Zera a velocidade do personagem em X e Y quando ele pousa no chão
            //HeroiRg.velocity = new Vector2(0, 0);

            //Jumping = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Coin"))
        {
            CoinCount++;
            CoinTMP.text = CoinCount.ToString();
            Destroy(collision.gameObject);


        }
    }


    public void Flip()
    {
        Face = !Face;
        Vector3 Escala = HeroiT.localScale;

        Escala.x *= -1;

        HeroiT.localScale = Escala;

    }

    public void Pular()
    {
        LiberaPulo = false;
        HeroiRg.AddForce(new Vector2(0, forca), ForceMode2D.Impulse);
    }
}
