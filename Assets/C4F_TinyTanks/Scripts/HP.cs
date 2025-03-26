using UnityEngine;
using UnityEngine.Events;

public class HP : MonoBehaviour
{
    public float currentHP,
                 maxHP = 10;
    public UnityEvent onDeath;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHP = maxHP;   
    }

    public void ChangeHP(float amount)
    {
        currentHP += amount;
        currentHP = Mathf.Clamp(currentHP, 0.0f, maxHP);
        if (currentHP == 0.0f) onDeath.Invoke();
    }
}
