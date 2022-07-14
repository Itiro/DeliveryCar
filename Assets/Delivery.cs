using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] bool packagePicked = false;
    [SerializeField] float destroyDelay = 1.0f;
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(0, 0, 0, 1);

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Oooops, sorry");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Package")
        {
            if (packagePicked == false)
            {
                Debug.Log("Package picked up");
                packagePicked = true;
                spriteRenderer.color = hasPackageColor;
                Destroy(collision.gameObject, destroyDelay);                
            }
            else
            {
                Debug.Log("You already has a package to deliver");
            }
        }
        if (collision.tag == "Customer")
        {
            if (packagePicked == true)
            {
                Debug.Log("Thank you for the package");
                packagePicked = false;
                spriteRenderer.color = noPackageColor;
            }
            else
            {
                Debug.Log("Where is my package?");
            }
        }

        
    }
}
