using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOfDeath : MonoBehaviour
{

    public HealthSystem HP;

    public void OnCollisionEnter(Collision collision)
    {
        BallScript ball = collision.gameObject.GetComponent<BallScript>();

        if(ball != null)
        {
            ball.PlayDeath();
            ball.ResetPosition();
            HP.TakeDamage();
        }
    }



}
