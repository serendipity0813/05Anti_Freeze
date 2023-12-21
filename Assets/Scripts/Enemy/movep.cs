using UnityEngine;

public class movep : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody charRigidbody;

    void Start()
    {
        charRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");

        Vector3 inputDir = new Vector3(hAxis, 0, vAxis).normalized;

        charRigidbody.velocity = inputDir * moveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bullet")){
            Debug.Log("충돌체크");
            //데미지 
            other.gameObject.SetActive(false);
        }
    }
}
