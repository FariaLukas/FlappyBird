using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    public Transform[] pieces;
    public float speed;
    public float width;
    public Vector2 randomHeightChange;
    Coin coin;

    void Awake()
    {
        for (int i = 0; i < pieces.Length; i++)
        {
            // se tiver a tag de pipes ele começa parado, coloquei dentro do for para nao  precisar repetir
            if (gameObject.tag == "Pipes")
            {
                speed = 0;
                //estava usando translate como feito em aula, porem os valores de y nao ficavam dentro do range escolhido
                pieces[i].transform.position = new Vector2(pieces[i].transform.position.x, Random.Range(randomHeightChange.x, randomHeightChange.y));
               
            } else
            {
                pieces[i].transform.position = new Vector2(pieces[i].transform.position.x, pieces[i].transform.position.y);
            }
            
        }
        coin = FindObjectOfType<Coin>();
        
       
    }

    void Update()
    {
        Moving();
        //quando apertar o botao ele seta a speed para o valor dela
        if (Input.GetMouseButtonDown(0))
        {
            if (gameObject.tag == "Pipes")
                speed = 1.5f;
        }

    }

    void Moving()
    {
        for (int i = 0; i < pieces.Length; i++)
        {
            if (pieces[i].position.x <= width*-2)
            {
                if (gameObject.tag == "Pipes")
                {
                    pieces[i].transform.position = new Vector2(width*2, Random.Range(randomHeightChange.x, randomHeightChange.y));
                    
                }else
                {
                    pieces[i].transform.position = new Vector2(width *2, pieces[i].transform.position.y);
                }


                coin.range = Random.Range(1, 7);
                if (coin.range == 1)
                {
                    coin.Spawn();
                }

            }
           
            pieces[i].transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

}
