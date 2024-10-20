using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class klon_olustur : MonoBehaviour
{
    public GameObject yildiz;
    public GameObject bariyer1, bariyer2, bariyer3, bariyer4, bariyer5, bariyer6;
    public GameObject huni, saricubuk;
    public Transform oyuncu;
    float silinmeZamani = 10.0f;
    float sagX_koordinat = 3f;
    float merkezX_koordinat = 0.1f;
    float solX_koordinat = -3f;
    void Start()
    {
        InvokeRepeating("nesne_klonla", 1f, 3f);
    }

    void nesne_klonla()
    {
        int rastsayi = Random.Range(0, 100);
        if (rastsayi>20 && rastsayi < 80) //alt�n
        {
            klonla(yildiz, 1.0f);
        }
        if (rastsayi > 10 && rastsayi < 25) //duba
        {
            klonla(huni, 0f);
        }
        if (rastsayi > 40 && rastsayi < 45) //sar� �ubuk
        {
            klonla(saricubuk, 0f);
        }
        if (rastsayi > 0 && rastsayi < 15) //engel1
        {
            klonla(bariyer1, 0f);
        }
        if (rastsayi > 14 && rastsayi < 30) //engel2
        {
            klonla(bariyer2, 0f);
        }
        if (rastsayi > 29 && rastsayi < 55) //engel3
        {
            klonla(bariyer3, 0f);
        }
        if (rastsayi > 54 && rastsayi < 70) //engel4
        {
            klonla(bariyer4, 0f);
        }
        if (rastsayi > 69 && rastsayi < 85) //engel5
        {
            klonla(bariyer5, 0f);
        }
        if (rastsayi > 84 && rastsayi < 100) //engel6
        {
            klonla(bariyer6, 0f);
        }
    }
    void klonla(GameObject nesne, float y_koordinat)
    {
        GameObject yeniKlon = Instantiate(nesne);

        int rastsayi = Random.Range(0, 100);

        if(rastsayi>0 && rastsayi < 33) //sol
        {
            yeniKlon.transform.position = new Vector3(sagX_koordinat, y_koordinat, oyuncu.position.z + 30.0f);
        }
        if (rastsayi > 33 && rastsayi < 67) //orta
        {
            yeniKlon.transform.position = new Vector3(merkezX_koordinat, y_koordinat, oyuncu.position.z + 30.0f);
        }
        if (rastsayi > 67 && rastsayi < 100) //sa�
        {
            yeniKlon.transform.position = new Vector3(solX_koordinat, y_koordinat, oyuncu.position.z + 30.0f);
        }

        Destroy(yeniKlon, silinmeZamani);
    }
    void Update()
    {
        
    }
}
