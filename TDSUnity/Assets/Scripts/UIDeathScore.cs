using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIDeathScore : MonoBehaviour
{
    public ScoreIncrease si;
    public TMP_Text scoretext;
    string stext;


    void DeathScore()
    {
        if(si.pacifist == true)
        {
            stext = "Score (Pacifist): " + si.score.ToString();
            scoretext.text = stext;
            si.pacifist = false;
        } 
        else
        {
            stext = "Score: " + si.score.ToString();
            scoretext.text = stext;
        }

    }


}
