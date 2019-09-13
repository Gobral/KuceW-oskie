using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerWlosow : MonoBehaviour
{
    public GameObject wlos;
    // Start is called before the first frame update
    void Start()
    {

        const float coIle = 1f;
        float x0 = -2f;
        float x1 = 2f;
        float y0 = -2f;
        float y1 = 2f;
        float x = x0;
        float y = y0;
        while (y < y1)
        {
            x = x0;
            while(x < x1)
            {
                GameObject haha = Instantiate(wlos, transform);
                haha.transform.Translate(transform.localPosition + new Vector3(x, 0, y));
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
