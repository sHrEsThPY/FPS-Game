using UnityEngine;
using TMPro;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public Transform point1;
    public Transform point2;
    public Transform point3;

    public TextMeshProUGUI countdownText;

    void Start()
    {
        StartCoroutine(SpawnWithCountdown());
    }

    IEnumerator SpawnWithCountdown()
    {
        countdownText.gameObject.SetActive(true);

        for (int i = 3; i > 0; i--)
        {
            countdownText.text = "Enemy Will Be Here In\n<size=200>" + i + "</size>";

            countdownText.transform.localScale = Vector3.one * 1.5f;

            float t = 0f;
            while (t < 0.2f)
            {
                t += Time.deltaTime * 5f;
                countdownText.transform.localScale = Vector3.Lerp(Vector3.one * 1.5f, Vector3.one, t);
                yield return null;
            }

            yield return new WaitForSeconds(0.8f);
        }

        countdownText.gameObject.SetActive(false);

        SpawnEnemy();
    }


    void SpawnEnemy()
    {
        int random = Random.Range(0, 3);

        Transform spawnPoint = point1;

        if (random == 1)
            spawnPoint = point2;
        else if (random == 2)
            spawnPoint = point3;

        Instantiate(enemyPrefab,
                    spawnPoint.position,
                    spawnPoint.rotation);
    }
}
