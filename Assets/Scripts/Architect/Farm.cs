using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : MonoBehaviour
{
    public GameObject Carrot;
    public GameObject Farm1;
    public GameObject Farm2;
    public GameObject Farm3;
    public Transform SpawnPosition1;
    public Transform SpawnPosition2;
    public Transform SpawnPosition3;

    void Start()
    {

        InvokeRepeating("Farming", 0, 30);
    }

    private void Farming()
    {
        if (Farm3.activeSelf == true)
            MakeCarrot3();
        else if (Farm2.activeSelf == true)
            MakeCarrot2();
        else if (Farm1.activeSelf == true)
            MakeCarrot();

    }

    private void MakeCarrot()
    {
        Instantiate(Carrot, SpawnPosition1);
    }
    private void MakeCarrot2()
    {
        Instantiate(Carrot, SpawnPosition2);
    }

    private void MakeCarrot3()
    {
        Instantiate(Carrot, SpawnPosition3);
        Instantiate(Carrot, SpawnPosition3);
    }
}
