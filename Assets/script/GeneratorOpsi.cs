using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

public class GeneratorOpsi
{

    private Opsi[] listOpsi = new Opsi[]
    {
        new Opsi { id = 0, label = 'a'},
        new Opsi { id = 1, label = 'b'},
        new Opsi { id = 2, label = 'c'},
        new Opsi { id = 3, label = 'd'},
    };
    
    private int a = 11;
    private int c = 7;
    private int m = 4;

    private int jumlahOpsiAktif = 4;

    private int LCM(int xn)
    {
      return (a * xn + c) % m;
    }

    private int GetX0()
    {
        System.Random random = new System.Random();
        return random.Next(0, 100);
    }

    public Opsi[] GetOpsiAcak()
    {
        int[] listIndexOpsi = Enumerable.Range(0, listOpsi.Length).ToArray();

        int xn = GetX0();

        for (int i = 0; i < listIndexOpsi.Length; i++)
        {
            xn = LCM(xn);
            int temp = listIndexOpsi[i];
            listIndexOpsi[i] = listIndexOpsi[xn];
            listIndexOpsi[xn] = temp;
        }

        Opsi[] listOpsiAcak = new Opsi[jumlahOpsiAktif];

        for (int i = 0; i < jumlahOpsiAktif; i++)
        {
            listOpsiAcak[i] = listOpsi[listIndexOpsi[i]];
        }

        return listOpsiAcak;
    }
}