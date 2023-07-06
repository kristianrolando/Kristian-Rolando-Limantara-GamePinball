using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] GameObject _coinPref;
    [SerializeField] Transform[] _spawnPos;
    [SerializeField] float _timeCoin = 10f;
    [SerializeField] float _timeSpawn = 3f;
    [SerializeField] int maxCoinInScene = 3;

    [HideInInspector]
    public List<GameObject> _coinList = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(SpawnCoin());
    }
    private IEnumerator SpawnCoin()
    {
        yield return new WaitForSeconds(_timeSpawn);
        if(_coinList.Count < maxCoinInScene)
        {
            int _i = Random.Range(0, _spawnPos.Length);
            GameObject _obj = Instantiate(_coinPref, _spawnPos[_i].position, Quaternion.identity);
            _obj.GetComponent<Coin>().Initial(this, _timeCoin);
            _coinList.Add(_obj);
        }
        StartCoroutine(SpawnCoin());
    }


}
