using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallScript : MonoBehaviour
{



    public List<AudioSource> sources;

    public bool StickToThePlayer = true;


    private void Start()
    {
        sources = GetComponents<AudioSource>().ToList();
        Debug.Log($"Source Count: {sources.Count}");

    }

    public void PlayDeath()
    {
        sources[2].Play();
    }


    public void PlayRegular()
    {
        sources[1].Play();
    }


    public void PlayDestroy()
    {
        sources[0].Play();
    }

    public void ResetPosition()
    {
        this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        StickToThePlayer = true;
    }



}
