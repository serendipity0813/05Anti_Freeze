using UnityEngine;

public class Center : MonoBehaviour
{
    private PlayerConditions condition;
    private GameObject player;
    public GameObject Center1;
    public GameObject Center2;
    // Start is called before the first frame update

    // Update is called once per frame
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        condition = player.GetComponent<PlayerConditions>();
        InvokeRepeating("Heal", 0, 1);
    }

    private void Heal()
    {
        if (Center1.activeSelf == true)
        {
            condition.Heal(1);
        }
        else if(Center2.activeSelf == true)
        {
            condition.Heal(2);
        }
    }
}
