using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovMagao : MonoBehaviour
{
    public GameObject Coin;
    public GameObject CoinSong;
    public float vel;
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
        if(Coin.gameObject.CompareTag("Coin")) {
            Instantiate(CoinSong, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.y), Quaternion.identity);
            Destroy(other.gameObject);
        

        }
    }
}
