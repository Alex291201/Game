using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class GFX : MonoBehaviour
{

    public AIPath aiPath;
    public Animator animator;

    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (aiPath.desiredVelocity.x != 0) animator.SetFloat("Speed", Mathf.Abs(aiPath.desiredVelocity.x));
     
    }
}
