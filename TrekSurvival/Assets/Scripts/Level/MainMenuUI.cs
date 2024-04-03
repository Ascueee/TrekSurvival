using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [Header("Main Menu UI Elements")]
    [SerializeField] Button selectMaps;
    [SerializeField] Button quit;
    [SerializeField] Button undeadForest;
    [SerializeField] Button islandOfDead;
    [SerializeField] Button back;
    [SerializeField] RawImage selectMapImage;
    [SerializeField] float lerpTime;

    [Header("UI Positions")]
    [SerializeField] Transform mapsButtonPosOne, mapsButtonPosTwo;
    [SerializeField] Transform quitButtonPosOne, quitButtonPosTwo;
    [SerializeField] Transform backButtonPosOne, backButtonPosTwo;
    [SerializeField] Transform undeadForestButtonPosOne, undeadForestButtonPosTwo;
    [SerializeField] Transform islandOfDeadButtonPosOne, islandOfDeadButtonPosTwo;
    [SerializeField] Transform mapSelectMenuPosOne, mapSelectMenuPosTwo;

    bool stateOne;
    bool mapSelectState;

    private void Start()
    {
        stateOne = true;
    }

    // Update is called once per frame
    void Update()
    {
        MenuStates();
    }

    void MenuStates()
    {
        LeanTween.init(200);

        if (stateOne)
        {
            print("is this running");
            //moves the main menu buttons to pos
            LeanTween.move(selectMaps.gameObject, mapsButtonPosOne.position, lerpTime).setEaseInOutSine();
            LeanTween.move(quit.gameObject, quitButtonPosOne.position, lerpTime).setEaseInOutSine();

            //resets the map select buttons
            LeanTween.move(selectMapImage.gameObject, mapSelectMenuPosTwo.position, lerpTime);
            LeanTween.move(undeadForest.gameObject, undeadForestButtonPosTwo.position, lerpTime).setEaseInOutSine();
            LeanTween.move(islandOfDead.gameObject, islandOfDeadButtonPosTwo.position, lerpTime).setEaseInOutSine();
            LeanTween.move(back.gameObject, backButtonPosTwo.position, lerpTime).setEaseInOutSine();
            stateOne = false;
        }

        if (mapSelectState == true)
        {
            LeanTween.move(selectMaps.gameObject, mapsButtonPosTwo.position, lerpTime).setEaseInOutSine();
            LeanTween.move(quit.gameObject, quitButtonPosTwo.position, lerpTime).setEaseInOutSine();

            LeanTween.move(selectMapImage.gameObject, mapSelectMenuPosOne.position, lerpTime);
            LeanTween.move(undeadForest.gameObject, undeadForestButtonPosOne.position, lerpTime).setEaseInOutSine();
            LeanTween.move(islandOfDead.gameObject, islandOfDeadButtonPosOne.position, lerpTime).setEaseInOutSine();
            LeanTween.move(back.gameObject, backButtonPosOne.position, lerpTime).setEaseInOutSine();
            mapSelectState = false;
        }
    }

    public void MapSelectMenuState()
    {
        mapSelectState = true;
    }

    public void BackButton()
    {
        stateOne = true;
    }

    public void GoToUndeadForest()
    {
        SceneManager.LoadScene(2);
    }

    public void GoToIslandOfDead()
    {
        SceneManager.LoadScene(3);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
