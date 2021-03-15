using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScript : MonoBehaviour
{
    Color color;
    Image image;
    //musica de background, tentei fazer diversas mudanças para parar de ter "noise" nesse som mas nao consegui
    public AudioClip bg;
    AudioSource source;
    void Start()
    {
        color = GetComponent<Image>().color;
        image = GetComponent<Image>();
        color.a = 0;
        image.color = color;
        source = GetComponent<AudioSource>();
    }

    public void Pisca()
    {
        StartCoroutine("Tilt");
        source.Stop();
    }
    //modifico o alpha da imagem para fazer ela "piscar"
    IEnumerator Tilt()
    {
        color.a = 0.6f;
        image.color = color;
        yield return new WaitForSeconds(.1f);
        color.a = 0;
        image.color = color;
    }
}
