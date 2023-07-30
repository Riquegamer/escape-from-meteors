using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnMeteors : MonoBehaviour
{
    public GameObject meteor;

    [SerializeField]
    private float _widght;

    [SerializeField]
    private float _maxTimer;

    [SerializeField]
    private float _timer;

    private void Update()
    {
        if (_timer > _maxTimer) 
        {
            GameObject newMeteor = Instantiate(meteor);
            newMeteor.transform.position = new Vector3(Random.Range(-_widght, _widght), 11f, 0);
            _timer = 0;
        }
        _timer += Time.deltaTime;
    }
}
