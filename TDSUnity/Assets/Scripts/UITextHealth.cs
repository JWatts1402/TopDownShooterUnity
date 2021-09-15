using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UITextHealth : MonoBehaviour
{
    public PlayerHealth ph;
    public TMP_Text healthtext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string htext = ph.health.ToString();
        healthtext.text = "Health: " + htext;
    }
}
