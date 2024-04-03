using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroVideo : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Invoke("GoToMenu", 3);
    }


    void GoToMenu()
    {
        SceneManager.LoadScene(1);
    }
}
