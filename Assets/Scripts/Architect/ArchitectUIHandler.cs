using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;
using System;
using UnityEditor.Experimental.GraphView;

enum BuildingType{
    Wall,
    House,
    Storage,
    Temple,
    Farm,
    Tower,
    Barrack,
    Center,
    Archery,
}

public class ArchitectUIHandler : MonoBehaviour
{
    public GameObject MakeBuildingUI;
    public GameObject UpgradeBuildingUI;
    public GameObject FailUI;
    public GameObject WallUpgradeFailUI;

    public TextMeshProUGUI nameTxt;
    public TextMeshProUGUI descriptionTxt;
    public TextMeshProUGUI ingredient1Txt;
    public TextMeshProUGUI ingredient2Txt;

    public TextMeshProUGUI upgradenameTxt;
    public TextMeshProUGUI upgradedescriptionTxt;
    public TextMeshProUGUI upgradeingredient1Txt;
    public TextMeshProUGUI upgradeingredient2Txt;

    private int[] buildingLevel;
    private bool[] BuildingCheck
    {
        get { return buildingCheck; }
        set { buildingCheck = value; }
    }
        private bool[] buildingCheck;


    private void Start()
    {
        buildingLevel = new int[10];
        BuildingCheck = new bool[10];

        for(int i=0; i<BuildingCheck.Length; i++)
        {
            BuildingCheck[i] = false;
        }
    }



    private void MakeBuilding(BuildingType type)
    {
        switch (type)
        {
            case BuildingType.Wall:
                ArchitectManager.Instance.MakeWall();
                buildingLevel[0]++;
                BuildingCheck[0] = false;
                break;

            case BuildingType.House:
                ArchitectManager.Instance.MakeHouse();
                buildingLevel[1]++;
                BuildingCheck[1] = false;
                break;

            case BuildingType.Storage:
                ArchitectManager.Instance.MakeStorage();
                buildingLevel[2]++;
                BuildingCheck[2] = false;
                break;

            case BuildingType.Temple:
                ArchitectManager.Instance.MakeTemple();
                buildingLevel[3]++;
                BuildingCheck[3] = false;
                break;

            case BuildingType.Farm:
                ArchitectManager.Instance.MakeFarm();
                buildingLevel[4]++;
                BuildingCheck[4] = false;
                break;

            case BuildingType.Tower:
                ArchitectManager.Instance.MakeTower();
                buildingLevel[5]++;
                BuildingCheck[5] = false;
                break;

            case BuildingType.Barrack:
                ArchitectManager.Instance.MakeBarrack();
                buildingLevel[6]++;
                BuildingCheck[6] = false;
                break;

            case BuildingType.Center:
                ArchitectManager.Instance.MakeCenter();
                buildingLevel[7]++;
                BuildingCheck[7] = false;
                break;

            case BuildingType.Archery:
                ArchitectManager.Instance.MakeArchery();
                buildingLevel[8]++;
                BuildingCheck[8] = false;
                break;


        }

        MakeBuildingUI.SetActive(false);
    }

    private void UpgradeBuilding(BuildingType type)
    {
        switch (type)
        {
            case BuildingType.Wall:
                ArchitectManager.Instance.UpgradeWall();
                buildingLevel[0]++;
                BuildingCheck[0] = false;
                break;

            case BuildingType.Storage:
                ArchitectManager.Instance.UpgradeStorage();
                buildingLevel[2]++;
                BuildingCheck[2] = false;
                break;

            case BuildingType.Temple:
                ArchitectManager.Instance.UpgradeTemple();
                buildingLevel[3]++;
                BuildingCheck[3] = false;
                break;

            case BuildingType.Farm:
                ArchitectManager.Instance.UpgradeFarm();
                buildingLevel[4]++;
                BuildingCheck[4] = false;
                break;

            case BuildingType.Tower:
                ArchitectManager.Instance.UpgradeTower();
                buildingLevel[5]++;
                BuildingCheck[5] = false;
                break;

            case BuildingType.Barrack:
                ArchitectManager.Instance.UpgradeBarrack();
                buildingLevel[6]++;
                BuildingCheck[6] = false;
                break;

            case BuildingType.Center:
                ArchitectManager.Instance.UpgradeCenter();
                buildingLevel[7]++;
                BuildingCheck[7] = false;
                break;

            case BuildingType.Archery:
                ArchitectManager.Instance.UpgradeArchery();
                buildingLevel[8]++;
                BuildingCheck[8] = false;
                break;
        }
        UpgradeBuildingUI.SetActive(false);
    }


