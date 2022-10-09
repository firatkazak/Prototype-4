using System.Collections;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    private float speed = 4.0f;//Hız.
    public bool hasPowerup;//Güçlendi mi?
    private float powerupStrength = 15.0f;//Güçlendirme.
    private Rigidbody playerRb;//Player'ın rigidbody'si.
    private GameObject focalPoint;//Odak noktası.
    public GameObject powerupIndicator;//Güçlendirme göstergesi
    private void Start()
    {
     playerRb = GetComponent<Rigidbody>();//playerRb'ye rigidbody'i atadık.
     focalPoint = GameObject.Find("Focal Point");//focalPoint'e Focal Point Game Objesini atadık.
    }
    private void Update()
    {
     float verticalInput = Input.GetAxis("Vertical");//Dikey çıkış aldık.
     playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed);
     //playerRb'ye güç uygula(focalpoint'in ilerisine doğru * Dikey çıkış * hız)
     powerupIndicator.transform.position = transform.position;
     //Player'in pozisyonunu, powerupIndicator'un pozisyonuna ata.
     //Güçlendirme alınca sarı halka tam üstüne oturmuş gibi olacak.
    }
    private void OnTriggerEnter(Collider other)
    {
     if(other.CompareTag("Powerup"))//Temas ettiğimiz nesnenin tagı Powerup ise
     {
      hasPowerup = true;//hasPowerup bool değişkenini true yap.
      powerupIndicator.gameObject.SetActive(true);//powerupIndicator nesnesini aktif yap.(başlangıçta kapalı.)
      Destroy(other.gameObject);//Güçlendiriciyi yedik. haliyle yok olması gerek. Yok et dedik.
      StartCoroutine(PowerupCountdownRoutine());//PowerupCountdownRoutine fonksiyonunu çalıştır. 
     }
    }
    private void OnCollisionEnter(Collision collision)
    {
     if(collision.gameObject.CompareTag("Enemy") && hasPowerup)//Çarpılan nesnenin tagı Enemy ve hasPowerup true ise;
     {
      Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();//enemyRigidbody'e düşman rb'sini atadık.
      Vector3 awayFromPlayer = (collision.transform.position - transform.position);
      //Çarpışılan nesnenin konumundan mevcut konumu çıkar ve bunu awayFromPlayer değişkenine ata.
      enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
      //Düşman Rb'sine güç uygula(Oyuncudan uzaklık * güçlendirme gücü kadar kuvvet uygula.)
      //Yani güçlendirme alınca düşman rb'sine awayFromPlayer'in 15 katı kadar güç uygulayacağız ve düşman o kadar uzaklaşacak.
      Debug.Log("Collided with " + collision.gameObject.name + "with powerup set to " + hasPowerup);
      //Konsola yazdır.(Çarpılan nesnenin adı + güçlendi şeklinde.)
     }
    }
    IEnumerator PowerupCountdownRoutine()
    {
     yield return new WaitForSeconds(7);//Güçlendirmenin etkisi 7 saniye sürecek.
     hasPowerup = false;//7 saniye sonra güçlendirme etkisi kalkacak.
     powerupIndicator.gameObject.SetActive(false);//Güçlendirmeyi belli eden sarı halka, 7 saniye sonra kaybolacak.
    }
}
