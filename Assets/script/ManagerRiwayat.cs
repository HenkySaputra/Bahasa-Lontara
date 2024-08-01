using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;

public class ManagerRiwayat
{

    public static void SimpanSkor(string kategori, string waktu)
    {
        List<Riwayat> listRiwayat;
        string lokasiFile = Path.Combine(Application.persistentDataPath, "riwayat.json");

        if (File.Exists(lokasiFile))
        {
            string json = File.ReadAllText(lokasiFile);
            listRiwayat = JsonConvert.DeserializeObject<List<Riwayat>>(json);
        }
        else
        {
            listRiwayat = new List<Riwayat>();
        }

        Riwayat newRiwayat = new Riwayat             
        {
            skor = Skor.instance.totalSkor,
            kategori = kategori,
            waktu = waktu
        };

        listRiwayat.Insert(0, newRiwayat);

        string jsonTerbaru = JsonConvert.SerializeObject(listRiwayat, Formatting.Indented);

        File.WriteAllText(lokasiFile, jsonTerbaru);
    }
}