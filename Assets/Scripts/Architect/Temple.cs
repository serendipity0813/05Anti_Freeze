using UnityEngine;

public class Temple : MonoBehaviour
{
    public GameObject Water;
    public GameObject Temple1;
    public GameObject Temple2;
    public GameObject Temple3;
    public Transform SpawnPosition1;
    public Transform SpawnPosition2;
    public Transform SpawnPosition3;

    void Start()
    {

        InvokeRepeating("Pray", 0, 30);
    }

    private void Pray()
    {
        if (Temple3.activeSelf == true)
            MakeWater3();
        else if (Temple2.activeSelf == true)
            MakeWater2();
        else if (Temple1.activeSelf == true)
            MakeWater();

    }

    private void MakeWater()
    {
        Instantiate(Water, SpawnPosition1);
    }
    private void MakeWater2()
    {
        Instantiate(Water, SpawnPosition2);
    }

    private void MakeWater3()
    {
        Instantiate(Water, SpawnPosition3);
        Instantiate(Water, SpawnPosition3);
    }
}
