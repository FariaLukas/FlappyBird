using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class flappy : MonoBehaviour
{
    private Rigidbody2D myRigidBody;
    public float pushForce;
    public static bool isDead;
    MoveBackground[] moveBackgrounds;

    AudioSource source;
    public AudioClip touch, death;

    public ParticleSystem particula;

    DeathScript deathScript;

    //controle para nao repetir a particula 
    private bool hit;

    private void Awake()
    {
        //tive que pausar no awake pq no start a particula estava começando na tela
        particula.Pause();
        
    }
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        moveBackgrounds = FindObjectsOfType<MoveBackground>();

        deathScript = FindObjectOfType<DeathScript>();

        //tive que colocar eles false no start pq nao estava ficando false quando da restart no game
        hit = false;
        isDead = false;

        source = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (isDead)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                myRigidBody.velocity = Vector2.zero;
                myRigidBody.AddForce(Vector2.up * pushForce, ForceMode2D.Impulse);

                //coloquei um random no pitch para nao ficar repetitivo
                source.pitch = Random.Range(0.7f, 1.2f);
                source.PlayOneShot(touch, 0.7f);
            }

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            Death();
            if (!hit)
            {
                source.pitch = Random.Range(0.7f, 1.2f);
                source.PlayOneShot(death, 0.7f);

                //me referi a esse metodo aqui pois precisava que ele tocasse somente 1 vez (o IEnumeretor)
                deathScript.Pisca();

                Instantiate(particula, transform.position, Quaternion.identity);

                hit = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Cano")
        {
            //se ele passar no cano vivo ganha ponto
            if (!isDead)
            {
                Pontuacao.Pontos++;
            }

        }
        if(collision.tag == "Coin")
        {
            Pontuacao.Pontos++;
            Destroy(collision.gameObject);

        }
    }

    void Death()
    {
        isDead = true;
        for (int i = 0; i < moveBackgrounds.Length; i++)
        {
            moveBackgrounds[i].speed = 0;
        }
        // Faz o flappy ir para tras quando encosta na tag "death" de forma bem exagerada
        //tambem rotaciona ele ( o intuito é ele sair voando quando encosta em qualquer coisa)
        
        myRigidBody.AddForce(new Vector2(-5, 10), ForceMode2D.Impulse);
        myRigidBody.AddTorque(30);
    }
}
