using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public  float       velocidadeJogador;
    public  float       forcaPulo;
    public  Transform   groundCheck;
    public  LayerMask   layer;
    private int         ladoPlayer;
    private int         vida;
    public  GameObject  prefabBolinha;
    public  float       tempoRecargaBolinha;
    private float       tempoUltimaBolinha;
    public  static Player Instance;
    private Animator    playerAnimator;
    private bool        atacando;

    private delegate void delegates();
    private delegates updateDelegate;


    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        playerAnimator = GetComponent<Animator>();
        ladoPlayer = 1;
        vida = 100;
        tempoUltimaBolinha = tempoRecargaBolinha;
        updateDelegate += verificaMovimentacao;
        updateDelegate += verificaAltura;
        updateDelegate += verificaVida;
        updateDelegate += verificaTiro;
        updateDelegate += verificaPulo;
    }

    // Update is called once per frame
    void Update()
    {
        updateDelegate();
        tempoUltimaBolinha += Time.deltaTime;
    }

    private void verificaPulo()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            pulo();
        }
    }

    private void verificaTiro()
    {
        if (Input.GetAxis("Fire3") > 0)
        {
            mandaAtirar();
        }
    }

    private void verificaMovimentacao()
    {
        if (!atacando)
        {
            var lado = Input.GetAxisRaw("Horizontal");
            transform.position = new Vector3(transform.position.x + (velocidadeJogador * lado * Time.deltaTime), transform.position.y, transform.position.z);
            if (lado > 0 && transform.localScale.x == -1)
            {
                transform.localScale = new Vector3(1, 1, 1);
                ladoPlayer = 1;
            }
            else if (lado < 0 && transform.localScale.x == 1)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                ladoPlayer = -1;
            }

            if (lado == 0)
            {
                playerAnimator.SetBool("andando", false);
            }
            else
            {
                playerAnimator.SetBool("andando", true);
            }
        }
    }

    private void pulo()
    {
        var grounded = Physics2D.OverlapCircle(groundCheck.transform.position, 0.05f, layer);
        if (grounded)
        {
            transform.GetComponent<Rigidbody2D>().velocity = (new Vector2(0, forcaPulo));
        }
    }

    private void verificaAltura()
    {
        if(transform.position.y < -60)
        {
            matarPersonagem();
        }
    }

    private void verificaVida()
    {
        if(vida <= 0)
        {
            matarPersonagem();
        }

        GameObject.Find("preencher").GetComponent<Image>().fillAmount = (vida / 100f);
    }

    private void matarPersonagem()
    {
        SceneManager.LoadScene("Game_over");
    }

    public void darDano(int dano)
    {
        vida -= dano;
    }

    private void mandaAtirar()
    {
        if(tempoUltimaBolinha >= tempoRecargaBolinha)
        {
            tempoUltimaBolinha = 0;
            playerAnimator.SetTrigger("atacar");
            atacando = true;
            playerAnimator.SetBool("andando", false);
        }
    }

    public void Atirar()
    {
        Instantiate(prefabBolinha, transform.position, Quaternion.identity);
        atacando = false;
    }

    public int GetLado()
    {
        return this.ladoPlayer;
    }
}