    private void ShowArcitectUI(BuildingType type)
    {
        switch(type)
        {
            case BuildingType.Wall:
                nameTxt.text = "Make Wall";
                descriptionTxt.text = "Protection against monsters";
                ingredient1Txt.text = "-20";
                ingredient2Txt.text = "0";
                break;

            case BuildingType.House:
                nameTxt.text = "Make House";
                descriptionTxt.text = "+1 Temp / S";
                ingredient1Txt.text = "-10";
                ingredient2Txt.text = "-10";
                break;

            case BuildingType.Storage:
                nameTxt.text = "Make Storage";
                descriptionTxt.text = "You can store more items";
                ingredient1Txt.text = "-10";
                ingredient2Txt.text = "0";
                break;

            case BuildingType.Temple:
                nameTxt.text = "Make Temple";
                descriptionTxt.text = "Make Water";
                ingredient1Txt.text = "-30";
                ingredient2Txt.text = "-0";
                break;

            case BuildingType.Farm:
                nameTxt.text = "Make Farm";
                descriptionTxt.text = "Make Carrot";
                ingredient1Txt.text = "-10";
                ingredient2Txt.text = "-10";
                break;

            case BuildingType.Tower:
                nameTxt.text = "Make Tower";
                descriptionTxt.text = "+1 Temp / S";
                ingredient1Txt.text = "-20";
                ingredient2Txt.text = "0";
                break;

            case BuildingType.Barrack:
                nameTxt.text = "Make Barrack";
                descriptionTxt.text = "Get New Weapon";
                ingredient1Txt.text = "-20";
                ingredient2Txt.text = "-0";
                break;

            case BuildingType.Center:
                nameTxt.text = "Make Center";
                descriptionTxt.text = "+1 HP / S";
                ingredient1Txt.text = "-30";
                ingredient2Txt.text = "-10";
                break;

            case BuildingType.Archery:
                nameTxt.text = "Make Archery";
                descriptionTxt.text = "+1 Atk Range ";
                ingredient1Txt.text = "-20";
                ingredient2Txt.text = "0";
                break;


        }
        
        MakeBuildingUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    private void ShowUpgradeUI(BuildingType type)
    {
        switch (type)
        {
            case BuildingType.Wall:
                upgradenameTxt.text = "Upgrade Wall";
                upgradedescriptionTxt.text = "Size Expansion";
                upgradeingredient1Txt.text = "0";
                upgradeingredient2Txt.text = "-20";
                break;

            case BuildingType.Storage:
                upgradenameTxt.text = "upgrade Storage";
                upgradedescriptionTxt.text = "You can store more more items";
                upgradeingredient1Txt.text = "0";
                upgradeingredient2Txt.text = "-20";
                break;

            case BuildingType.Temple:
                upgradenameTxt.text = "upgrade Temple";
                upgradedescriptionTxt.text = "Make More Water";
                upgradeingredient1Txt.text = "-0";
                upgradeingredient2Txt.text = "-30";
                break;

            case BuildingType.Farm:
                upgradenameTxt.text = "upgrade Farm";
                upgradedescriptionTxt.text = "Make More Carrot";
                upgradeingredient1Txt.text = "0";
                upgradeingredient2Txt.text = "-20";
                break;

            case BuildingType.Tower:
                upgradenameTxt.text = "upgrade Tower";
                upgradedescriptionTxt.text = "+2 Temp / S.";
                upgradeingredient1Txt.text = "0";
                upgradeingredient2Txt.text = "-20";
                break;

            case BuildingType.Barrack:
                upgradenameTxt.text = "Get Special Weapon";
                upgradedescriptionTxt.text = "+20 ATK";
                upgradeingredient1Txt.text = "-0";
                upgradeingredient2Txt.text = "-20";
                break;

            case BuildingType.Center:
                upgradenameTxt.text = "upgrade Center";
                upgradedescriptionTxt.text = "+2 HP / S";
                upgradeingredient1Txt.text = "-10";
                upgradeingredient2Txt.text = "-30";
                break;

            case BuildingType.Archery:
                upgradenameTxt.text = "upgrade Archery";
                upgradedescriptionTxt.text = "+3 Atk Range ";
                upgradeingredient1Txt.text = "0";
                upgradeingredient2Txt.text = "-20";
                break;


        }

        UpgradeBuildingUI.SetActive(true);
    }


    //건물 생성 버튼 상호작용 함수
    #region

    public void MakeBtn()
    {    

        if (BuildingCheck[0])
            MakeWall();
        else if (BuildingCheck[1])
            MakeHouse();
        else if (BuildingCheck[2])
            MakeStorage();
        else if (BuildingCheck[3])
            MakeTemple();
        else if (BuildingCheck[4])
            MakeFarm();
        else if (BuildingCheck[5])
            MakeTower();
        else if (BuildingCheck[6])
            MakeBarrack();
        else if (BuildingCheck[7])
            MakeCenter();
        else if (BuildingCheck[8])
            MakeArchery();

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void MakeWall()
    {
        if (buildingLevel[0] == 0)
            MakeBuilding(BuildingType.Wall);
        else if (buildingLevel[0] == 1)
        {
            if (buildingLevel[1] == 1 && buildingLevel[2] == 1 && buildingLevel[3] == 1)
                UpgradeBuilding(BuildingType.Wall);
            else
                WallUpgradeFailUI.SetActive(true);
        }

    }

    private void MakeHouse()
    {
        if (buildingLevel[1] == 0)
            MakeBuilding(BuildingType.House);
        else if (buildingLevel[1] == 1)
            UpgradeBuilding(BuildingType.House);
    }

    private void MakeStorage()
    {
        if (buildingLevel[2] == 0)
            MakeBuilding(BuildingType.Storage);
        else if (buildingLevel[2] == 1)
            UpgradeBuilding(BuildingType.Storage);
    }

    private void MakeTemple()
    {
        if (buildingLevel[3] == 0)
            MakeBuilding(BuildingType.Temple);
        else if (buildingLevel[3] == 1)
            UpgradeBuilding(BuildingType.Temple);
    }


    private void MakeFarm()
    {
        if (buildingLevel[4] == 0)
            MakeBuilding(BuildingType.Farm);
        else if (buildingLevel[4] == 1)
            UpgradeBuilding(BuildingType.Farm);
    }



    private void MakeTower()
    {
        if (buildingLevel[5] == 0)
            MakeBuilding(BuildingType.Tower);
        else if (buildingLevel[5] == 1)
            UpgradeBuilding(BuildingType.Tower);
    }

    private void MakeBarrack()
    {
        if (buildingLevel[6] == 0)
            MakeBuilding(BuildingType.Barrack);
        else if (buildingLevel[6] == 1)
            UpgradeBuilding(BuildingType.Barrack);
    }

    private void MakeCenter()
    {
        if (buildingLevel[7] == 0)
            MakeBuilding(BuildingType.Center);
        else if (buildingLevel[7] == 1)
            UpgradeBuilding(BuildingType.Center);
    }

    private void MakeArchery()
    {
        if (buildingLevel[8] == 0)
            MakeBuilding(BuildingType.Archery);
        else if (buildingLevel[8] == 1)
            UpgradeBuilding(BuildingType.Archery);
    }
    #endregion


    //건물 생선 전 바닥 버튼 상호작용 함수
    #region
    public void ShowWallUI()
    {
        if (buildingLevel[0] == 0)
        {
            ShowArcitectUI(BuildingType.Wall);
            BuildingCheck[0] = true;
        }
        else
        {
            ShowUpgradeUI(BuildingType.Wall);
            BuildingCheck[0] = true;
        }
  
    }

    public void ShowHouseUI()
    {
        if (buildingLevel[1] == 0)
        {
            BuildingCheck[1] = true;
            ShowArcitectUI(BuildingType.House);
        }
        else
        {
            ShowUpgradeUI(BuildingType.House);
            BuildingCheck[1] = true;
        }
    }

    public void ShowStorageUI()
    {
        if (buildingLevel[2] == 0)
        {
            ShowArcitectUI(BuildingType.Storage);
            BuildingCheck[2] = true;
        }
        else
        {
            ShowUpgradeUI(BuildingType.Storage);
            BuildingCheck[2] = true;
        }
    }

    public void ShowTempleUI()
    {
        if (buildingLevel[3] == 0)
        {
            ShowArcitectUI(BuildingType.Temple);
            BuildingCheck[3] = true;
        }
        else
        {
            ShowUpgradeUI(BuildingType.Temple);
            BuildingCheck[3] = true;
        }
    }


    public void ShowFarmUI()
    {
        if (buildingLevel[4] == 0)
        {
            ShowArcitectUI(BuildingType.Farm);
            BuildingCheck[4] = true;
        }
        else
        {
            ShowUpgradeUI(BuildingType.Farm);
            BuildingCheck[4] = true;
        }
    }

    

    public void ShowTowerUI()
    {
        if (buildingLevel[5] == 0)
        {
            ShowArcitectUI(BuildingType.Tower);
            BuildingCheck[5] = true;
        }
        else
        {
            ShowUpgradeUI(BuildingType.Tower);
            BuildingCheck[5] = true;
        }
    }


    public void ShowBarrackUI()
    {
        if (buildingLevel[6] == 0)
        {
            ShowArcitectUI(BuildingType.Barrack);
            BuildingCheck[6] = true;
        }
        else
        {
            ShowUpgradeUI(BuildingType.Barrack);
            BuildingCheck[6] = true;
        }
    }

    public void ShowCenterUI()
    {
        if (buildingLevel[7] == 0)
        {
            ShowArcitectUI(BuildingType.Center);
            BuildingCheck[7] = true;
        }
        else
        {
            ShowUpgradeUI(BuildingType.Center);
            BuildingCheck[7] = true;
        }
    }

    public void ShowArcheryUI()
    {
        if (buildingLevel[8] == 0)
        {
            ShowArcitectUI(BuildingType.Archery);
            BuildingCheck[8] = true;
        }
        else
        {
            ShowUpgradeUI(BuildingType.Archery);
            BuildingCheck[8] = true;
        }
    }

   
    #endregion

}
