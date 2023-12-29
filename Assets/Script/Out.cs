using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Out : MonoBehaviour
{

    private AudioSource playerAudio;
    public AudioSource bgm;


    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {        
        if(other.gameObject.CompareTag("bal"))
        {
            playerAudio.Play();
            bgm.GetComponent<AudioSource>().Stop();
            Destroy(other.gameObject);
            
        }
    }
}
