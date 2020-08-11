using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum EndGameCondition
{
    won = 0,
    lost = 1
}

public class HealthSystem : MonoBehaviour
{
    public List<GameObject> list = new List<GameObject>();

    private int HealthLeft;
    public void Start()
    {
        HealthLeft = list.Count - 1;
    }

    public void Update()
    {
        GameObject[] bricks = GameObject.FindGameObjectsWithTag("brick");

        Debug.Log(bricks.Length);

        if(bricks.Length <= 0 )
        {
            EndGame(EndGameCondition.won);
        }
        
    }

    public void TakeDamage()
    {
        Destroy(list[HealthLeft]);
        list.RemoveAt(HealthLeft);
        HealthLeft--;
        if (HealthLeft < 0 || list.Count == 0)
        {
            this.EndGame((EndGameCondition)1);
        }

    }


    public void EndGame(EndGameCondition cond)
    {

        switch(cond)
        {
            case (EndGameCondition)0:
                SceneManager.LoadScene("GameOverWin");
                break;
            case (EndGameCondition)1:
                SceneManager.LoadScene("GameLost");
                break;
        }
    }



}
