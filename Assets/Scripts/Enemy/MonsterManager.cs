using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class MonsterManager : MonoBehaviour
{
    public static MonsterManager instance;
    private float _spawntime;
    private float _respawntime;
    public GameObject[] MonsterPrefebs;
    public GameObject[] partPrefebs;
    public GameObject Player;

    public int count = 0;
    private GameObject spawnMonster;
    private GameObject[] splitMonster= new GameObject[3];
    private int _respawnTime = 3;
    private bool _respawnCheck;
    private Queue<GameObject> _spawnQueue = new Queue<GameObject>();

    private Vector3 _spawnPos;

    [SerializeField]
    private ParticleSystem ParticleSystem;

    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        _respawntime = _respawntime + Time.deltaTime;
        _spawntime = _spawntime + Time.deltaTime;

        spawn();
        if (_respawntime > 30)
        {
            destrymonster();
            _respawntime = 0;
        }
    }

    public  void split(GameObject snow)
    {
        splitMonster[0] = Instantiate(partPrefebs[0], snow.transform.position, Quaternion.identity);      
        splitMonster[1] = Instantiate(partPrefebs[1], snow.transform.position + new Vector3 (0.1f,0.1f,0) +Vector3.up *1, Quaternion.identity);
        splitMonster[2] = Instantiate(partPrefebs[2], snow.transform.position + new Vector3(-0.1f, -0.1f,0)+Vector3.up *2, Quaternion.identity);

        StartCoroutine(InitObject(splitMonster[0]));
        StartCoroutine(InitObject(splitMonster[1]));
        StartCoroutine(InitObject(splitMonster[2]));
    }

    public void spawn()
    {
        if (_respawnTime - _spawntime < 0 && count < 5)
        {
            float randomX = Random.Range(-10f, 10f);
            float randomY = 1f;
            float randomz = Random.Range(-10f, 10f);
            _spawnPos = new Vector3(randomX, randomY, randomz);

            int selection = Random.Range(0, MonsterPrefebs.Length);

            GameObject selectedPrefab = MonsterPrefebs[selection];
            spawnMonster = Instantiate(selectedPrefab, _spawnPos, Quaternion.identity);
            spawnMonster.GetComponent<SnowMonster>().player = Player;
            spawnMonster.GetComponent<SnowMonster>().ParticleSystem = ParticleSystem;
            _spawnQueue.Enqueue(spawnMonster);
            _spawntime = 0;
            count++;
        }
    }
    public void destrymonster() 
    {
        Destroy(_spawnQueue.Dequeue(),1f);
        count--;
    }

    IEnumerator InitObject(GameObject gameObject)
    {
        
        yield return new WaitForSeconds(2f);
        Debug.Log(gameObject);
        _spawnQueue.Enqueue(gameObject);
        gameObject.GetComponent<SnowMonster>().enabled = true;
        gameObject.GetComponent<NavMeshAgent>().enabled = true;
        gameObject.GetComponent<SnowMonster>().player = Player;
        Destroy(gameObject.GetComponent<Rigidbody>());
    }
}
