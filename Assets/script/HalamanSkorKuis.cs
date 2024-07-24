using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;

public class HalamanSkorKuis : MonoBehaviour
{ 
    public Text totalSkor;
    public Button buttonhome;
    public Button buttonmain;

    public void Start(){
        // Debug.Log("game finish");
        totalSkor.text = Skor.instance.totalSkor.ToString();
        buttonhome.onClick.AddListener(TombolKembaliHome);
        buttonmain.onClick.AddListener(TombolKembaliMain);
    }

    public void TombolKembaliHome(){
        Skor.instance.ResetSkor();
        SceneManager.LoadScene("HalamanHome");
    }

    public void TombolKembaliMain(){
        Skor.instance.ResetSkor();
        SceneManager.LoadScene("HalamanKuis");
    }
}
