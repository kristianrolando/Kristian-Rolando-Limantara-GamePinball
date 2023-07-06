using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    [SerializeField] Material[] _material;
    [SerializeField] float multipler = 3;
    
    Animator anim;
    MeshRenderer _mesh;
    int id;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        _mesh = GetComponent<MeshRenderer>();
        ChangeColor();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            collision.gameObject.GetComponent<Rigidbody>().velocity *= multipler;
            anim.Play("bumber_bounce_anim");
            ChangeColor();
        }
    }
    private void ChangeColor()
    {
        _mesh.material = _material[id];
        id++;
        if (id >= _material.Length)
            id = 0;
    }
}
