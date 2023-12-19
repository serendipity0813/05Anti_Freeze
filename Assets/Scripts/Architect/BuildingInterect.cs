using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingInterect : MonoBehaviour
{
    [SerializeField]
    private float range;
    private RaycastHit hitInfo;
    private LayerMask layerMask;
    public GameObject interectText;
    public GameObject buildingUI;

    // Update is called once per frame
    void Update()
    {
        CheckBuilding();

        if(interectText.activeSelf == true && Input.GetKeyDown(KeyCode.E))
        {
            InterectUIOff();
            BuildingUIOn();
        }
    }


    private void CheckBuilding()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, range, layerMask))
        {
            if (hitInfo.transform.tag == "Building")
            {
                InterectUIOn();
                if (interectText.activeSelf == true && Input.GetKeyDown(KeyCode.E))
                {
                    InterectUIOff();
                    BuildingUIOn();
                }
            }
        }
        else
            InterectUIOff();
    }

    private void InterectUIOn()
    {
        interectText.SetActive(true);
    }

    private void InterectUIOff()
    {
        interectText.SetActive(false);
    }
    private void BuildingUIOn()
    {
        buildingUI.SetActive(true);
    }


}
