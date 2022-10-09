using UnityEngine;
public class Enemy : MonoBehaviour
{
    public float speed;//Hız.
    private Rigidbody enemyRb;//Düşman Rigidbody'si.
    private GameObject player;//Takip edilecek Player Game Objesi.
    private void Start()
    {
     enemyRb = GetComponent<Rigidbody>();//Düşmanın rigidbody komponentini tanımladık.
     player = GameObject.Find("Player");//Player isimli game objesini bulup player Game Objemize atadık.
    }
    private void Update()
    {
     ////.normalized Bu vektörü 1 büyüklüğünde döndürür.
     Vector3 lookDirection = (player.transform.position - transform.position).normalized;
     //Yöne bak = player'in pozisyonundan - düşmanın mevcut pozisyonunu çıkart.
     //Bu yöntemle sürekli düşman topun ön kısmı player'a bakacak. alttaki kod ile de onu kovalayacak.
     enemyRb.AddForce(lookDirection * speed);//Düşman rb'sine güç uygula(lookDirection yönünde * speed hızında)
     if(transform.position.y < -10)//Eğer düşmanın y kordinatındaki pozisyonu -10'dan küçük ise(-10.1 gibi)
     //Toplar aşağı düştüğünde silinsin diye yazdık bu kodu.
     {
      Destroy(gameObject);//Yok et.
     }
    }
}
