using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

public class GeneratorSoal
{
    private List<SoalBenarSalah> listSoal;
    private int a = 11;
    private int c = 7;
    private int m;
    private int jumlahSoalAktif = 10;

    public GeneratorSoal(TextAsset dataKuis)
    {
        listSoal = JsonConvert.DeserializeObject<List<SoalBenarSalah>>(dataKuis.text);
        m = listSoal.Count;
    }

    private int LCM(int xn)
    {
      return (a * xn + c) % m;
    }

    private int GetX0()
    {
        System.Random random = new System.Random();
        return random.Next(0, 100);
    }

    public SoalBenarSalah[] GetSoalAcak()
    {
        List<int> listIndexSoal = Enumerable.Range(0, listSoal.Count).ToList();

        int xn = GetX0();

        for (int i = 0; i < listIndexSoal.Count; i++)
        {
            xn = LCM(xn);
            int temp = listIndexSoal[i];
            listIndexSoal[i] = listIndexSoal[xn];
            listIndexSoal[xn] = temp;
        }

        SoalBenarSalah[] listSoalAcak = new SoalBenarSalah[jumlahSoalAktif];

        for (int i = 0; i < jumlahSoalAktif; i++)
        {
            listSoalAcak[i] = listSoal[listIndexSoal[i]];
        }

        return listSoalAcak;
    }
}