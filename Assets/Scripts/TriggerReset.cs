using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerReset : MonoBehaviour
{
    [SerializeField] Transform _pos;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball")
        {
            other.gameObject.transform.position = _pos.position;
        }
    }
}
