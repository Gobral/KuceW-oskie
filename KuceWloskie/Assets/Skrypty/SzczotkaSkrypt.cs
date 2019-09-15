using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SzczotkaSkrypt : MonoBehaviour
{
    public GameObject gracz;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other) {
        GraczScript grs = (GraczScript) gracz.GetComponent(typeof(GraczScript));
        if(other.gameObject.name.Remove(4) == "Bone"){
            grs.DodajPunkty(500000);
        }
    }
}
