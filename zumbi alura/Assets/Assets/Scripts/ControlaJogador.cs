using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ControlaJogador : MonoBehaviour
{

    public float Velocidade = 10;
    Vector3 direcao;
    public LayerMask MascaraChao;
    public GameObject TextoGameOver1;
    public GameObject TextoGameOver2;
    private Rigidbody rigidbodyJogador;
    private Animator animatorJogador;
    public int Vida = 100;

    private void Start()
    {
        Time.timeScale = 1;
        rigidbodyJogador = GetComponent<Rigidbody>();
        animatorJogador = GetComponent<Animator>();
    }
    
    void Update()
    {
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        direcao = new Vector3(eixoX, 0, eixoZ);

       

        if(direcao != Vector3.zero)
        {
            animatorJogador.SetBool("movendo", true);
        }
        else
        {
            animatorJogador.SetBool("movendo", false);
        }
         if(Vida <= 0)
         {
            if(Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("Main");
            }
         }
    }

    void FixedUpdate() 
    {
         rigidbodyJogador.MovePosition(rigidbodyJogador.position + (direcao * Velocidade * Time.deltaTime));

         Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
         Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);

         RaycastHit impacto;

         if(Physics.Raycast(raio, out impacto, 100, MascaraChao))
         {
            Vector3 posicaoMiraJogador = impacto.point - transform.position;

            posicaoMiraJogador.y = transform.position.y;

            Quaternion novaRotacao = Quaternion.LookRotation(posicaoMiraJogador);

            rigidbodyJogador.MoveRotation(novaRotacao);
         }
    }

    public void TomarDano (int dano)
    {
        Vida -= dano;
        if(Vida <= 0)
        {
            Time.timeScale = 0;
            TextoGameOver1.SetActive(true);
            TextoGameOver2.SetActive(true);
        }

    }
}
