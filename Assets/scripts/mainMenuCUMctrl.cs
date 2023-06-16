using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuCUMctrl : MonoBehaviour
{
    public AudioClip ButtonPositive;
    AudioSource audSors;


    public Camera cam;

    public GameObject MainMenuUI;
    public GameObject LvlsMenuUI;
    public GameObject ChangesUI;




    // Start is called before the first frame update
    void Start()
    {
        audSors = GetComponent<AudioSource>();
        Time.timeScale = 1;
        cam.transform.position = new Vector3(39.8363419f, 2.96585274f, 53f);
        LvlsMenuUI.SetActive(false);
        MainMenuUI.SetActive(false);
        ChangesUI.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void idleCUM()
    {
        audSors.PlayOneShot(ButtonPositive);
        LvlsMenuUI.SetActive(false);
        MainMenuUI.SetActive(true);
        cam.transform.position = new Vector3(39.8363419f, 2.96585274f, 53f);
        

    }
    public void lvlsCUM()
    {
        audSors.PlayOneShot(ButtonPositive);
        LvlsMenuUI.SetActive(true);
        MainMenuUI.SetActive(false);
        cam.transform.position = new Vector3(39.8199997f, 2.97000003f, 45.1599998f);

    }

    public void goToLVL_1()
    {
        audSors.PlayOneShot(ButtonPositive);

        SceneManager.LoadScene(1);
    }


    public void ExitGame()
    {
        audSors.PlayOneShot(ButtonPositive);

        Application.Quit();
    }
    public void changesShowFalse()
    {
        audSors.PlayOneShot(ButtonPositive);

        MainMenuUI.SetActive(true);

        ChangesUI.SetActive(false);
    }
}
