using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    private Transform player;
    [SerializeField] private GameObject[] childRings;
    [SerializeField] private float radius;
    [SerializeField] private float force;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        if(transform.position.y > player.position.y)
        {
            GameManager.numberOfPassingRings++;
            GameManager.currentScore += 10;
            for(int i = 0; i < childRings.Length; ++i)
            {
                childRings[i].GetComponent<Rigidbody>().isKinematic = false;
                childRings[i].GetComponent<Rigidbody>().useGravity = true;
                childRings[i].GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, radius);
                childRings[i].GetComponent<MeshCollider>().enabled = false;
                childRings[i].transform.parent = null;
                Destroy(childRings[i].gameObject, 2f);
                Destroy(this.gameObject, 5f);
            }
            this.enabled = false;
        }
    }

}
