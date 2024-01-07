using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touc : MonoBehaviour
{

    public Material materi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("bal"))
        {
            GetComponent<MeshRenderer>().material.color= Color.green;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.CompareTag("bal"))
        {
            GetComponent<MeshRenderer>().material.color = Color.white;
        }
    }
}
