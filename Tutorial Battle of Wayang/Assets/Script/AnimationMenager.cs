using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMenager : MonoBehaviour
{
    public Animator camAnim;
    public Animator wayang;
    public Animator puji;
    public void camShake()
    {
        camAnim.SetTrigger("Shake");
    }

    public void WayangHurt()
    {
        wayang.SetTrigger("Hurt");
    }
    public void PujiHurt()
    {
        puji.SetTrigger("Hurt");
    }
}
