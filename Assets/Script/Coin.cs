using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject moeda;
    public float range;

    public void Spawn()
    {
        Instantiate(moeda, transform.position, Quaternion.identity);
    }
}
