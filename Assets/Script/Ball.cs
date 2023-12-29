using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject ktp;
    

    private void OnCollisionEnter(Collision collision)
    {
        string tag = collision.gameObject.tag;
        switch(tag)
        {
            case "Point Seg":
                GameManager.instance.UpdateScore(10, 1);
                break;

            case "Point Bul":
                GameManager.instance.UpdateScore(20, 1);
                break;

            case "Alatas":
                GameManager.instance.UpdateScore(15,1);
                break;

            case "sekor":
                GameManager.instance.UpdateScore(5,1);
                break;

            case "Finish":
                GameManager.instance.GameEnd();
                break;



            default:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Katup"))
        {
            ktp.SetActive(true);
        }
    }
}
