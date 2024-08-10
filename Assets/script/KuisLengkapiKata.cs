using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KuisLengkapiKata : MonoBehaviour
{
    public Button tombolA;
    public Button tombolB;
    public Button tombolC;
    public Button tombolD;
    public Text soalAktif;
    public SuaraKuis suaraBenar;
    public SuaraKuis suaraSalah;
    public Text textSkor;
    public Text textWaktu;
    private Soal[] listSoal;
    private Soal soal;
    private int indeksSoalAktif = 0;
    private int skorJawabBenar = 10;

    private GeneratorOpsi generatorOpsi;
    private Opsi buttonAValue;
    private Opsi buttonBValue;
    private Opsi buttonCValue;
    private Opsi buttonDValue;
    private float waktuMulai;
    private bool kuisBerjalan = false;


    void Start()
    {
        TextAsset dataKuis = Resources.Load<TextAsset>("Data/KuisLengkapiKata");

        GeneratorSoal generatorSoal = new GeneratorSoal(dataKuis);
        generatorOpsi = new GeneratorOpsi();

        listSoal = generatorSoal.GetSoalAcak();

        GantiSoal();

        // Jalankan waktu
        waktuMulai = Time.time;
        kuisBerjalan = true;

        tombolA.onClick.AddListener(JawabA);
        tombolB.onClick.AddListener(JawabB);
        tombolC.onClick.AddListener(JawabC);
        tombolD.onClick.AddListener(JawabD);
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
        soalAktif.text = soal.pertanyaan;
        GantiOpsi();
    }

    void GantiOpsi()
    {
        string lokasiOpsi = "OpsiKuisLengkapiKata/" + soal.id + "/";
        Opsi[] listOpsi = generatorOpsi.GetOpsiAcak();

        buttonAValue = listOpsi[0];
        buttonBValue = listOpsi[1];
        buttonCValue = listOpsi[2];
        buttonDValue = listOpsi[3];

        Sprite newSpriteA = Resources.Load<Sprite>(lokasiOpsi + buttonAValue.label);
        Sprite newSpriteB = Resources.Load<Sprite>(lokasiOpsi + buttonBValue.label);
        Sprite newSpriteC = Resources.Load<Sprite>(lokasiOpsi + buttonCValue.label);
        Sprite newSpriteD = Resources.Load<Sprite>(lokasiOpsi + buttonDValue.label);

        tombolA.image.sprite = newSpriteA;
        tombolB.image.sprite = newSpriteB;
        tombolC.image.sprite = newSpriteC;
        tombolD.image.sprite = newSpriteD;
    }

    void JawabA()
    {
        PeriksaJawaban(buttonAValue);
    }
    void JawabB()
    {
        PeriksaJawaban(buttonBValue);
    }

    void JawabC()
    {
        PeriksaJawaban(buttonCValue);
    }

    void JawabD()
    {
        PeriksaJawaban(buttonDValue);
    }

    void PeriksaJawaban(Opsi jawaban)
    {
        if (soal.jawaban == jawaban.id)
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
        ManagerRiwayat.SimpanSkor("Kuis Pilihan Ganda", textWaktu.text);
        SceneManager.LoadScene("HalamanSkorLengkapiKata");
    }
}
