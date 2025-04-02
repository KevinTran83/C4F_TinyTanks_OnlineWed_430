using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class HPEvent : UnityEvent<float> {}

public class HP : MonoBehaviour
{
    public float currentHP,
                 maxHP = 10;
    public UnityEvent onDeath;
    public HPEvent    onChange;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHP = maxHP;
        onChange.Invoke( currentHP/maxHP );
    }

    public void ChangeHP(float amount)
    {
        currentHP += amount;
        currentHP = Mathf.Clamp(currentHP, 0.0f, maxHP);
        onChange.Invoke( currentHP/maxHP );
        if (currentHP == 0.0f) onDeath.Invoke();
    }
}
