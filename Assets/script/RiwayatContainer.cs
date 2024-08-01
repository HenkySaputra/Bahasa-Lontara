using UnityEngine;
using UnityEngine.UI;

public class RiwayatContainer : MonoBehaviour
{
    public Text skorText;
    public Text kategoriText;
    public Text waktuText;

    public void SetData(Riwayat data)
    {
        skorText.text = data.skor.ToString();
        kategoriText.text = data.kategori;
        waktuText.text = data.waktu;
    }
}