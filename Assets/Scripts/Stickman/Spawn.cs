using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject stickman;
    public Transform[] levels;

    float spawnTimer = 0;
    float nextSpawn = 0;
    float hardnessDelayMultiplier = 2;
    float hardnessTime = 10;
    public int delay = 2;

	private void Start ()
    {
        CaluculateNextSpawn();
    }

    private void FixedUpdate ()
    {
        hardnessTime -= Time.fixedDeltaTime;
        spawnTimer += Time.fixedDeltaTime;
        if (spawnTimer > nextSpawn)
        {
            SpawnMan();
            CaluculateNextSpawn();
        }

        if (hardnessTime < 0)
        {
            hardnessDelayMultiplier /= 1.2f;
            hardnessTime = 10;
        }
	}

    private void SpawnMan()
    {
        int h = Random.Range(0, levels.Length);
        GameObject nextMan = Instantiate(stickman);
        nextMan.transform.position = new Vector3(-11, levels[h].position.y, 0);
        nextMan.layer = levels[h].gameObject.layer + 7;
        nextMan.GetComponent<StickmanFly>().rightBorderPos = levels[h].GetChild(0).position;
        nextMan.GetComponent<StickmanAttack>().damage = Random.Range(10, 50);
        nextMan.GetComponent<StickmanRun>().speed = Random.Range(1, 5);
        nextMan.GetComponent<StickmanAnim>().Go();
    }

    private void CaluculateNextSpawn()
    {
        nextSpawn += Random.Range(delay * Mathf.Min(0, hardnessDelayMultiplier - 0.5f), delay * hardnessDelayMultiplier + 0.5f);
    }


}
