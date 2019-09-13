using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WlosScript : MonoBehaviour
{
    const int MAX_ILOSC_KAWALKOW = 20000;

    public int iloscKawalkow = 20;
    public int iloscIteracji = 8;
    public bool blokada = false;
    public float odlegloscKawalkow = 1.0f + 0.03f;
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

        if (blokada && ktory == 0)
        {
            kawalek.isKinematic = true;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //return;
        Rigidbody jeden = null;
        Rigidbody dwa = null;
        Vector3 q;
        Vector3 w;
        foreach(Transform kawalek in transform)
        {
            kawalek.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
        for (int i = 0; i < iloscIteracji; ++i)
        {
            jeden = null;
            dwa = null;
            foreach (Transform kawalek in transform)
            {
                jeden = dwa;
                dwa = kawalek.GetComponent<Rigidbody>();
                if (jeden == null)
                {
                    continue;
                }
                q = jeden.transform.localPosition;
                w = dwa.transform.localPosition;
                float odleglosc = (w - q).magnitude;
                Vector3 wersor = (w - q).normalized;
                if (odleglosc > odlegloscKawalkow)
                {
                    Vector3 zmiana = (odleglosc - odlegloscKawalkow) * wersor / 2.0f;
                    Vector3 sredniaPredkosc = (jeden.velocity + dwa.velocity) * 0.5f;
                    if (!jeden.isKinematic)
                    {
                        jeden.transform.localPosition += zmiana;
                        //jeden.velocity += zmiana / Time.deltaTime;
                        //jeden.AddForce(zmiana * 0.05f);
                        jeden.velocity = sredniaPredkosc;
                    }
                    dwa.transform.localPosition -= zmiana;
                    //dwa.velocity -= zmiana / Time.deltaTime;
                    //dwa.AddForce(-zmiana * 0.05f);
                    dwa.velocity = sredniaPredkosc;
                }
            }
        }
    }
}
