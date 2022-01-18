using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolinha : MonoBehaviour
{
    public  int dano;
    public  int velocidade;
    public  int tempoMaxVivo;
    private float tempoVivo;

    // Start is called before the first frame update
    void Start()
    {
        tempoVivo = 0;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(velocidade * Player.Instance.GetLado(), 0));
    }

    // Update is called once per frame
    void Update()
    {
        if(tempoVivo > tempoMaxVivo)
        {
            Destroy(gameObject);
        }
        else
        {
            tempoVivo += Time.deltaTime;
            //transform.position = new Vector3(transform.position.x + (Time.deltaTime * velocidade), transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var inimigo = collision.gameObject.GetComponent<Inimigo>();
        if (inimigo != null)
        {
            inimigo.darDano(dano);
            Destroy(gameObject);
        }
    }
}
