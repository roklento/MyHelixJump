using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixManager : MonoBehaviour
{
    [SerializeField] private GameObject[] rings;
    [SerializeField] private int numberOfRings;
    [SerializeField] private float ringDistance;

    private float yPos;

    private void Start()
    {
        for( int i = 0; i < numberOfRings; ++i)
        {
            if (i == 0)
            {
                SpawnRings(0);
            }
            else
            {
                SpawnRings(Random.Range(1, rings.Length - 1));
            }
        }
        SpawnRings(rings.Length - 1);
    }

    void SpawnRings(int index)
    {
        GameObject newRing = Instantiate(rings[index], new Vector3(transform.position.x, yPos, transform.position.z), Quaternion.identity, transform);
        yPos -= ringDistance;
        //newRing.transform.parent = transform;
    }


}
