using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    [SerializeField] float multipler = 3;
    private Animator anim;
    Color _baseColor;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        _baseColor = GetComponent<MeshRenderer>().material.color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            collision.gameObject.GetComponent<Rigidbody>().velocity *= multipler;
            anim.Play("bumber_bounce_anim");
            GetComponent<MeshRenderer>().material.color = Color.blue;
            StartCoroutine(ChangeColor(_baseColor));
        }
    }

    IEnumerator ChangeColor(Color _color)
    {
        yield return new WaitForSeconds(0.3f);
        GetComponent<MeshRenderer>().material.color = _color;
    }
}
