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

    public Transform kucyk;

    bool dziwnosc = false;
    float ileDziwnosci = 0.0f;

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

    void DziwneRzeczy()
    {
        dziwnosc = true;
        ileDziwnosci += Time.deltaTime;

        if (kucyk)
        {
            float rand = Szybsze(1.0f / 120.0f * ileDziwnosci) * 5.0f;
            float speed = Szybsze(1.0f / 240.0f * ileDziwnosci) * 12.0f;
            rand = Random.Range(-rand, rand);
            transform.RotateAround(kucyk.transform.position, new Vector3(rand, 1.0f, 0.0f).normalized, -180.0f / 24.0f * speed * Time.deltaTime);
        }
    }

    float Szybsze(float x)
    {
        return x / Mathf.Sqrt(x * x + 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        AktualizujCzas();
        czas -= Time.deltaTime;

        if(czas < -10.0f)
        {
            DziwneRzeczy();
        }
        
        NaliczPunkty();
        UstawKolory();
    }
    void AkyualizujPunkty(){
        punktyTMP.text = "Rezultat: " + punkty;
    }
    void AktualizujCzas(){
        czasTMP.text = "Czas: " + (Mathf.Max(czas, 0.0f)).ToString ("0.0");
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
        if(czasTemp - czas > 0.5f){
            punkty += Random.Range(1, 100);
            // Debug.Log(punkty);
            AkyualizujPunkty();
            czasTemp -= 0.5f;
        }
    }
    public void DodajPunkty(int pkt){
        punkty += pkt;
    }
    
}
