using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArchitectManager : MonoBehaviour
{
    public static ArchitectManager Instance { get; private set; }

    //건물변수 모음집
    #region
    [Header("Floor")]
    public GameObject WallFloor;
    public GameObject HouseFloor;
    public GameObject StorageFloor;
    public GameObject FarmFloor;
    public GameObject TempleFloor;
    public GameObject TowerFloor;
    public GameObject BarrackFloor;
    public GameObject CenterFloor;
    public GameObject ArcheryFloor;

    [Header("Building1")]
    public GameObject Wall1;
    public GameObject House1;
    public GameObject Storage1;
    public GameObject Farm1;
    public GameObject Temple1;
    public GameObject Tower1;
    public GameObject Barrack1;
    public GameObject Center1;
    public GameObject Archery1;

    [Header("Building2")]
    public GameObject Wall2;
    public GameObject House2;
    public GameObject Storage2;
    public GameObject Farm2;
    public GameObject Farm3;
    public GameObject Temple2;
    public GameObject Temple3;
    public GameObject Tower2;
    public GameObject Barrack2;
    public GameObject Center2;
    public GameObject Archery2;
    #endregion

    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }
    }


    //건물 생성 함수
    public void MakeWall()
    {
        WallFloor.SetActive(false);
        Wall1.SetActive(true);
    }


    public void MakeHouse()
    {
        Debug.Log("MakeHouse");
        HouseFloor.SetActive(false);
        House1.SetActive(true);
    }


    public void MakeStorage()
    {
        StorageFloor.SetActive(false);
        Storage1.SetActive(true);
    }

    public void MakeFarm()
    {
        FarmFloor.SetActive(false);
        Farm1.SetActive(true);
    }

    public void MakeTemple()
    {
        TempleFloor.SetActive(false);
        Temple1.SetActive(true);
    }

    public void MakeBarrack()
    {
        BarrackFloor.SetActive(false);
        Barrack1.SetActive(true);
    }

    public void MakeArchery()
    {
        ArcheryFloor.SetActive(false);
        Archery1.SetActive(true);
    }

    public void MakeCenter()
    {
        CenterFloor.SetActive(false);
        Center1.SetActive(true);
    }

    public void MakeTower()
    {
        TowerFloor.SetActive(false);
        Tower1.SetActive(true);
    }

    //건물 업그레이드 함수
    public void UpgradeWall()
    {
        Wall1.SetActive(false);
        Farm1.SetActive(false);
        Temple1.SetActive(false);
        House1.SetActive(false);

        Wall2.SetActive(true);
        Farm2.SetActive(true);
        Temple2.SetActive(true);
        House2.SetActive(true);

        CenterFloor.SetActive(true);
        BarrackFloor.SetActive(true);
        ArcheryFloor.SetActive(true);
        TowerFloor.SetActive(true);

    }

    public void UpgradeStorage()
    {
        Storage1.SetActive(false);
        Storage2.SetActive(true);
    }

    public void UpgradeFarm()
    {
        Farm2.SetActive(false);
        Farm3.SetActive(true);
    }

    public void UpgradeTemple()
    {
        Temple2.SetActive(false);
        Temple3.SetActive(true);
    }
    public void UpgradeBarrack()
    {
        Barrack1.SetActive(false);
        Barrack2.SetActive(true);
    }

    public void UpgradeArchery()
    {
        Archery1.SetActive(false);
        Archery2.SetActive(true);
    }
    public void UpgradeCenter()
    {
        Center1.SetActive(false);
        Center2.SetActive(true);
    }

    public void UpgradeTower()
    {
        Tower1.SetActive(false);
        Tower2.SetActive(true);
    }
}
