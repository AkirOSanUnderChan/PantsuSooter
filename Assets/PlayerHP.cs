using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using UnityEngine.UIElements;
//using Cursor = UnityEngine.UIElements;

public class PlayerHP : MonoBehaviour
{


    
    public bool CanEditTimeBool = true;
    public int MaxHP = 200;
    public int CurrentHP;

    public TextMeshProUGUI TimerText;

    public bool TActive = false;

    public float T_time;
    public float T_time_M;
    public float T_time_H;


    public GameObject GameManager_1;

    public TextMeshProUGUI HPCount;

    


    void Start()
    {
        CurrentHP = MaxHP;
        T_time = 0;

    }

    void Update()
    {
        if (CanEditTimeBool)
        {
            if (Input.anyKey)
            {
                TActive = true;
                CanEditTimeBool = false;
            }
        }

        

        HPCount.text = "HP" + CurrentHP;

        if (TActive)
        {
            T_time += Time.deltaTime;

        }

        if (T_time >= 60)
        {
            T_time = 0;
            T_time_M ++;
        }
        if (T_time_M >= 60)
        {
            T_time_H++;
            T_time_M = 0;
        }
        TimerText.text = T_time_H.ToString() + ":" + T_time_M.ToString() + ":" + T_time.ToString();

        if (CurrentHP <= 0)
        {
            gameManager_1 GM_1 = GameManager_1.GetComponent<gameManager_1>();
            GM_1.DeathBordUI.SetActive(true);
            GM_1.PauseGame();

        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("enemy"))
        {
            CurrentHP -= 1;
        }
    }
}
