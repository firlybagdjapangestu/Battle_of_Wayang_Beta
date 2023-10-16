using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyStatus : MonoBehaviour
{
    public HealthBar healthbar;
    public float hp, maxHp;
    public Transform playerPosition;
    private float jarak;
    private FuzzyScript fuzzyLogic;
    public bool turnEnemy;
    public UnityEvent[] enemyMove; 

    private void Awake()
    {
        maxHp = hp;
        healthbar.setMaxHP(maxHp);
        fuzzyLogic = GetComponent<FuzzyScript>();
    }

    private void Update()
    {
        jarak = Vector2.Distance(transform.position, playerPosition.transform.position);
        fuzzyLogic.Fuzzy(hp, jarak);
        EnemyController();
    }
    public void ONOFF()
    {
        if (turnEnemy)
        {
            turnEnemy = false;
        }
        else
        {
            turnEnemy = true;
        }
    }

    public void EnemyController()
    {
       
        if (!turnEnemy || hp <= 0) return ;
        if (fuzzyLogic.Fuzzy(hp, jarak) >= 90)
        {
            enemyMove[0].Invoke();
        }
        else if (fuzzyLogic.Fuzzy(hp, jarak) >= 60 && fuzzyLogic.Fuzzy(hp, jarak) <= 90)
        {
            enemyMove[1].Invoke();
        }
        else if (fuzzyLogic.Fuzzy(hp, jarak) <= 50 && fuzzyLogic.Fuzzy(hp, jarak) > 0)
        {
            enemyMove[2].Invoke();
        }
    }

}
