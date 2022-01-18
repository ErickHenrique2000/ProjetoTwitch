using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    private GameObject  panel;
    private bool        pausado;

    void Start()
    {
        panel = GameObject.Find("Pause");
        panel.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (pausado)
            {
                Continuar();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Continuar()
    {
        pausado = false;
        panel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Pause()
    {
        pausado = true;
        panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void MainMenu()
    {
        Continuar();
        SceneManager.LoadScene("Menu_principal");
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Sai");
    }
}
