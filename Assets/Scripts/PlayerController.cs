using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    [RequireComponent(typeof(Rigidbody2D))]//Bu scripte sahip obje mutlaka Rigidbody2D bileþenine sahip olmak zorundadýr.
public class PlayerController : MonoBehaviour
{
    //Bu script oyuncunun yürüme zýplama gibi animasyonlarýný konrol etmek için kullanýlacak.

    Rigidbody2D rb;
    Animator animator;//Animasyon kontrolü için
    Vector2 velocity;//Hýz
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
        float horizontalMoveInput = Input.GetAxisRaw("Horizontal");//A,D ve sað sol oklar ile yatay hareket kontrolü saðlanacak
        Vector2 playerScale = transform.localScale;//Karakterin localscale deðiþken deðerini aldýk.Saða sola dönüþlerde karakterin yüzünü de çevirmek için
        if (horizontalMoveInput > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x,horizontalMoveInput*speed,acceleration*Time.deltaTime);
            //Mevcut deðer,ulaþýlmak istenen deðer,artýþ miktarý
            animator.SetBool("Walk", true);
            playerScale.x = 1;//karakterin saða bakmasýný saðlar
        }
        else if (horizontalMoveInput < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, horizontalMoveInput * speed, acceleration * Time.deltaTime);
            //Mevcut deðer,ulaþýlmak istenen deðer,artýþ miktarý
            animator.SetBool("Walk", true);
            playerScale.x = -1;//Karakterin sola bakmasýný saðlar
        }
        else
        {
            //Karakter hiçbir tuþa basmýyorsa dursun 
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
            animator.SetBool("Walk", false);
        }
        transform.Translate(velocity*Time.deltaTime);
        //Daha sonra velocity deðerini player'ýn transform deðerine atýyoruz ki hareket saðlansýn
        transform.localScale=playerScale;
        //playerScale deðerini karakterin localScale deðerine eþitliyoruz ki karakterin saða sola bakmasý saðlansýn
    }
}
