using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public float startDelay;
    public float enemyDelay;
    public float waveDelay;

    public int enemiesInWaves;
    public GameObject[] enemyPrefabs;

    public int score;
    public Text scoreText;

    AudioSource audio;


    void Start()
    {
        StartCoroutine(SpawnWaves());

        audio = GetComponent<AudioSource>();
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startDelay);
        while (true)
        {
            for (int i = 0; i < enemiesInWaves; i++)
            {
                Vector2 spawnPosition = new Vector2(Random.Range(-5, 5), 6);
                Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(enemyDelay);
            }
            audio.Play();
            yield return new WaitForSeconds(waveDelay);
        }
    }

    public void AddToScore(int points)
    {
        score += points;
        scoreText.text = "Score:  " + score.ToString();
    }
}
