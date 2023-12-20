using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class environment : MonoBehaviour
{
    public float cooltime; // 쿨타임, 감소값
    public float pertime; // 쿨타임, 절대값

    public Transform coaltransform; // 석탄 생성 위치
    public Transform coaltransform1; // 석탄 생성 위치1
    public Transform coaltransform2; // 석탄 생성 위치2
    public Transform coaltransform3; // 석탄 생성 위치3
    public Transform coaltransform4; // 석탄 생성 위치4
    public Transform coaltransform5; // 석탄 생성 위치5



    public GameObject rock; /// 돌 오브젝트 1~@
    public GameObject tree; /// 나무 오브젝트 1~@
    public GameObject coal; /// 석탄 오브젝트 1~@

    public GameObject rock1;
    public GameObject tree1;
    public GameObject coal1;
    public GameObject rock2;
    public GameObject tree2;
    public GameObject coal2;
    public GameObject rock3;
    public GameObject tree3;
    public GameObject coal3;
    public GameObject rock4;
    public GameObject tree4;
    public GameObject coal4;
    public GameObject rock5;
    public GameObject tree5;
    public GameObject coal5;
    public GameObject rock6;
    public GameObject tree6;
    public GameObject coal6;
    public GameObject rock7;
    public GameObject tree7;
    public GameObject coal7;

    void Start()
    {
        
    }

  
    void Update()
    {

        cooltime -= Time.deltaTime; // 쿨타임 감소

        if (Input.GetKey(KeyCode.Alpha1)) // 임시로 바위 제거
        {
            Debug.Log("임시로 바위 제거");
            coal.SetActive(false); // 석탄 비활성화
        }

      

        if (cooltime <= 0)
        {
            coal.SetActive(true); // 석탄 활성화
            cooltime = pertime; // 쿨타임 초기화
        }

        

    }

    public void Environmentinstiate() // 테스트 코드
    {
        
    }
}
