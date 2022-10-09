using UnityEngine;
public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed;//dönme hızı.
    private void Update()
    {
     float horizontalInput = Input.GetAxis("Horizontal");//Horizontal çıkış aldık.
     transform.Rotate(Vector3.up * Time.deltaTime * horizontalInput * rotationSpeed);
     //Transfmorm'u Döndür(yukarı * delta zamanda * horizontal çıkış * dönme hızı)
    }
}
