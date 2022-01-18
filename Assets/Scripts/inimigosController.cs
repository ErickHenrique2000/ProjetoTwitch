using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigosController : MonoBehaviour
{
    private Transform[]    inimigos;

    void Start()
    {
        inimigos = new Transform[transform.childCount];
        for(int i = 0; i < transform.childCount; i++)
        {
            inimigos[i] = transform.GetChild(i);
        }
    }

    void FixedUpdate()
    {
        for(int i = 0; i < inimigos.Length; i++)
        {
            if(Vector3.Distance(inimigos[i].position, Player.Instance.transform.position) >= 25){
                inimigos[i].gameObject.SetActive(false);
            }
            else
            {
                inimigos[i].gameObject.SetActive(true);
            }
        }
    }
}
