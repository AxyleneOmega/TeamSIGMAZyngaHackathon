using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public GameObject smallMeteorPrefab;
    public GameObject mediumMeteorPrefab;
    public GameObject largeMeteorPrefab;
    PlayerScript ps;

    private bool currentlySpawning = false;

    private void Start()
    {
        ps = FindAnyObjectByType<PlayerScript>();
    }
    IEnumerator spawn(GameObject gameObject, float delay)
    {
        currentlySpawning = true;
        yield return new WaitForSeconds(delay);
        float xMin = Screen.safeArea.xMin;
        float yMin = Screen.safeArea.yMin;
        float xMax = Screen.safeArea.xMax;
        float yMax = Screen.safeArea.yMax;
        GameObject m = Instantiate(gameObject);
        m.transform.position = Camera.main.ScreenToWorldPoint(new Vector2(Random.Range(20, Screen.width - 20), 5), 0);
        currentlySpawning = false;
    }

    private void FixedUpdate()
    {
        if (ps.gameRunning && Time.timeScale > 0 && !currentlySpawning)
        {
            StartCoroutine(spawn(smallMeteorPrefab, 1));
            StartCoroutine(spawn(mediumMeteorPrefab, 3));
            StartCoroutine(spawn(largeMeteorPrefab, 5));
        }

    }
}
