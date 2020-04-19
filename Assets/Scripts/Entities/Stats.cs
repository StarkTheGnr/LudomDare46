using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public Component dyingHandler;

    [SerializeField]
    private int _maxhealth = 100;
    public int MaxHealth
    {
        get => _maxhealth;
        set => _maxhealth = value;
    }

    [SerializeField]
    private int _health = 100;
    public int Health 
    { 
        get => _health; 
        set
        {
            _health = value;
            if (_health <= 0)
                Die();
        }
    }

    [SerializeField]
    private int _damage = 100;
    public int Damage { get => _damage; set => _damage = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Die()
    {
        if(dyingHandler == null)
        {
            Destroy(gameObject);
        }
        else
        {
            dyingHandler.SendMessage("Die");
        }
    }
}
