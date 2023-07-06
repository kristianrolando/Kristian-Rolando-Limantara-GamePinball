using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] Material _onMaterial;
    [SerializeField] Material _offMaterial;
    MeshRenderer _mesh;
    bool isOn;

    private void Awake()
    {
        _mesh = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball")
        {
            if (isOn)
                _mesh.material = _offMaterial;
            else
                _mesh.material = _onMaterial;
            isOn = !isOn;
        }
    }

}
