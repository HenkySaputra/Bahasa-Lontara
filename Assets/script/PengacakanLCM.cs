using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PengacakanLCM : MonoBehaviour
{
   // Konstanta untuk LCM
    private const int a = 1664525;
    private const int c = 1013904223;
    private const int m = int.MaxValue;
    private int seed;

    // Daftar gambar
    public List<Image> images;

    void Start()
    {
        // Inisialisasi seed dengan waktu saat ini
        seed = System.DateTime.Now.Millisecond;

        // Mengacak gambar
        ShuffleImages();
        
        // Menampilkan urutan gambar yang telah diacak (untuk debugging)
        for (int i = 0; i < images.Count; i++)
        {
            images[i].transform.SetSiblingIndex(i);
        }
    }

    int LCM()
    {
        seed = (a * seed + c) % m;
        return seed;
    }

    void ShuffleImages()
    {
        for (int i = 0; i < images.Count; i++)
        {
            int randomIndex = LCM() % images.Count;
            // Swap images[i] dengan images[randomIndex]
            Image temp = images[i];
            images[i] = images[randomIndex];
            images[randomIndex] = temp;
        }
    }

    void DisplayShuffledImages()
    {
    for (int i = 0; i < images.Count; i++)
    {
        images[i].transform.SetSiblingIndex(i);
        Debug.Log("Image " + i + ": " + images[i].name);
    }
}
}
