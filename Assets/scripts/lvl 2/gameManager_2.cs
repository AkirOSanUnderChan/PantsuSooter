using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class gameManager_2 : MonoBehaviour
{


    // ANOTHER CODE LINKS _START_

    public GameObject playerHP;

    // ANOTHER CODE LINKS _END_


    public int zombieKilled;
    public int zombieAtLVL;
    public int zombieLeftToKill;

    public bool gameIsPaused = false;

    //         GUI

    public GameObject VictoryBordUI;
    public GameObject DeathBordUI;
    public GameObject PauseBordUI;


    public TextMeshProUGUI zombiesLeft_UI;




    void Start()
    {
        PauseBordUI.SetActive(false);
        VictoryBordUI.SetActive(false);
        DeathBordUI.SetActive(false);

        zombieKilled = 0;
        zombieAtLVL = 93;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gameIsPaused)
            {
                PauseBordUI.SetActive(true);
                gameIsPaused = true;
                PauseGame();
            }
            else
            {
                PauseBordUI.SetActive(false);
                gameIsPaused = false;
                ResumeGame();
            }


        }


        zombieLeftToKill = zombieAtLVL - zombieKilled;
        zombiesLeft_UI.text = zombieLeftToKill.ToString() + " / " + zombieAtLVL.ToString();


        if (zombieLeftToKill <= 0)
        {
            PlayerHP P_HP = playerHP.GetComponent<PlayerHP>();

            P_HP.TActive = false;

            VictoryBordUI.SetActive(true);
            PauseGame();
            Cursor.lockState = CursorLockMode.None;

        }

    }
    

    public void PauseGame()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;

    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;

    }

    public void GoToMainMenu()
    {
        Debug.Log("GO TO MAIN MENU !");
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        



    }


}
