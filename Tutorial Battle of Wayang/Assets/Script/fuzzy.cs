using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fuzzy : MonoBehaviour
{
    //hp stuff
       
    /*public float armHpLeft;
    public float armHpRight;*/
    
    /*public HingeJoint2D armsLeft;
    public HingeJoint2D armsRight;*/

    public FixedJoint2D head;
    public Transform player;
    public Transform enemy;
    public EnemyController puji;
    public HealthBar healthbar;
    public bool prilaku;
    [Header("Fuzzy Stuff")]
    private float maxhp;
    public float hp;
    public float jarak;
    public float sedikit, sedang, banyak;
    public float jauh, dekat;
    public float[] a;
    public float[] z;
    public float hasil;
    void Start()
    {
        Collider2D[] coliders = transform.GetComponentsInChildren<Collider2D>();
        for (int i = 0; i < coliders.Length; i++)
        {
            for (int j = i + 1; j < coliders.Length; j++)
            {
                Physics2D.IgnoreCollision(coliders[i], coliders[j]);
            }
        }
        maxhp = hp;
       /* armHpLeft = hp;
        armHpRight = hp;*/
        healthbar.setMaxHP(maxhp);
        prilaku = false;
    }
  
    // Update is called once per frame
    void Update()
    {
        // untuk hp
        if (hp <= 30)
        {
            sedikit = 1;
            sedang = 0;
            banyak = 0;
            //sedikit = 1
        }
        else if (hp>30 && hp<60)
        {
            if(hp>30 && hp < 45)
            {
                sedikit = (45 - hp) / (45 - 30); // (45 - x) / (45 - 30)
                sedang = (hp - 30) / (45 - 30); // (x - 30) / (45 - 30)
                banyak = 0;
            }
            else if (hp>45 && hp < 60)
            {
                sedikit = 0;
                sedang = (60 - hp) / (60 - 45); // (60 - x) / (60 - 45)
                banyak = (hp - 45) / (60 - 45); // (x - 45) / (60 - 45)
            }
        }
        else
        {
            sedikit = 0;
            sedang = 0;
            banyak = 1;
            //banyak
        }
        // untuk jarak
        if (Vector2.Distance(enemy.transform.position, player.transform.position) >= 4.56f)
        {
            //jauh
            jauh = 1;
            dekat = 0;
        }
        else
        {
            //dekat
            jauh = 0;
            dekat = 1;
        }


        a[0] = Mathf.Min(banyak, jauh);
        a[1] = Mathf.Min(banyak, dekat);
        a[2] = Mathf.Min(sedang, jauh);
        a[3] = Mathf.Min(sedang, dekat);
        a[4] = Mathf.Min(sedikit, jauh);
        a[5] = Mathf.Min(sedikit, dekat);

        int i = 0;
        for(i = 0; i < a.Length; i++)
        {
            
            if (i == 0 || i == 1 || i == 3)
            {
                if (a[i] >= 1)
                {
                    z[i] = 100;

                }
                else if (a[i] <= 0)
                {
                    z[i] = 50;
                }
                else
                {
                    z[i] = 50 + ((100 - 50) * a[i]);
                }

            }
            else if(i == 2 || i == 4 || i == 5)
            {
                if (a[i] >= 1)
                {
                    z[i] = 50;

                }
                else if (a[i] <= 0)
                {
                    z[i] = 100;
                }
                else
                {
                    z[i] = 100 - ((100 - 50) * a[i]);
                }
            }
            
        }
        hasil = (a[0] * z[0]) + (a[1] * z[1]) + (a[2] * z[2]) + (a[3] * z[3]) + (a[4] * z[4]) + (a[5] * z[5])
                     / (a[0] + a[1] + a[2] + a[3] + a[4] + a[5]);

        if (prilaku)
        {
            if (hasil > 90)
            {
                puji.Agresif(dekat);
            }
            else if (hasil >= 60 && hasil <= 90)
            {
                puji.Chasing(dekat);
            }
            else if (hasil <= 50 && hp > 0)
            {
                puji.Defensif(dekat);
            }
            
        }
        if (hasil <= 50 && hp <= 0)
        {
            head.enabled = false;

        }

        
    }        

    public void TurnOfEnemy()
    {
        if (prilaku)
        {
            prilaku = false;
        }
        else
        {
            prilaku = true;
        }
        
    }

}
