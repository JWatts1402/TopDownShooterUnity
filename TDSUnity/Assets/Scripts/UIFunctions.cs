using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIFunctions : MonoBehaviour
{
    // Start is called before the first frame update
   public void endApp()
    {
        Application.Quit();
    }
    public void startAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
