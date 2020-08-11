using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BrickScript : MonoBehaviour
{

    private BallScript ballRef;



    public void OnCollisionEnter(Collision collision)
    {
        ballRef = collision.gameObject.GetComponent<BallScript>();
        if(ballRef != null)
        {
            ballRef.PlayDestroy();
        }
        Destroy(this.gameObject);
        
    }


}
