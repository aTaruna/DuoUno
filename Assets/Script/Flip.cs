using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    //[SerializeField]
    private float restPost=0f;
    private float pressedPost = 90f;
    private float hit = 10000f;
    private float flipperdamp = 200f;
    HingeJoint joint;

    public string inputName;




    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<HingeJoint>();
        joint.useSpring = true;
    }

    // Update is called once per frame
    void Update()
    {
        JointSpring spring=new JointSpring();
        spring.spring = hit;
        spring.damper = flipperdamp;

        if(Input.GetAxis(inputName)==1) 
        {
            spring.targetPosition = pressedPost;
        }
        else
        {
            spring.targetPosition = restPost;
        }
        joint.spring = spring;
        joint.useLimits=true;
    }
}
