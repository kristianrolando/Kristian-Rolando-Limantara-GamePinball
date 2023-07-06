using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField] float maxTimeHold = 2.5f;
    [SerializeField] float maxLaunchPower = 20000f;
    [SerializeField] KeyCode input;

    Rigidbody _ballCollider;
    bool isBallTouching = false;
    bool isHold;
    float timeHold = 0;

    private void Update()
    {
        ReadInput();
    }
    void ReadInput()
    {
        if (Input.GetKey(input) && isBallTouching)
        {
            timeHold += Time.deltaTime;
            if (timeHold > maxTimeHold)
                timeHold = maxTimeHold;
        }
        if(Input.GetKeyUp(input) && isBallTouching)
        {
            float power = timeHold / maxTimeHold * maxLaunchPower;
            _ballCollider.AddForce(Vector3.forward * power, ForceMode.Force);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            isBallTouching = true;
            _ballCollider = collision.gameObject.GetComponent<Rigidbody>();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            isBallTouching = false;
        }
    }

}
