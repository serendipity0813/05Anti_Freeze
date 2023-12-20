using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    private PlayerConditions condition;
    private GameObject player;
    private bool InOutCheck;
    public GameObject House1;
    public GameObject Tower1;
    public GameObject Tower2;
    // Start is called before the first frame update

    // Update is called once per frame
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        condition = player.GetComponent<PlayerConditions>();
        InvokeRepeating("Hot", 0, 1);
    }

    private void Hot()
    {
        if (House1.activeSelf == true && InOutCheck == true)
        {
            Debug.Log(condition.Temperature.curValue);
            if(condition.Temperature.curValue < 100)
            {
                condition.Temperature.Add(1);
                if (Tower1.activeSelf == true)
                    condition.Temperature.Add(1);
                if (Tower2.activeSelf == true)
                    condition.Temperature.Add(1);
            }
        

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            InOutCheck = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            InOutCheck = false;

    }
}
