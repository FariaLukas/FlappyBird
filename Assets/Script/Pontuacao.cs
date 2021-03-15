using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pontuacao : MonoBehaviour
{
    public static int Pontos;
    Text text;
    void Start()
    {
        text = GetComponent<Text>();
        Pontos = 0;
    }

    void Update()
    {

        text.text = Pontos.ToString(); ;
    }


}
