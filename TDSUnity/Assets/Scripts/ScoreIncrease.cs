using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreIncrease : MonoBehaviour
{

    public float score = 0;
    public EnemyManagement EM;
    public bool pacifist;
    private void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Score()
    {
        score += 100;
        
    }

    void PacifistScoreCheck()
    {
        if(score == 0)
        {
            pacifist = true;
            score = (EM.count-3) * 300;
        }
    }
}
