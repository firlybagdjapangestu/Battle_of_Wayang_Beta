using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkin : MonoBehaviour
{
    public SpriteRenderer head;
    public SpriteRenderer body;
    public SpriteRenderer waist;
    public Hero hero;
    void Start()
    {
        hero = FindObjectOfType<Hero>();
    }

    // Update is called once per frame
    void Update()
    {
        head.sprite = hero.head;
        body.sprite = hero.body;
        waist.sprite = hero.waist;
    }
}
