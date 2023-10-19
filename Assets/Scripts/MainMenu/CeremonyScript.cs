using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class CeremonyScript : MonoBehaviour
{
    public List<Sprite> customers;
    private SpriteRenderer customerSpriteRenderer;
    public GameObject customer;
    public GameObject oracle;

    void Start()
    {
        customerSpriteRenderer = customer.GetComponent<SpriteRenderer>();

        customerSpriteRenderer.sprite = customers[Random.Range(0, customers.Count)];

    }

    void Update()
    {
        
    }
}
