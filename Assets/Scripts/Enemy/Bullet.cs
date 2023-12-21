using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int dmg = 3;
    private void Update()
    {
        transform.Translate(Vector3.forward *0.03f);
    }
}
