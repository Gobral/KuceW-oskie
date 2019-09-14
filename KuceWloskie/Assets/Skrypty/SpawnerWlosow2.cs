using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerWlosow2 : MonoBehaviour
{
    public GameObject wlos;
    public float coIle = 0.1f;
    public float x0 = -0.2f;
    public float x1 = 0.2f;
    public float z0 = -0.3f;
    public float z1 = 0.3f;

    Vector3 GetVec(float x, float z)
    {
        return new Vector3(x, 0 * (z - x * x), z);
    }

    Quaternion GetQuat(float x, float z)
    {
        return Quaternion.AngleAxis(30.0f * x, Vector3.right);
    }

    void Start()
    {
        float x = x0;
        float z = z0;
        while (z <= z1)
        {
            Debug.Log("hehehe");
            x = x0;
            while(x <= x1)
            {
                Debug.Log("hahahaha");
                GameObject haha = Instantiate(wlos, GetVec(x, z), GetQuat(x, z), transform);
                x += coIle;
            }
            z += coIle + 10000.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
