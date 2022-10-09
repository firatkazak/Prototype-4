using UnityEngine;
public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;//Düşman Prefabını atayacağımız GameObject.
    public GameObject powerupPrefab;//Güçlendirme Prefabını atayacağımız GameObject.
    private float spawnRange = 9.0f;//Spawn aralığı.
    public int enemyCount;//Düşman sayısı.
    public int waveNumber = 1;//Dalga sayısı.
    private void Start()
    {
     SpawnEnemyWave(waveNumber);
     //SpawnEnemyWave fonksiyonunu waveNumber kadar(1) çalıştır. Yani oyun başlayınca 1 tane düşman ile başlayacak.
     Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
     //Powerup prefabından GenerateSpawnPosition konumunda, Powerup prefabının açısında YARAT. Başlangıçta 1 tane Powerup verecek. 
    }
    private void Update()
    {
     enemyCount = FindObjectsOfType<Enemy>().Length;
     //Burada sahnedeki düşman sayısını(Sanede 1 düşman varsa 1, 2 tane varsa 2) enemyCount değişkenine atadık.
     if(enemyCount == 0)//Eğer atadığımız enemyCount'taki düşman sayısı 0 ise
     {
      waveNumber++;//Dalga sayısını 1 arttır.(Düşman 0 ise 1 olacak.)
      SpawnEnemyWave(waveNumber);//SpawnEnemyWave fonksiyonunu waveNumber kadar(1) çalıştır.
      Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
      //Powerup prefabından GenerateSpawnPosition konumunda, Powerup prefabının açısında YARAT.
      //Yukarıdaki kodda Düşmanı yendikçe 1 artarak gelecek şekilde bir kod yazdık. Yani diyelim ki;
      //1 düşman öldürdük. 2.ci wave'de 2 düşman gelecek. 2'sini öldürdük. 3 düşman gelecek.
     }
    }
    private Vector3 GenerateSpawnPosition()//Spawn pozisyonu için ayrı fonksiyon yazdık.
    {
     float spawnPosX = Random.Range(-spawnRange, spawnRange);//X pozisyonu için -9+9 aralığında yarat.
     float spawnPosZ = Random.Range(-spawnRange, spawnRange);//Y pozisyonu için -9+9 aralığında yarat.
     Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);//randomPos = 9a9'luk bir kare alan içinde yeni top spawnlanacak.
     return randomPos;//randomPos'u döndür.
    }
    void SpawnEnemyWave(int enemiesToSpawn)//enemiesToSpawn isimli int tipi parametre alan fonksiyon açtık.
    {
     for(int i = 0; i < enemiesToSpawn; i++)
     //0 ile başla; i, enemyToSpawn'dan küçük olduğu sürece çalış; i'yi her döngüde 1 arttır.
     {
      Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
      //Düşman Prefabından, GenerateSpawnPosition konumunda, düşman prefabının açısında YARAT.
     }
    }
    //SpawnEnemyWave fonksiyonu: 0 tane düşman ile başladık. 1 arttırdık. enemiesToSpawn her döngüde 1 kere artacak.
    //Böylece sonsuz kere, her elde 1 artacak şekilde düşman gelecek.
}
