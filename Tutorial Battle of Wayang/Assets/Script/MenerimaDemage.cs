using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenerimaDemage : MonoBehaviour
{
    public float awal, akhir;
    private fuzzy enemy;
    private PlayerConroller player;
    public ParticleSystem hit;
    private AnimationMenager animasi;
    private Rigidbody2D rb;
    private EnemyStatus enemyStatus;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animasi = FindObjectOfType<AnimationMenager>();
        player = FindObjectOfType<PlayerConroller>();
        enemy = FindObjectOfType<fuzzy>();
        enemyStatus = FindObjectOfType<EnemyStatus>();
    }
    public void TakeDemage(float demage)
    {
        enemyStatus.hp -= demage;
        enemy.hp -= demage;
        enemyStatus.healthbar.setHP(enemyStatus.hp);
    }

    public void TakeDemageForPlayer(float demage)
    {
        player.hp -= demage;
        player.healthbar.setHP(player.hp);
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Arms")
        {
            animasi.PujiHurt();
            rb.AddForce(new Vector2(-4000,0) * 1);
            animasi.camShake();
            Instantiate(hit, transform.position, Quaternion.identity);
            TakeDemage(Random.Range(awal,akhir));
        }
        if (collision.gameObject.tag == "ArmsEnemy")
        {
            animasi.WayangHurt();
            rb.AddForce(new Vector2(-4000, 0) * 1);
            animasi.camShake();
            Instantiate(hit, transform.position, Quaternion.identity);
            TakeDemageForPlayer(Random.Range(awal, akhir));
        }
    }
}
