using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDeSom : MonoBehaviour
{
    public AudioSource Som;
    public static GerenciadorDeSom Inst;
    // Start is called before the first frame update
    void Start()
    {
        Inst = this;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PlayAudio(AudioClip Musica){
        //Classes static aceitam apenas membros static
        Som.clip = Musica;
        Som.Play();

    }
}
