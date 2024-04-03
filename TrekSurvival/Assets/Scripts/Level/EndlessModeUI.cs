using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EndlessModeUI : MonoBehaviour
{
    [Header("Endless Mode UI Vars")]
    [SerializeField] TextMeshProUGUI roundText;
    [SerializeField] TextMeshProUGUI currentObjective;
    [SerializeField] TextMeshProUGUI timer;
    [SerializeField] GameObject endlessModeManager;
    [SerializeField] int sceneIndex;
    [SerializeField] float fadeInTime;

    [Header("Game Over UI Vars")]
    [SerializeField] TextMeshProUGUI finalTime;
    [SerializeField] TextMeshProUGUI finalRounds;
    [SerializeField] TextMeshProUGUI gameOver;
    [SerializeField] Button playAgain;
    [SerializeField] Button quit;
    [SerializeField] Transform playAgainPos;
    [SerializeField] Transform quitPos;
    [SerializeField] Camera deathCam;
    [SerializeField] GameObject player;

    float elapsedTime;
    bool fadeIn;
    bool deathFade;
    bool gamePaused;
    int min;
    int second;

    private void Start()
    {
        gamePaused = false;
        fadeIn = true;
    }
    // Update is called once per frame
    void Update()
    {
        if(fadeIn == true)
        {
            FadeIn();
        }

        if (player.GetComponent<Player>().GetPlayerHeal() <= 0)
        {

            deathFade = true;

        }

        if(deathFade == true)
        {
            IfPlayerDead();
        }
        
        UpdateRoundText();
        UpdateObjectiveText();
        UpdateTimer();

        CheckForPause();
    }

    void UpdateRoundText()
    {
        roundText.text = "Rounds: " + endlessModeManager.GetComponent<EndlessModeManager>().GetRounds();
    }

    void CheckForPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(gamePaused == false)
            {
                Time.timeScale = 0;

                gamePaused = true;
            }
            else if(gamePaused == true)
            {
                Time.timeScale = 1;
                gamePaused = false;
            }
        }
    }

    void UpdateTimer()
    {
        elapsedTime += Time.deltaTime;
        min = Mathf.FloorToInt(elapsedTime / 60);
        second = Mathf.FloorToInt(elapsedTime % 60);
        timer.text = "Time: " + string.Format("{0:00}:{1:00}", min, second);
    }

    void UpdateObjectiveText()
    {
        currentObjective.text = "Objective: " + endlessModeManager.GetComponent<EndlessModeManager>().GetObjectiveName();
    }

    void IfPlayerDead()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        deathCam.gameObject.SetActive(true);
        LeanTween.value(roundText.gameObject, roundText.color.a, 0f, fadeInTime).setOnUpdate(ChangeRoundTextAlpha);
        LeanTween.value(currentObjective.gameObject, currentObjective.color.a, 0f, fadeInTime).setOnUpdate(ChangeObjectiveTextAlpha);
        LeanTween.value(timer.gameObject, timer.color.a, 0f, fadeInTime).setOnUpdate(ChangeTimeTextAlpha);



        //bring in new UI
        LeanTween.value(finalTime.gameObject, finalTime.color.a, 1f, fadeInTime).setOnUpdate(ChangeFinalTimeTextAlpha);
        LeanTween.value(finalRounds.gameObject, finalRounds.color.a, 1f, fadeInTime).setOnUpdate(ChangeFinalRoundsTextAlpha);
        LeanTween.value(gameOver.gameObject, gameOver.color.a, 1f, fadeInTime).setOnUpdate(ChangeGameOverTextAlpha);
        LeanTween.move(playAgain.gameObject, playAgainPos.position, 2f);
        LeanTween.move(quit.gameObject, quitPos.position, 2f);

        gameOver.text = "Game Over!!";

        finalRounds.text = "Final Round: " + endlessModeManager.GetComponent<EndlessModeManager>().GetRounds();

        finalTime.text = "Final Time: " + string.Format("{0:00}:{1:00}", min, second);


    }

    void FadeIn()
    {
        LeanTween.init(1000);

        if(fadeIn == true)
        {
            LeanTween.value(roundText.gameObject, roundText.color.a, 1f, fadeInTime).setOnUpdate(ChangeRoundTextAlpha);
            LeanTween.value(currentObjective.gameObject, currentObjective.color.a, 1f, fadeInTime).setOnUpdate(ChangeObjectiveTextAlpha);
            LeanTween.value(timer.gameObject, timer.color.a, 1f, fadeInTime).setOnUpdate(ChangeTimeTextAlpha);

            fadeIn = false;
        }
    }

    void ChangeRoundTextAlpha(float a)
    {
        var alphaChange = new Vector4(roundText.color.r, roundText.color.g, roundText.color.b, a);

        roundText.color = alphaChange;

    }

    void ChangeObjectiveTextAlpha(float a)
    {
        var alphaChange = new Vector4(currentObjective.color.r, currentObjective.color.g, currentObjective.color.b, a);

        currentObjective.color = alphaChange;

    }

    void ChangeTimeTextAlpha(float a)
    {
        var alphaChange = new Vector4(timer.color.r, timer.color.g, timer.color.b, a);

        timer.color = alphaChange;
    }

    void ChangeFinalTimeTextAlpha(float a)
    {
        var alphaChange = new Vector4(finalTime.color.r, finalTime.color.g, finalTime.color.b, a);

        finalTime.color = alphaChange;
    }

    void ChangeFinalRoundsTextAlpha(float a)
    {
        var alphaChange = new Vector4(finalRounds.color.r, finalRounds.color.g, finalRounds.color.b, a);

        finalRounds.color = alphaChange;
    }

    void ChangeGameOverTextAlpha(float a)
    {
        var alphaChange = new Vector4(gameOver.color.r, gameOver.color.g, gameOver.color.b, a);

        gameOver.color = alphaChange;
    }



    public void GoToMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(sceneIndex);
    }

}
