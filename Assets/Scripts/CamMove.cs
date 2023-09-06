using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    //Bu script dosyas�nda kameran�n zaman i�erisinde yukar�ya do�ru hareket etmesi sa�layaca��z.
    //Ayn� zamanda arkaplan resimleri de s�rekli �st �ste eklenerek sonsuz bir arkaplan hissi verecek.
    //1-Kameran�n h�z�n� kontrol etmek i�in float t�r�nde de�i�ken
    //2-Kameran�n zaman i�erisinde ne kadar h�zlanaca��n� kontrol etmek i�in float bir h�zlanma de�eri
    //3-Ve son olarak maxH�z de�eri.H�zlanmas�n� sonsuza kadar art�rmak mant�ks�z olur
    //4-Belirli durumlarda kamera hareketini durdurup ba�latmak i�in bool t�r�nde de�i�ken.
    //5-Kameray� hareket ettirmek i�in y de�erini s�rekli art�rmak gerek
    //6-Kameran�n h�zlanmas�n� sa�lamak i�in h�z ile h�zlanma de�erini �arp�p h�z de�i�kenine tekrardan atal�m.
    //7-H�z�m�z maxH�z de�erini ge�mesin diye if ile kontrol edicez.
    float hiz, hizlanma, maxHiz;
    bool hareketDurumu=true;//default de�eri false
    void Start()
    {
        //1.basamak
        hiz = 1f;
        //2.basamak
        hizlanma = 0.05f;
        //3.basamak
        maxHiz = 2.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hareketDurumu)
        {
            CameraMove();
        }
        
        Debug.Log("Mecvut h�z�m:" + hiz);
    }
    void CameraMove()
    {
        //5.basamak
        transform.position += transform.up * hiz * Time.deltaTime;
        //6.basamak
        hiz += hizlanma * Time.deltaTime;
        //7.basamak
        if (hiz > maxHiz)
        {
            hiz = maxHiz;
        }
    }
}
