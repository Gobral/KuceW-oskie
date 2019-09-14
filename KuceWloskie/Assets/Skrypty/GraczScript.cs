using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GraczScript : MonoBehaviour
{
    private int punkty;
    [SerializeField]
    private float czas;
    private float czasTemp;
    public TextMeshProUGUI punktyTMP;
    public TextMeshProUGUI czasTMP;
    
    // Start is called before the first frame update
    void Start()
    {
        punkty = 0;
        czasTemp = czas;
        AkyualizujPunkty();
        AktualizujCzas();
    }

    // Update is called once per frame
    void Update()
    {
        if(czas > 0){
            AktualizujCzas();
            czas -= Time.deltaTime;
        }
        else {

        }
        if(czasTemp - czas > 0.5f){
            punkty += Random.Range(1, 100);
            // Debug.Log(punkty);
            AkyualizujPunkty();
            czasTemp -= 0.5f;
        }
        
    }
    void AkyualizujPunkty(){
        punktyTMP.text = "Rezultat: " + punkty;
    }
    void AktualizujCzas(){
        if(czas > 0.05f)
            czasTMP.text = "Czas: " + czas.ToString ("0.0");
        else{
            czasTMP.text = "Czas: 0";
        }
    }
}
