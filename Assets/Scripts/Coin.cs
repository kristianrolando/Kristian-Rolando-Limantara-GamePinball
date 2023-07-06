using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    CoinController _controller;
    float _timeDestroy;
    float _time;

    public void Initial(CoinController controller, float time)
    {
        _controller = controller;
        _timeDestroy = time;
        _time = 0;
    }

    private void Update()
    {
        transform.Rotate(transform.forward * Time.deltaTime * 150f);

        _time += Time.deltaTime;
        if(_time >= _timeDestroy)
        {
            SelftDestruct();
        }
    }
    
    private void SelftDestruct()
    {
        _controller._coinList.Remove(this.gameObject);
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            SelftDestruct();
        }
    }
}
