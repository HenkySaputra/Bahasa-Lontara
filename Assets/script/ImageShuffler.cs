using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class ImageShuffler : MonoBehaviour
{
    // Konstanta untuk LCM
    private const int a = 1664525;
    private const int c = 1013904223;
    private const int m = int.MaxValue;
    private int seed;

    // Daftar gambar yang akan diacak
    public List<Image> images;

    // Durasi setiap perpindahan gambar
    public float moveDuration = 1f;
    public float waitBetweenMoves = 0.5f;

    private void Start()
    {
        // Inisialisasi seed dengan waktu saat ini
        seed = System.DateTime.Now.Millisecond;

        // Mengacak gambar
        ShuffleImages();

        // Menampilkan urutan gambar yang telah diacak
        StartCoroutine(DisplayShuffledImages());
    }

    private int LCM()
    {
        seed = (a * seed + c) % m;
        return seed;
    }

    private void ShuffleImages()
    {
        for (int i = 0; i < images.Count; i++)
        {
            int randomIndex = LCM() % images.Count;
            // Swap images[i] dengan images[randomIndex]
            Image temp = images[i];
            images[i] = images[randomIndex];
            images[randomIndex] = temp;
        }
    }

    private IEnumerator DisplayShuffledImages()
    {
        for (int i = 0; i < images.Count; i++)
        {
            // Set posisi gambar
            images[i].transform.SetSiblingIndex(i);
            Debug.Log("Image " + i + ": " + images[i].name);

            // Move the image to a new position
            RectTransform rectTransform = images[i].GetComponent<RectTransform>();
            Vector2 startPosition = rectTransform.anchoredPosition;
            Vector2 targetPosition = new Vector2(i * 100, i * 100); // Example target position

            float elapsedTime = 0f;

            while (elapsedTime < moveDuration)
            {
                rectTransform.anchoredPosition = Vector2.Lerp(startPosition, targetPosition, elapsedTime / moveDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            rectTransform.anchoredPosition = targetPosition;
            yield return new WaitForSeconds(waitBetweenMoves);
        }
    }
}
