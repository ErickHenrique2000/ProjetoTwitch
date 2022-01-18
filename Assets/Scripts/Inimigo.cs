using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    private int vida;
    public  int dano;
    public  int velocidade;
    public  float tempoMudanca; 
    private float tempo;
    private int lado;
    public  Transform chaoAFrente;
    public  LayerMask chao;

    // Start is called before the first frame update
    void Start()
    {
        vida = 100;
        tempo = 0;
        lado = 1;
    }

    // Update is called once per frame
    void Update()
    {
        var temChao = Physics2D.OverlapCircle(chaoAFrente.position, 0.1f, chao);
        
        if (tempo > tempoMudanca)
        {
            tempo = 0;
            transform.Rotate(new Vector3(0, 180, 0));
           lado *= -1;
        }

        if (temChao)
        {
            transform.position = new Vector3(transform.position.x + (lado * velocidade * Time.deltaTime), transform.position.y, transform.position.z);
        }
        tempo += Time.deltaTime;

        if(vida <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null){
            player.darDano(dano);
        }
        
    }

    public void darDano(int dano)
    {
        vida -= dano;
    }
}
