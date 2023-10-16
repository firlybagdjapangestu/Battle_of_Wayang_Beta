using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Hero", menuName = "ScriptableObjects/Hero", order = 1)]
public class Hero : ScriptableObject
{
    public string name;
    public Sprite head;
    public Sprite body;
    public Sprite waist;
  
}
