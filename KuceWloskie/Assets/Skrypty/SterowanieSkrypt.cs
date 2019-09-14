using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SterowanieSkrypt : MonoBehaviour
{
    Scene scena;
    // Start is called before the first frame update
    void Start()
    {
        scena =  SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(scena.name);
        }
    }
}
