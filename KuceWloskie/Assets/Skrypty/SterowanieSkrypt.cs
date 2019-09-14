using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SterowanieSkrypt : MonoBehaviour
{
    public Rigidbody szczota;
    Scene scena;
    Camera silverChariot;
    static Quaternion kout = Quaternion.AngleAxis(20.0f, Vector3.right) * Quaternion.AngleAxis(90.0f, Vector3.forward);

    public float nacisk = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        scena = SceneManager.GetActiveScene();
        foreach(Transform crazyDiamond in transform)
        {
            if (crazyDiamond.GetComponent<Camera>() != null)
            {
                silverChariot = crazyDiamond.GetComponent<Camera>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(scena.name);
        }
        if(szczota == null)
        {
            return;
        }
        Vector3 mycha = Input.mousePosition;


        nacisk += Input.GetAxis("Vertical") * 2.0f * Time.deltaTime;

        nacisk = Mathf.Min(1.0f, Mathf.Max(0.0f, nacisk));


        szczota.transform.SetPositionAndRotation(MiejsceSzczoty(mycha), ObrotSczoty(mycha));
        szczota.velocity = Vector3.zero;
        szczota.angularVelocity = Vector3.zero;
    }

    Vector3 MiejsceSzczoty(Vector3 mycha)
    {
        return silverChariot.ScreenToWorldPoint(mycha + (silverChariot.nearClipPlane + 14.2f) * Vector3.forward) +
            3.0f * nacisk * Vector3.forward;
    }

    Quaternion ObrotSczoty(Vector3 mycha)
    {
        return Quaternion.AngleAxis(15.0f * nacisk, Vector3.right) * kout * silverChariot.transform.rotation;
    }
}
