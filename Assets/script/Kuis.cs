using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kuis : MonoBehaviour
{
    public Button tombolBenar;
    public Image soalAktif;
    private SoalBenarSalah[] listSoal;
    private int indeksSoalAktif = 0;

    void Start()
    {
        string lokasiSoal = Path.Combine(Application.dataPath, "Data/kuis.json");

        GeneratorSoal generator = new GeneratorSoal(lokasiSoal);
        listSoal = generator.GetSoalAcak();

        SetImage();
        tombolBenar.onClick.AddListener(ChangeImage);
    }

    void SetImage()
    {
        SoalBenarSalah soal = listSoal[indeksSoalAktif];
        Sprite newSprite = Resources.Load<Sprite>("Kuis/" + soal.pertanyaan);

        if (newSprite != null)
        {
            soalAktif.sprite = newSprite;
        }
        else
        {
            Debug.Log("Failed to load image: " + soal.pertanyaan);
        }

         indeksSoalAktif++;
    }

    void ChangeImage()
    {
        if (indeksSoalAktif < listSoal.Length)
        {
            SetImage();
        }
    }
}
