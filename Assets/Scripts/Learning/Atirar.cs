using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirar : MonoBehaviour
{
    public GameObject Bala;
    public GameObject Cano;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(Bala, new Vector3(Cano.transform.position.x, Cano.transform.position.y, Cano.transform.position.z), Cano.transform.rotation);
        }
    }

    public void Shoot() {
        Instantiate(Bala, new Vector3(Cano.transform.position.x, Cano.transform.position.y, Cano.transform.position.z), Cano.transform.rotation);    
    }
}
