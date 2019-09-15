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
    public Light swiatlo;


    private float czerony, zielony, niebieski;
    private bool st_cz, st_zi, st_ni;
    private int zmieniany_kolor;
    private int krok_koloru = 25;
    
    // Start is called before the first frame update
    void Start()
    {
        punkty = 0;
        czasTemp = czas;
        AkyualizujPunkty();
        AktualizujCzas();
        czerony = 255;
        niebieski = 255;
        zielony = 0;
        zmieniany_kolor = 1;
        st_cz = false;
        st_ni = false;
        st_zi = true;
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
        
        NaliczPunkty();
        UstawKolory();
    }
    void AkyualizujPunkty(){
        punktyTMP.text = "Rezultat: " + punkty;
    }
    void AktualizujCzas(){
        if(czas > 0.001f)
            czasTMP.text = "Czas: " + czas.ToString ("0.0");
        else{
            czasTMP.text = "Czas: 0";
        }
    }
    void ObliczKolory(){
        if(zmieniany_kolor == 1){
            if(st_cz){
                czerony += krok_koloru;
                if(czerony > 255){
                    czerony = 255;
                    st_cz = false;
                    zmieniany_kolor = 2;
                }
            }
            else {
                czerony -= krok_koloru;
                if(czerony < 0){
                    czerony = 0;
                    st_cz = true;
                    zmieniany_kolor = 2;
                }
            }
        }
        else if(zmieniany_kolor == 2){
            if(st_zi){
                zielony += krok_koloru;
                if(zielony > 255){
                    zielony = 255;
                    st_zi = false;
                    zmieniany_kolor = 3;
                }
            }
            else {
                zielony -= krok_koloru;
                if(zielony < 0){
                    zielony = 0;
                    st_zi = true;
                    zmieniany_kolor = 3;
                }
            }
        }
        else if(zmieniany_kolor == 3){
            if(st_ni){
                niebieski += krok_koloru;
                if(niebieski > 255){
                    niebieski = 255;
                    st_ni = false;
                    zmieniany_kolor = 1;
                }
            }
            else {
                niebieski -= krok_koloru;
                if(niebieski < 0){
                    niebieski = 0;
                    st_ni = true;
                    zmieniany_kolor = 1;
                }
            }
        }
    }
    void UstawKolory(){
        ObliczKolory();
        Color kolor = new Color(czerony/255f, zielony/255f, niebieski/255f);  
        punktyTMP.color = kolor;
        czasTMP.color = kolor;
        swiatlo.color = new Color(Random.Range(0.7f, 1f), Random.Range(0.7f, 1f), Random.Range(0.7f, 1f));
    }
    void NaliczPunkty(){
        if(czasTemp - czas > 0.2f){
            punkty += Random.Range(1, 100);
            // Debug.Log(punkty);
            AkyualizujPunkty();
            czasTemp -= 0.5f;
        }
    }
    
}
