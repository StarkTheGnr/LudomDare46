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

    [SerializeField]
    private bool _isDead = false;
    public bool IsDead { get => _isDead; set => _isDead = value; }

    public GameObject audioSource;


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
        if (!IsDead)
        {
            IsDead = true;
            if (dyingHandler == null)
            {
                if (gameObject.tag == "Entity")
                {
                    WaveHandler.enemyCount--;

                    Instantiate(audioSource, transform.position, transform.rotation).GetComponent<AudioSource>().Play();

                    print("enemy died");
                }

                Destroy(gameObject);
            }
            else
            {
                dyingHandler.SendMessage("Die");
            }
        }
    }
}
