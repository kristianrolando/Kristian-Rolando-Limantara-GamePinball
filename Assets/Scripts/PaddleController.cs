using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] KeyCode input;
    public float sprintPower;
    HingeJoint _hingeJoint;
    

    private void Start()
    {
        _hingeJoint = GetComponent<HingeJoint>();
    }
    private void Update()
    {
        ReadInput();
    }
    private void ReadInput()
    {
        JointSpring _jointSpring = _hingeJoint.spring;
        if(Input.GetKey(input))
        {
            _jointSpring.spring = sprintPower;
        }
        else
        {
            _jointSpring.spring = 0;
        }
        _hingeJoint.spring = _jointSpring;
    }

}
