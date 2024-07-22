using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Kuis : MonoBehaviour
{
    public Button tombolBenar;
    public Button tombolSalah;
    public Image soalAktif;
    public SuaraKuis suaraBenar;
    public SuaraKuis suaraSalah;
    public Text textSkor;
    private SoalBenarSalah[] listSoal;
    private SoalBenarSalah soal;
    private int indeksSoalAktif = 0;
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
        if (indeksSoalAktif >= listSoal.Length)
        {
            Selesai();
            return;
        }

        soal = listSoal[indeksSoalAktif];
        Sprite newSprite = Resources.Load<Sprite>("Kuis/" + soal.pertanyaan);

        if (newSprite != null)
        {
            soalAktif.sprite = newSprite;
        }
        else
        {
            Debug.Log("Failed to load image: " + soal.pertanyaan);
        }
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
        if (soal.jawaban == jawaban)
        {
            suaraBenar.mainkan();
            Skor.instance.totalSkor += skorJawabBenar;
            textSkor.text = Skor.instance.totalSkor.ToString();
        }
        else
        {
            suaraSalah.mainkan();
        }

        indeksSoalAktif++;
        GantiSoal();
    }

    public void Selesai()
    {
        SceneManager.LoadScene("HalamanSkorKuis");
    }
}
