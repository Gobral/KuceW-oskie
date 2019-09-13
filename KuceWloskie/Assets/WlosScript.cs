using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WlosScript : MonoBehaviour
{
    const int MAX_ILOSC_KAWALKOW = 20000;

    public int iloscKawalkow = 20;
    public int iloscIteracji = 30;
    public float odlegloscKawalkow = 1.0f + 0.05f;
    public Rigidbody kawalekWlosaObject;

    private bool isNew = true;

    private void Awake()
    {
        isNew = false;
        if (iloscKawalkow <= 0 || iloscKawalkow >= MAX_ILOSC_KAWALKOW)
        {
            Destroy(this);
            return;
        }
        for (int i = 0; i < iloscKawalkow; ++i)
        {
            SpawnKawalka(i);
        }
    }

    void SpawnKawalka(int ktory)
    {
        Rigidbody kawalek = Instantiate(kawalekWlosaObject, transform);
        // kawalek.transform.localPosition = transform.localPosition;
        //kawalek.transform.localRotation = transform.localRotation;
        Vector3 przesuniecie = transform.localRotation * (Vector3.up * odlegloscKawalkow * (ktory + 0.5f));
        kawalek.transform.localPosition = przesuniecie;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //return;
        for (int i = 0; i < iloscIteracji; ++i)
        {
            Rigidbody jeden = null;
            Rigidbody dwa = null;
            foreach (Transform kawalek in transform)
            {
                jeden = dwa;
                dwa = kawalek.GetComponent<Rigidbody>();
                if (jeden == null)
                {
                    continue;
                }
                Vector3 q = jeden.transform.localPosition;
                Vector3 w = dwa.transform.localPosition;
                float odleglosc = (w - q).magnitude;
                Vector3 wersor = (w - q).normalized;
                if (odleglosc > odlegloscKawalkow)
                {
                    Vector3 zmiana = (odleglosc - odlegloscKawalkow) * wersor / 2.0f / 4.0f;
                    jeden.transform.localPosition += zmiana;
                    dwa.transform.localPosition -= zmiana;
                    //jeden.AddForce(zmiana);
                    //dwa.AddForce(-zmiana);
                }
            }
        }
    }
}
