using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class yonetici : MonoBehaviour
{
    public veri_data data;
    public soru suankisoru;

    public TextMeshProUGUI Sorutexts;
    public TextMeshProUGUI Asikkis;
    public TextMeshProUGUI Bsikkis;
    public TextMeshProUGUI Csikkis;
    public TextMeshProUGUI Dsikkis;
    public Image Resims;

    public GameObject oyunKazandý;
    public GameObject oyunKaybetti;

    public TextMeshProUGUI skorText;
    private int dogruSayisi = 0;
    private int yanlisSayisi = 0;

    public int randomid;
    public void Awake()
    {
        soruver();
    }

    public void Update()
    {
        if (data.Sorular.Count == 0 & yanlisSayisi>dogruSayisi)
        {
            oyunKaybetti.SetActive(true);
        }
        else if(data.Sorular.Count == 0 & yanlisSayisi < dogruSayisi)
        {
            oyunKazandý.SetActive(true);
        }

        if (suankisoru.Resim == null)
        {
            Resims.enabled = false;
        }
        else
        {
            Resims.enabled = true;
        }
    }
    void soruver()
    {
        randomid = Random.Range(0, data.Sorular.Count);
        Debug.Log("element silindi");
        suankisoru = data.Sorular[randomid];
        Sorutexts.text = suankisoru.SoruText;
        Asikkis.text = suankisoru.Asikki;
        Bsikkis.text = suankisoru.Bsikki;
        Csikkis.text = suankisoru.Csikki;
        Dsikkis.text = suankisoru.Dsikki;
        Resims.GetComponent<Image>().sprite = suankisoru.Resim;
    }

    public void cevapver(string sik)
    {
        data.Sorular.RemoveAt(randomid);

        if (sik == suankisoru.Cevap)
        {
            Debug.Log("tebrikler dogru cevap");
            dogruCevap(); // Doðru cevap durumunda metodu çaðýr
        }
        else
        {
            Debug.Log("uzgunum yanlis cevap");
            yanlisCevap(); // Yanlýþ cevap durumunda metodu çaðýr
        }
    }

    void dogruCevap()
    {
        // Doðru cevap durumunda yapýlacak iþlemler
        soruver();
        Debug.Log("doðru");
        dogruSayisi = dogruSayisi + 1;
        skorText.text = "Doðru: " + dogruSayisi.ToString()+ " Yanlýþ: " + yanlisSayisi.ToString();
    }

    void yanlisCevap()
    {
        // Yanlýþ cevap durumunda yapýlacak iþlemler
        soruver();
        Debug.Log("yanlýþ");
        yanlisSayisi = yanlisSayisi + 1;
        skorText.text = "Doðru: " + dogruSayisi.ToString() + " Yanlýþ: " + yanlisSayisi.ToString();
    }
}
