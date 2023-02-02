using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float bounceForce;
    [SerializeField] private GameObject splitPrefab;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        string materialName = collision.transform.GetComponent<MeshRenderer>().sharedMaterial.name;
        Debug.Log(materialName);
        if(materialName == "Safe")
        {
            rb.velocity = new Vector3(rb.velocity.x, bounceForce, rb.velocity.z);
            GameObject newSplit = Instantiate(splitPrefab, new Vector3(transform.position.x, collision.transform.position.y + 0.2f, transform.position.z), transform.rotation);
            newSplit.transform.localScale = Vector3.one * Random.Range(0.8f, 1.2f);
            newSplit.transform.parent = collision.transform;
            Destroy(newSplit, 1f);
        }
        else if(materialName == "Unsafe")
        {
            Debug.Log("game over");

            this.gameObject.SetActive(false);
        }
        else if(materialName == "Final")
        {
            Debug.Log("You Win");
        }
        
    }
}
