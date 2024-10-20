using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class oyuncu : MonoBehaviour
{
    //public GameObject yandýn;
    int puan = 0;
    int yildiz = 0;
    public AudioSource arabaSes;
    public AudioSource sesDosyasi;
    public AudioClip yildizSes;
    public Transform yol1;
    public Transform yol2;
    public Text puanText;
    public Text yildizText;
    public GameObject oyunDurdu;
    public bool oyunDurduMu = false;
    private float gecenZaman = 0f;       // Zamanlayýcý deðiþkeni
    public float onSaniye = 10f;    // Artýþ aralýðý (saniye)
    public bool sesAcikMi = true;
    public GameObject solButon, sagButon;
    public GameObject OyunaDevamEt;
    public GameObject OyunaDevamEtme;
    public GameObject OyunuDurdur;


    void Start()
    {
        arabaSes.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SON_1")
        {
            yol2.position = new Vector3(yol1.position.x, yol1.position.y, yol1.position.z + 100.0f);
        }
        if (other.gameObject.name == "SON_2")
        {
            yol1.position = new Vector3(yol2.position.x, yol2.position.y, yol2.position.z + 100.0f);
        }

        if (other.gameObject.tag == "engel")
        {
            //yandýn.SetActive(true);
            Time.timeScale = 0.0f;
            Debug.Log("ÇARPTIN engel");
            oyunDurdu.SetActive(true);
            oyunDurduMu = true;
            arabaSes.enabled = false;
            sesDosyasi.enabled = false;
            OyunaDevamEt.SetActive(false);
            OyunaDevamEtme.SetActive(false);
            OyunuDurdur.SetActive(false);

        }
        if (other.gameObject.tag == "yildiz")
        {
            sesDosyasi.PlayOneShot(yildizSes);
            Destroy(other.gameObject);
            yildiz++;
            puan += 5;
            Debug.Log("ÇARPTIN yildiz");
        }
    }

    void Update()
    {
        puanText.text = puan.ToString();
        yildizText.text = yildiz.ToString();

        gecenZaman += Time.deltaTime;
        if (gecenZaman >= onSaniye)
        {
            puan += 3;
            gecenZaman = 0f;
        }

        if (oyunDurduMu == false)
        {
            hareket();
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                // W veya Up Arrow tuþlarý basýlýyor
                sola_don();
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                // W veya Up Arrow tuþlarý basýlýyor
                saga_don();
            }
        }
        
    }
    void hareket()
    {
        transform.Translate(Vector3.forward * 0.2f);

    }
    public void sola_don()
    {
        transform.Translate(Vector3.left * 0.1f);

    }
    public void saga_don()
    {
        transform.Translate(Vector3.right * 0.1f);

    }
    public void oyundanCik()
    {
        Application.Quit();
    }
    public void sesAcKapa()
    {
        if (sesAcikMi)
        {
            AudioListener.volume = 0f;
            sesAcikMi = !sesAcikMi;
        }
        else
        {
            AudioListener.volume = 1f;
            sesAcikMi = !sesAcikMi;
        }
    }
    public void yenidenBaslat()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void durdurBaslat()
    {
        if (!oyunDurduMu)
        {
            oyunDurduMu = true;
            Time.timeScale = 0.0f;
            oyunDurdu.SetActive(true);
            sagButon.SetActive(false);
            solButon.SetActive(false);
            AudioListener.volume = 0f;
        }
        else
        {
            oyunDurduMu = false;
            Time.timeScale = 1f;
            oyunDurdu.SetActive(false);
            sagButon.SetActive(true);
            solButon.SetActive(true);
            AudioListener.volume = 1f;
        }
    }
}
