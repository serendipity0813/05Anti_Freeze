using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterManager : MonoBehaviour
{
    public static MonsterManager instance;
    private float _spawntime;
    private float _respawntime;
    public GameObject[] MonsterPrefabs;
    public GameObject[] partPrefabs;
    public GameObject Player;

    public int count = 0;
    private GameObject spawnMonster;
    private GameObject[] splitMonster= new GameObject[3];
    private int _respawnRate = 3;
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
        /*if (_respawntime > 30)
        {
            destrymonster();
            _respawntime = 0;
        }*/
    }

    public  void split(GameObject snow)
    {
        splitMonster[0] = Instantiate(partPrefabs[0], snow.transform.position, Quaternion.identity);      
        splitMonster[1] = Instantiate(partPrefabs[1], snow.transform.position + new Vector3 (0.1f,0.1f,0) +Vector3.up *1, Quaternion.identity);
        splitMonster[2] = Instantiate(partPrefabs[2], snow.transform.position + new Vector3(-0.1f, -0.1f,0)+Vector3.up *2, Quaternion.identity);

        splitMonster[0].transform.localScale = snow.transform.localScale;
        splitMonster[1].transform.localScale = snow.transform.localScale;
        splitMonster[2].transform.localScale = snow.transform.localScale;

        StartCoroutine(InitObject(splitMonster[0]));
        StartCoroutine(InitObject(splitMonster[1]));
        StartCoroutine(InitObject(splitMonster[2]));
    }

    public void spawn()
    {
        if (_respawnRate - _spawntime < 0 && count < 5)
        {
            float randomX = Random.Range(this.transform.position.x-10, this.transform.position.x + 10);
            float randomY = 1f;
            float randomz = Random.Range(this.transform.position.z - 10, this.transform.position.z + 10);
            _spawnPos = new Vector3(randomX, randomY, randomz);

            int selection = Random.Range(0, MonsterPrefabs.Length);

            GameObject selectedPrefab = MonsterPrefabs[selection];
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
        
        yield return new WaitForSeconds(3f);
        Debug.Log(gameObject);
        _spawnQueue.Enqueue(gameObject);
        gameObject.GetComponent<SnowMonster>().enabled = true;
        gameObject.GetComponent<NavMeshAgent>().enabled = true;
        gameObject.GetComponent<SnowMonster>().player = Player;
        //Destroy(gameObject.GetComponent<Rigidbody>());
    }
}
