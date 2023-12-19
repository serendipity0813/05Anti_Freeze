using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;

enum BuildingType{
    Wall,
    House,
    Tower,
    Storage,
    Barrack,
    Center,
    Farm,
    Archery,
    Temple
}

public class ArchitectUIHandler : MonoBehaviour
{
    public GameObject MakeBuildingUI;
    public GameObject UpgradeBuildingUI;
    public GameObject FailUI;
    public TextMeshProUGUI nameTxt;
    public TextMeshProUGUI descriptionTxt;
    public TextMeshProUGUI ingredient1Txt;
    public TextMeshProUGUI ingredient2Txt;


    private void MakeBuilding(BuildingType type)
    {

        switch (type)
        {

            case BuildingType.House:
                //재료가 충분한지 판단하는 코드 필요
                ArchitectManager.Instance.MakeHouse();
                break;

        }

    }


    private void ShowArcitectUI(BuildingType type)
    {
        switch(type)
        {
            case BuildingType.Wall:

                break;

            case BuildingType.House:
                nameTxt.text = "Make House";
                descriptionTxt.text = "+1 HP / S";
                ingredient1Txt.text = "-10";
                ingredient1Txt.text = "-10";
                break;

        }
        
        MakeBuildingUI.SetActive(true);
    }

    public void ShowHouseUI()
    {
        Debug.Log("click");
        ShowArcitectUI(BuildingType.House);
    }

    public void MakeHouse()
    {
        MakeBuilding(BuildingType.House);
    }
}
