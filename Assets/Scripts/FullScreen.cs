using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreen : MonoBehaviour
{
    //Bu scriptin amacý oyun arkaplan resminin her cihazda ayný ekraný kaplayacak þekilde durmasýný saðlamak olacak.
    //1-Bunun için ilk olarak SpriteRenderer bileþenine ihtiyacýmýz olacak.
    //2-Daha sonra arkaplan resmimizin scale deðerlerini alacaðýz.
    //3-Elimizdeki sprite nesnesinin geniþlik deðerini almamýz lazým.(float bir deðer)
    //4-Kameramýzýn yükselik deðerini almamýz lazým.(float)
    //5-Oyunumuz çalýþtýracak cihazýmýzýn ekran geniþliðine ihtiyacýmýz var.
    //6-Cihaz ve sprite geniþliðini arkaplan resminin geniþliðne eþitlememiz lazým
    //7-Bu çýkan deðeri de arkaplan scale deðerine atýcaz.(localScale)

    void Start()
    {
        //1.basamak
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        //2.basamak
        Vector2 backgroundScale = transform.localScale;//Objenin mevcut scale deðerlerini aldýk.

        //3.basamak
        float spriteGenislik = spriteRenderer.size.x;

        //4.basamak
        float ekranYukseklik = Camera.main.orthographicSize * 2.0f;
        //Bunu 2 ile çarpmamýzýn nedeni þöyle açýklayayým. Kameramýzýn bulunduðu alandan yukarý ve aþaðýya doðru gördüðü alanýn büyüklüðünü ifade eder.
        //Yani deðer 5 ise yukarý için 5 birim ve aþaðýsý için 5 birimlik görüþ saðlar. Toplamda 10 olacaðý için bunu 2 ile çarparýz.

        //5.basamak
        float cihazGenislik = ekranYukseklik / Screen.height * Screen.width;
        //Mevcut cihazýn yükseklik ve geniþlik deðerlerini alýp kameramýzýn yükseklik deðerine bölüyoruz.
        //Debug.Log("Cihaz çözünürlüðü:"+Screen.height + "*" + Screen.width+" --Kameramýzýn yüksekliði: "+ekranYukseklik+" Ekran çöz: "+ekranCozunurluk);

        //6.basamak
        backgroundScale.x = cihazGenislik / spriteGenislik;
        //7.basamak
        transform.localScale = backgroundScale;
    }


    void Update()
    {
        
    }
}
