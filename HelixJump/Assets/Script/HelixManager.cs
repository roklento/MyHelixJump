using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixManager : MonoBehaviour
{
    public float numberOfRings;

    [SerializeField] private GameObject[] rings;
    [SerializeField] private float ringDistance;

    private float yPos;

    private void Start()
    {
        numberOfRings = (GameManager.currentLevelIndex * 2f ) + 5f;
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
