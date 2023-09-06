using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    //Bu script ile arkaplandaki resmi s�rekli yukar� do�ru atarak sonsuz bir arkaplan hissi verece�iz.
    //1-Arkaplan resminin y de�erini(y�kseklik) alaca��z. 
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
        {//Kameran�n y de�eri(y�kseklik) arkaplan sprite+ mesafe de�erinden b�y�kse BackgroundPlace metodunu �a��r
            //Yani asl�nda kamera 10.24f'lik bir y+ hareketi yaparsa
            BackgroundPlace();
        }
    }
    void BackgroundPlace()
    {
        backGroundYPos += mesafe * 2;//Arkaplan spriten�n posunu mesafenin 2 kat� kadar art�r ve ekle
        Vector2 backgroundNewYPos = new Vector2(0, backGroundYPos);//Yeni bir vector2 olu�turup arkaplan de�erini ona al�yoruz
        transform.position = backgroundNewYPos;//Daha sonra yeni pozisyon de�erini transformun de�erine at.
    }
}
