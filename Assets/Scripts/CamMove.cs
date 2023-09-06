using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    //Bu script dosyasýnda kameranýn zaman içerisinde yukarýya doðru hareket etmesi saðlayacaðýz.
    //Ayný zamanda arkaplan resimleri de sürekli üst üste eklenerek sonsuz bir arkaplan hissi verecek.
    //1-Kameranýn hýzýný kontrol etmek için float türünde deðiþken
    //2-Kameranýn zaman içerisinde ne kadar hýzlanacaðýný kontrol etmek için float bir hýzlanma deðeri
    //3-Ve son olarak maxHýz deðeri.Hýzlanmasýný sonsuza kadar artýrmak mantýksýz olur
    //4-Belirli durumlarda kamera hareketini durdurup baþlatmak için bool türünde deðiþken.
    //5-Kamerayý hareket ettirmek için y deðerini sürekli artýrmak gerek
    //6-Kameranýn hýzlanmasýný saðlamak için hýz ile hýzlanma deðerini çarpýp hýz deðiþkenine tekrardan atalým.
    //7-Hýzýmýz maxHýz deðerini geçmesin diye if ile kontrol edicez.
    float hiz, hizlanma, maxHiz;
    bool hareketDurumu=true;//default deðeri false
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
        
        Debug.Log("Mecvut hýzým:" + hiz);
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
