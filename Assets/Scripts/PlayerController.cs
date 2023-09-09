using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    [RequireComponent(typeof(Rigidbody2D))]//Bu scripte sahip obje mutlaka Rigidbody2D bile�enine sahip olmak zorundad�r.
public class PlayerController : MonoBehaviour
{
    //Bu script oyuncunun y�r�me z�plama gibi animasyonlar�n� konrol etmek i�in kullan�lacak.

    Rigidbody2D rb;
    Animator animator;//Animasyon kontrol� i�in
    Vector2 velocity;//H�z
    [SerializeField]
    float speed = default;
    [SerializeField]
    float acceleration = default;
    [SerializeField]
    float deceleration = default;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControlFNC();
    }

    void PlayerControlFNC()//Oyuncu kontrol metodu
    {
        float horizontalMoveInput = Input.GetAxisRaw("Horizontal");//A,D ve sa� sol oklar ile yatay hareket kontrol� sa�lanacak
        Vector2 playerScale = transform.localScale;//Karakterin localscale de�i�ken de�erini ald�k.Sa�a sola d�n��lerde karakterin y�z�n� de �evirmek i�in
        if (horizontalMoveInput > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x,horizontalMoveInput*speed,acceleration*Time.deltaTime);
            //Mevcut de�er,ula��lmak istenen de�er,art�� miktar�
            animator.SetBool("Walk", true);
            playerScale.x = 1;//karakterin sa�a bakmas�n� sa�lar
        }
        else if (horizontalMoveInput < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, horizontalMoveInput * speed, acceleration * Time.deltaTime);
            //Mevcut de�er,ula��lmak istenen de�er,art�� miktar�
            animator.SetBool("Walk", true);
            playerScale.x = -1;//Karakterin sola bakmas�n� sa�lar
        }
        else
        {
            //Karakter hi�bir tu�a basm�yorsa dursun 
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
            animator.SetBool("Walk", false);
        }
        transform.Translate(velocity*Time.deltaTime);
        //Daha sonra velocity de�erini player'�n transform de�erine at�yoruz ki hareket sa�lans�n
        transform.localScale=playerScale;
        //playerScale de�erini karakterin localScale de�erine e�itliyoruz ki karakterin sa�a sola bakmas� sa�lans�n
    }
}
