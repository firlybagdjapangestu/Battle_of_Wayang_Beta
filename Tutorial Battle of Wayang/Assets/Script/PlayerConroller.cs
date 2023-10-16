using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConroller : MonoBehaviour
{
    public Transform enemy;
    private Arms arms;
    private float maxhp;
    public HealthBar healthbar;
    public float hp;
    public FixedJoint2D head;
    void Start()
    {
        Collider2D[] coliders = transform.GetComponentsInChildren<Collider2D>();
        for(int i = 0; i < coliders.Length; i++)
        {
            for(int j = i + 1; j < coliders.Length; j++)
            {
                Physics2D.IgnoreCollision(coliders[i], coliders[j]);
            }
        }
        arms = FindObjectOfType<Arms>();
        maxhp = hp;
        healthbar.setMaxHP(maxhp);
    }
    private void Update()
    {
        if (hp <= 0)
        {
            arms.enabled = false;
            head.enabled = false;
        }
    }
}
