using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public Transform target;
    public Rigidbody2D body;
    public Rigidbody2D handLeft;
    public Rigidbody2D handRight;

    public void Defensif(float dekat)
    {
        if (dekat == 1)
        {
            SpiningLeftHand();
            SpiningRightHand();
        }
    }
    public void Agresif(float dekat)
    {
        if(dekat == 0)
        {
            SuperMan();
        }
        else if(dekat == 1)
        {
            SpiningLeftHand();
            SpiningRightHand();
        }        
    }
    public void Chasing(float dekat)
    {
        handLeft.AddForce(new Vector2(speed, 0) * 1);
        handRight.AddForce(new Vector2(speed, 0) * 1);
    }
    public void SuperMan()
    {        
        handLeft.AddForce(new Vector2(speed, 0) * 1);
        handRight.AddForce(new Vector2(0, 40) * 1);       
    }

    public void SpiningLeftHand()
    {
        handLeft.AddTorque(-2, ForceMode2D.Impulse);
    }
    public void SpiningRightHand()
    {
        handRight.AddTorque(-2, ForceMode2D.Impulse);
    }
    
}
