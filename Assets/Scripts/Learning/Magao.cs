using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magao : MonoBehaviour
{
    public GameObject FireBall;
    public float vel;

    public AudioClip Som;
    // Start is called before the first frame update
    void Start()
    {
        vel = 5;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * vel * Time.deltaTime, 0, 0));

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Coin")) {
            GerenciadorDeSom.Inst.PlayAudio(Som);
            Destroy(other.gameObject);
        }
    }
}
