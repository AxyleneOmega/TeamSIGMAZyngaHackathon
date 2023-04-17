using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public GameObject smallMeteorPrefab;
    public GameObject mediumMeteorPrefab;
    public GameObject largeMeteorPrefab;
    public int maxObstaclesOnScreen = 5;
    [SerializeField] private List<GameObject> children;
    [SerializeField] private float difficulty = 0;
    [SerializeField] private float linearDifficulty = 0;
    [Range(0f, 1f)]
    public float difficultyVariation=0.5f;
    [Range(0f, 2f)]
    public float difficultyVariationFrequency = 0.5f;

    PlayerScript ps;

    private bool currentlySpawning = false;

    private void Start()
    {
        difficulty = 0;
        linearDifficulty = 0;
        ps = FindAnyObjectByType<PlayerScript>();
    }
    private void Update()
    {
        if (children.Count <= 0 && ps.gameRunning)
            currentlySpawning = true;       
    }

    public void StopGame()
    {
        currentlySpawning = false;
        foreach (GameObject meteor in children)
        {
            meteor.GetComponent<MeteorScript>().Kill(0f,0);
        }
    }
    public void removeMeteor(GameObject meteorRef)
    {
        children.Remove(meteorRef);
    }
    IEnumerator spawn(GameObject gameObject, float delay)
    {
        currentlySpawning = true;
        yield return new WaitForSeconds(delay);
        GameObject meteor = Instantiate(gameObject);
        children.Add(meteor);
        meteor.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(Screen.safeArea.xMin + 50, Screen.safeArea.xMax - 50), Screen.safeArea.yMax + 50, 10));
        if (children.Count <= maxObstaclesOnScreen)
        {
            yield return new WaitForSeconds(delay);
            currentlySpawning = false;
        }
    }

    private void FixedUpdate()
    {
        linearDifficulty += Time.fixedDeltaTime;
        difficulty = Mathf.Pow(linearDifficulty, 0.36787f) * (Mathf.Log(linearDifficulty + 1) + (difficultyVariation * Mathf.Sin(difficultyVariationFrequency * linearDifficulty)));

        if (ps.gameRunning && Time.timeScale > 0 && !currentlySpawning)
        {
            int x = Random.Range(0, 5);
            switch (x){
                case 0: 
                case 1:
                case 2:
                    StartCoroutine(spawn(smallMeteorPrefab, Random.Range(0f, 1f)));
                    break;
                case 3:
                case 4:
                    StartCoroutine(spawn(mediumMeteorPrefab, Random.Range(0f, 3f)));
                    break;
                case 5:
                    StartCoroutine(spawn(largeMeteorPrefab, Random.Range(0f, 5f)));
                    break;
                default:
                    break;
            }
        }
    }
}
