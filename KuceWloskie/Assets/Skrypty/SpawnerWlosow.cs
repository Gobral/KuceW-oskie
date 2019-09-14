using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerWlosow : MonoBehaviour
{
    public GameObject wlos;
    // Start is called before the first frame update
    void Start()
    {

        const float coIle = 0.3f;
        float x0 = -1f;
        float x1 = 1f;
        float y0 = -1f;
        float y1 = 1f;
        float x = x0;
        float y = y0;
        while (y < y1)
        {
            Debug.Log("hehehe");
            x = x0;
            while(x < x1)
            {
                Debug.Log("hahahaha");
                GameObject haha = Instantiate(wlos, transform);
                haha.transform.Translate(new Vector3(x, 0, y));
                x += coIle;
            }
            y += coIle;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
