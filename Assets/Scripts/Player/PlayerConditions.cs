using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

//public interface IDamagable
//{
//    void TakePhysicalDamage(int damageAmount);
//}

[System.Serializable]
public class Condition
{
    [HideInInspector]
    public float curValue;
    public float maxValue;
    public float startValue;
    public float regenRate;
    public float decayRate;
    public Image uiBar;

    public void Add(float amount)
    {
        curValue = Mathf.Min(curValue + amount, maxValue);
    }

    public void Subtract(float amount)
    { 
        curValue = Mathf.Max(curValue - amount, 0.0f);
    }

    public float GetPercentage()
    {
        return curValue / maxValue;
    }

}


public class PlayerConditions : MonoBehaviour, IDamagable
{
    public Condition health;
    public Condition hunger;
    public Condition Thirst;
    public Condition Temperature;

    public float noHungerHealthDecay;

    public UnityEvent onTakeDamage;

    void Start()
    {
        health.curValue = health.startValue;
        hunger.curValue = hunger.startValue;
        Thirst.curValue = Thirst.startValue;
        Temperature.curValue = Temperature.startValue;
    }

    // Update is called once per frame
    void Update()
    {
        hunger.Subtract(hunger.decayRate * Time.deltaTime);
        Thirst.Subtract(hunger.decayRate * Time.deltaTime);

        if (hunger.curValue == 0.0f)
            health.Subtract(noHungerHealthDecay * Time.deltaTime);

        if (Thirst.curValue == 0.0f)
            health.Subtract(noHungerHealthDecay * Time.deltaTime);

        if (health.curValue == 0.0f)
            Die();

        health.uiBar.fillAmount = health.GetPercentage();
        hunger.uiBar.fillAmount = hunger.GetPercentage();
        Thirst.uiBar.fillAmount = Thirst.GetPercentage();
        Temperature.uiBar.fillAmount = Temperature.GetPercentage();
    }

    public void Heal(float amount)
    {
        health.Add(amount);
    }

    public void Eat(float amount)
    {
        hunger.Add(amount);
    }

    public void Drink(float amount)
    {
        Thirst.Add(amount);
    }

    //public bool UseStamina(float amount)
    //{
    //    if (stamina.curValue - amount < 0)
    //        return false;

    //    stamina.Subtract(amount);
    //    return true;
    //}

    public void Die()
    {
        Debug.Log("플레이어가 죽었다.");
        //
    }

    public void TakePhysicalDamage(int damageAmount)
    {

        health.Subtract(damageAmount);
        onTakeDamage?.Invoke();
        Debug.Log("cur"+health.curValue);
        Debug.Log("dmg"+damageAmount);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bullet")) 
        {
            TakePhysicalDamage(3);
        }
    }
}