using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void IniciarFase()
    {
        SceneManager.LoadScene("Fase_1");
    }

    public void FecharJogo()
    {
        Application.Quit();
        Debug.Log("Cliquei em fechar");
    }

    public void IrParaMenu()
    {
        SceneManager.LoadScene(0);
    }
}
