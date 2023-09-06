using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreen : MonoBehaviour
{
    //Bu scriptin amac� oyun arkaplan resminin her cihazda ayn� ekran� kaplayacak �ekilde durmas�n� sa�lamak olacak.
    //1-Bunun i�in ilk olarak SpriteRenderer bile�enine ihtiyac�m�z olacak.
    //2-Daha sonra arkaplan resmimizin scale de�erlerini alaca��z.
    //3-Elimizdeki sprite nesnesinin geni�lik de�erini almam�z laz�m.(float bir de�er)
    //4-Kameram�z�n y�kselik de�erini almam�z laz�m.(float)
    //5-Oyunumuz �al��t�racak cihaz�m�z�n ekran geni�li�ine ihtiyac�m�z var.
    //6-Cihaz ve sprite geni�li�ini arkaplan resminin geni�li�ne e�itlememiz laz�m
    //7-Bu ��kan de�eri de arkaplan scale de�erine at�caz.(localScale)

    void Start()
    {
        //1.basamak
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        //2.basamak
        Vector2 backgroundScale = transform.localScale;//Objenin mevcut scale de�erlerini ald�k.

        //3.basamak
        float spriteGenislik = spriteRenderer.size.x;

        //4.basamak
        float ekranYukseklik = Camera.main.orthographicSize * 2.0f;
        //Bunu 2 ile �arpmam�z�n nedeni ��yle a��klayay�m. Kameram�z�n bulundu�u alandan yukar� ve a�a��ya do�ru g�rd��� alan�n b�y�kl���n� ifade eder.
        //Yani de�er 5 ise yukar� i�in 5 birim ve a�a��s� i�in 5 birimlik g�r�� sa�lar. Toplamda 10 olaca�� i�in bunu 2 ile �arpar�z.

        //5.basamak
        float cihazGenislik = ekranYukseklik / Screen.height * Screen.width;
        //Mevcut cihaz�n y�kseklik ve geni�lik de�erlerini al�p kameram�z�n y�kseklik de�erine b�l�yoruz.
        //Debug.Log("Cihaz ��z�n�rl���:"+Screen.height + "*" + Screen.width+" --Kameram�z�n y�ksekli�i: "+ekranYukseklik+" Ekran ��z: "+ekranCozunurluk);

        //6.basamak
        backgroundScale.x = cihazGenislik / spriteGenislik;
        //7.basamak
        transform.localScale = backgroundScale;
    }


    void Update()
    {
        
    }
}
