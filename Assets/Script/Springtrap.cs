using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Springtrap : MonoBehaviour
{
    float power;
    private float maxPower = 100f;
    public Slider powerSlider;
    List<Rigidbody> rball;
    bool ballReady;
    
    void Start()
    {
        powerSlider.minValue = 0f;
        powerSlider.maxValue = maxPower;
        rball= new List<Rigidbody>();
    }

    
    void Update()
    {
        if (ballReady) 
        { 
            powerSlider.gameObject.SetActive(true);
        }
        else
        {
            powerSlider.gameObject.SetActive(false);
        }

        powerSlider.value = power;

        if (rball.Count > 0 ) 
        {
            ballReady = true;
            if(Input.GetKey(KeyCode.Space))
            {
                if(power<=maxPower) 
                {
                    power += 50 * Time.deltaTime;
                }
            }
            if(Input.GetKeyUp(KeyCode.Space)) 
            {
                foreach(Rigidbody rb in rball) 
                {
                    rb.AddForce(power * 20 * Vector3.up);
                }
            }
        }
        else
        {
            ballReady=false;
            power = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("bal"))
        {
            rball.Add(other.gameObject.GetComponent<Rigidbody>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("bal"))
        {
            rball.Remove(other.gameObject.GetComponent<Rigidbody>());
            power = 0f;
        }
    }
}
