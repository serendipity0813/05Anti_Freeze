using System.Collections.Generic;
using UnityEngine;


public class RespawnResource : MonoBehaviour
{
    public static RespawnResource instance;
    private float _spawntime;
    private float _respawntime;
    public GameObject[] ResourcePrefabs;

    public int count = 0;
    private GameObject spawnResource;
    private int _respawnRate = 3;
    private bool _respawnCheck;

    private Queue<GameObject> _spawnQueue = new Queue<GameObject>();

    private Vector3 _spawnPos;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        _respawntime = _respawntime + Time.deltaTime;
        _spawntime = _spawntime + Time.deltaTime;

        spawn();
    }


    public void spawn()
    {
        if (_respawnRate - _spawntime < 0 && count < 5)
        {
            float randomX = Random.Range(this.transform.position.x-10, this.transform.position.x + 10);
            float randomY = 0f;
            float randomz = Random.Range(this.transform.position.z - 10, this.transform.position.z + 10);
            _spawnPos = new Vector3(randomX, randomY, randomz);

            int selection = Random.Range(0, ResourcePrefabs.Length);

            GameObject selectedPrefab = ResourcePrefabs[selection];
            spawnResource = Instantiate(selectedPrefab, _spawnPos, Quaternion.identity);

            _spawnQueue.Enqueue(spawnResource);
            _spawntime = 0;
            count++;
            Debug.Log(count);
        }
    }
}
