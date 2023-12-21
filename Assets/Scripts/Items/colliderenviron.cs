using UnityEngine;

public class Colliderenviron : MonoBehaviour
{
   
  

    private void OnTriggerEnter(Collider collision) // 채택, ontriggerenter는 자원을 캘 때 적합
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("자원 채광");
        }
    }

}


