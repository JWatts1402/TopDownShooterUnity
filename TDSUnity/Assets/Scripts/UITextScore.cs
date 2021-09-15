using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UITextScore : MonoBehaviour
{
    public ScoreIncrease si;
    public TMP_Text scoretext;
    string stext;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
            stext = si.score.ToString();
            scoretext.text = "Score: " + stext;     
    }

}
