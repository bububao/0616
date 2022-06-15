using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tulip : MonoBehaviour
{
    MeshRenderer meshRenderer;
    public bool isWalked;
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    void Start()
    {
        meshRenderer.material.color = new Color(1,1,1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isWalked)
        {
            float randomRed;
            randomRed = Random.Range(0, 1f);
            float randomGreen;
            randomGreen = Random.Range(0, 1f);
            float randomBlue;
            randomBlue = Random.Range(0, 1f);
            meshRenderer.material.color = new Color(randomRed, randomGreen, randomBlue);
            isWalked = true;
        }
    }
}
