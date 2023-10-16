using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arms : MonoBehaviour
{
    private Rigidbody2D rb;
    public VariableJoystick joystick;
    public float x, y;
    public float speedArms;
    Vector2 moveDir;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        x = joystick.Horizontal;
        y = joystick.Vertical;
        moveDir = new Vector2(x, y);

        

    }
    private void FixedUpdate()
    {
        /*rb.AddForce(new Vector2(x,y)*speedArms);*/
        rb.velocity = moveDir * speedArms;
        
    }
}
