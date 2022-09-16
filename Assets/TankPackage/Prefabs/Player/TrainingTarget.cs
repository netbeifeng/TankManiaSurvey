using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingTarget : MonoBehaviour
{
    int minReflections;
    Material mat;
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        minReflections = Random.Range(0, 3);
        switch (minReflections)
        {
            case 0: mat.color = Color.green; break;
            case 1: mat.color = Color.yellow; break;
            case 2: mat.color = Color.red; break;
        }
            
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            if(other.gameObject.GetComponent<TrajectoryMover>().GetNumReflections()== minReflections)
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
