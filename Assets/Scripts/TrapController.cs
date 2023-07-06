using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    [SerializeField] GameObject _trapPref;
    [SerializeField] Transform[] _spawnPos;
    [SerializeField] float _timeTrap = 10f;
    [SerializeField] float _timeSpawn = 3f;
    [SerializeField] int maxTrapInScene = 3;

    [SerializeField] Transform _pos;

    [HideInInspector]
    public List<GameObject> _trapList = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(SpawnTrap());
    }
    private IEnumerator SpawnTrap()
    {
        yield return new WaitForSeconds(_timeSpawn);
        if (_trapList.Count < maxTrapInScene)
        {
            int _i = Random.Range(0, _spawnPos.Length);
            GameObject _obj = Instantiate(_trapPref, _spawnPos[_i].position, Quaternion.identity);
            _obj.GetComponent<Trap>().Initial(this, _timeTrap, _pos);
            _trapList.Add(_obj);
        }
        StartCoroutine(SpawnTrap());
    }
}
