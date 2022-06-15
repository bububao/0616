using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public Material[]material;
    public GameObject[] leaf;
    public GameObject[] petal;
    public GameObject[] stalk;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider col)
    {
        
        if (col.CompareTag("Player"))
        {
            Invoke("StalkChange", 0.5f);   
        }
    }
    void StalkChange()
    {
        for (int i = 0; i < stalk.Length; i++)
        {
            stalk[i].GetComponent<Renderer>().sharedMaterial = material[2];
        }
        Invoke("LeafChange", 0.5f);
    }
    void LeafChange()
    {
        for (int i = 0; i < leaf.Length; i++)
        {
            leaf[i].GetComponent<Renderer>().sharedMaterial = material[1];
        }
        Invoke("FlowerChange", 0.5f);
    }
    void FlowerChange()
    {
        for (int i = 0; i < petal.Length; i++)
        {
            petal[i].GetComponent<Renderer>().sharedMaterial = material[0];
        }

    }
}
