using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivaGatilho : MonoBehaviour
{
    public GameObject Arma;

    public bool TravaGatilho;

    // Start is called before the first frame update
    void Start()
    {
        TravaGatilho = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(TravaGatilho == false) {
            Arma.gameObject.transform.Rotate(new Vector3(0, 0, 5 * Time.deltaTime));
            //Arma.GetComponent<Atirar>().Shoot();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Magao")) {
            TravaGatilho = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Magao")) {
            TravaGatilho = true;
        }
    }
}
