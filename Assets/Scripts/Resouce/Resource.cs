using UnityEngine;

public class Resource : MonoBehaviour
{
    public ItemData itemToGive;
    public int quantityPerHit = 1;
    public int capacity;

    public void Gather(Vector3 hitPoint, Vector3 hitNormal)
    {
        for (int i = 0; i < quantityPerHit; i++)
        {
            if (capacity <= 0) { break; }
            capacity -= 1;
            Instantiate(itemToGive.dropPrefab, hitPoint + Vector3.up, Quaternion.LookRotation(hitNormal, Vector3.up));
        }

        if (capacity <= 0)
        {
            Destroy(gameObject);
            RespawnResource.instance.count--;
        }
    }


    /// <summary>
    /// 자원 수집 테스트용
    /// </summary>
    /// <param name="collision"></param>
   /* private void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < quantityPerHit; i++)
        {
            if (capacity <= 0) { break; }
            capacity -= 1;
            Instantiate(itemToGive.dropPrefab, this.transform.position, Quaternion.identity);
        }

        if (capacity <= 0) 
        {
            Destroy(gameObject);
            RespawnResource.instance.count--;
        }
        

    }*/
}