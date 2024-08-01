using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KuisBenarSalah : MonoBehaviour
{
    public Button tombolBenar;
    public Button tombolSalah;
    public Image soalAktif;
    public SuaraKuis suaraBenar;
    public SuaraKuis suaraSalah;
    public Text textSkor;
    public Text textWaktu;
    private Soal[] listSoal;
    private Soal soal;
    private int indeksSoalAktif = 0;
    private int skorJawabBenar = 10;
    private float waktuMulai;
    private bool kuisBerjalan = false;


    void Start()
    {
        TextAsset dataKuis = Resources.Load<TextAsset>("Data/KuisBenarSalah");

        GeneratorSoal generator = new GeneratorSoal(dataKuis);
        listSoal = generator.GetSoalAcak();

        // Jalankan waktu
        waktuMulai = Time.time;
        kuisBerjalan = true;

        GantiSoal();
        tombolBenar.onClick.AddListener(JawabBenar);
        tombolSalah.onClick.AddListener(JawabSalah);
    }

    void Update()
    {
        if (kuisBerjalan)
        {
            float selisihWaktu = Time.time - waktuMulai;
            string menit = Mathf.Floor(selisihWaktu / 60).ToString("00");
            string detik = (selisihWaktu % 60).ToString("00");

            textWaktu.text = menit + ":" + detik;
        }
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
        kuisBerjalan = false;
        ManagerRiwayat.SimpanSkor("Kuis Salah Benar", textWaktu.text);
        SceneManager.LoadScene("HalamanSkorKuis");
    }
}
