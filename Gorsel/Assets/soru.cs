using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class soru
{
    public string SoruText;
    public string Asikki;
    public string Bsikki;
    public string Csikki;
    public string Dsikki;
    public string Cevap;
    public Sprite Resim;

    void sorular(string asikki, string bsikki, string csikki, string dsikki, string cevap,string sorutext,Sprite resim,string soruText)
    {
        SoruText = soruText;
        Asikki = asikki;
        Bsikki = bsikki;
        Csikki = csikki;
        Dsikki = dsikki;
        Cevap = cevap;
        Resim = resim;
        
    }
}
