using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{

    private float _checktime;
    public GameObject MonsterPrefebs;
    public GameObject Player;

    private GameObject spawnMonster;
    private int _respawnTime = 3;
    private bool _respawnCheck;

    private Vector3 _spawnPos;

    private void Awake()
    {

    }
    void Update()
    {
        _checktime = _checktime + Time.deltaTime;
        if (_respawnTime - _checktime < 0)
        {
            float randomX = Random.Range(-10f, 10f);
            float randomY = 1f;
            float randomz = Random.Range(-10f, 10f);
            _spawnPos = new Vector3(randomX, randomY, randomz);
            spawnMonster =Instantiate(MonsterPrefebs, _spawnPos,Quaternion.identity);
            spawnMonster.GetComponent<SnowMonster>().player = Player;
            _checktime = 0;
        }
    }
    
}
