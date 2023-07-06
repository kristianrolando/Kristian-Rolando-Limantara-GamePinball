using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    Transform _pos;

    TrapController _controller;
    float _timeDestroy;
    float _time;

    public void Initial(TrapController controller, float time, Transform _pos)
    {
        _controller = controller;
        _timeDestroy = time;
        this._pos = _pos;
        _time = 0;
    }

    private void Update()
    {
        _time += Time.deltaTime;
        if (_time >= _timeDestroy)
        {
            SelftDestruct();
        }
    }

    private void SelftDestruct()
    {
        _controller._trapList.Remove(this.gameObject);
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            other.gameObject.transform.position = _pos.position;
            SelftDestruct();
        }
    }
}
