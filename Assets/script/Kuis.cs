using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kuis : MonoBehaviour
{
    public Button tombolBenar;
    public Button tombolSalah;
    public Image soalAktif;
    public SuaraKuis suaraBenar;
    public SuaraKuis suaraSalah;
    public Text textSkor;
    private SoalBenarSalah[] listSoal;
    private int indeksSoalAktif = 0;
    private int skor = 0;
    private int skorJawabBenar = 10;

    void Start()
    {
        string lokasiSoal = Path.Combine(Application.dataPath, "Data/kuis.json");

        GeneratorSoal generator = new GeneratorSoal(lokasiSoal);
        listSoal = generator.GetSoalAcak();

        GantiSoal();
        tombolBenar.onClick.AddListener(JawabBenar);
        tombolSalah.onClick.AddListener(JawabSalah);
    }

    void GantiSoal()
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

    void JawabBenar()
    {
        PeriksaJawaban(1);
    }

    void JawabSalah()
    {
        PeriksaJawaban(0);
    }

    void PeriksaJawaban(int jawaban)
    {
        if (indeksSoalAktif < listSoal.Length)
        {
            SoalBenarSalah soal = listSoal[indeksSoalAktif];

            if (soal.jawaban == jawaban)
            {
                suaraBenar.mainkan();
                skor += skorJawabBenar;
            }
            else
            {
                suaraSalah.mainkan();
            }

            textSkor.text = skor.ToString();
            GantiSoal();
        }
    }
}
