using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public static MonsterManager instance;
    private float _checktime;
    public GameObject[] MonsterPrefebs;
    public GameObject Player;

    public int count = 0;
    private GameObject spawnMonster;
    private int _respawnTime = 3;
    private bool _respawnCheck;

    private Vector3 _spawnPos;

    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        _checktime = _checktime + Time.deltaTime;
        if (_respawnTime - _checktime < 0&& count<5)
        {
            float randomX = Random.Range(-10f, 10f);
            float randomY = 1f;
            float randomz = Random.Range(-10f, 10f);
            _spawnPos = new Vector3(randomX, randomY, randomz);

            int selection = Random.Range(0, MonsterPrefebs.Length);

            GameObject selectedPrefab = MonsterPrefebs[selection];
            spawnMonster =Instantiate(selectedPrefab, _spawnPos,Quaternion.identity);
            spawnMonster.GetComponent<SnowMonster>().player = Player;
            _checktime = 0;
            count++;
        }
    }
    
}
