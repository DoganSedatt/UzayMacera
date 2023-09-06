using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    //Bu script ile arkaplandaki resmi sürekli yukarý doðru atarak sonsuz bir arkaplan hissi vereceðiz.
    //1-Arkaplan resminin y deðerini(yükseklik) alacaðýz. 
    float backGroundYPos;
    float mesafe = 10.24f;//Bir background sprite nesnesinin boyu
    void Start()
    {
        //1.basamak
        backGroundYPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (backGroundYPos + mesafe < Camera.main.transform.position.y)
        {//Kameranýn y deðeri(yükseklik) arkaplan sprite+ mesafe deðerinden büyükse BackgroundPlace metodunu çaðýr
            //Yani aslýnda kamera 10.24f'lik bir y+ hareketi yaparsa
            BackgroundPlace();
        }
    }
    void BackgroundPlace()
    {
        backGroundYPos += mesafe * 2;//Arkaplan spritenýn posunu mesafenin 2 katý kadar artýr ve ekle
        Vector2 backgroundNewYPos = new Vector2(0, backGroundYPos);//Yeni bir vector2 oluþturup arkaplan deðerini ona alýyoruz
        transform.position = backgroundNewYPos;//Daha sonra yeni pozisyon deðerini transformun deðerine at.
    }
}
