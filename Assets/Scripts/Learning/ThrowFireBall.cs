using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowFireBall : MonoBehaviour
{
    public GameObject FireBall;
    public GameObject SoundFireBall;

    public AudioClip Audio;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            Instantiate(FireBall, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.y), this.transform.rotation);

            // GerenciadorDeSom.Inst.PlayAudio(Audio);

            // Instantiate(SoundFireBall, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.y), this.transform.rotation);
        }

    }
}
