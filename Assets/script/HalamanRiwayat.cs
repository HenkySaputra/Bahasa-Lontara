using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class HalamanRiwayat : MonoBehaviour
{
    public string lokasiFile = "riwayat.json";
    public Transform contentPanel;
    public GameObject riwayatPrefab;

    private void Start()
    {
        string path = Path.Combine(Application.persistentDataPath, lokasiFile);
        List<Riwayat> listRiwayat;

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            listRiwayat = JsonConvert.DeserializeObject<List<Riwayat>>(json);
        }
        else
        {
            listRiwayat = new List<Riwayat>();
        }

        TampilkanData(listRiwayat);
    }

    private void TampilkanData(List<Riwayat> listRiwayat)
    {
        foreach (var riwayat in listRiwayat)
        {
            GameObject newItem = Instantiate(riwayatPrefab, contentPanel);
            RiwayatContainer riwayatContainer = newItem.GetComponent<RiwayatContainer>();
            riwayatContainer.SetData(riwayat);
        }

        Destroy(riwayatPrefab);

        Canvas.ForceUpdateCanvases();
        ScrollRect scrollRect = contentPanel.GetComponentInParent<ScrollRect>();
    }
}