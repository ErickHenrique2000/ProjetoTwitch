using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{
    private GameObject  painel;

    // Start is called before the first frame update
    void Start()
    {
        painel = GameObject.Find("MensagemFinal");
        fecharPainel();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && Vector3.Distance(Player.Instance.transform.position, transform.position) < 1.2f)
        {
            GetComponent<Animator>().SetTrigger("abrir");
        }
    }

    public void setAberto()
    {
        GetComponent<Animator>().SetBool("aberto", true);
        painel.SetActive(true);
    }

    public void fecharPainel()
    {
        painel.SetActive(false);
    }
}
