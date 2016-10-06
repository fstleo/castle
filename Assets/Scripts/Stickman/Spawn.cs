using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject stickman;
    public Transform[] levels;
    [SerializeField]
    Destroyable castle;
    AttackerParameters aParams;
    FlyingParameters fParams;
    RunnerParameters rParams;

    float spawnTimer = 0;
    float nextSpawn = 0;
    float hardnessDelayMultiplier = 2;
    float hardnessTime = 10;
    public int delay = 2;

	private void Start ()
    {
        Debug.Log(stickman.name);
        aParams = Resources.Load<AttackerParameters>(string.Format("Parameters/AttackParameters/{0}_AttackParameters", stickman.name)) as AttackerParameters;
        rParams = Resources.Load<RunnerParameters>(string.Format("Parameters/RunParameters/{0}_RunParameters", stickman.name)) as RunnerParameters;
        fParams = Resources.Load<FlyingParameters>(string.Format("Parameters/FlyParameters/{0}_FlyParameters", stickman.name)) as FlyingParameters;
        aParams.Target = castle;
        SpawnMan();
        CaluculateNextSpawn();
    }

    private void FixedUpdate ()
    {
        //hardnessTime -= Time.fixedDeltaTime;
        //spawnTimer += Time.fixedDeltaTime;
        //if (spawnTimer > nextSpawn)
        //{
        //    SpawnMan();
        //    CaluculateNextSpawn();
        //}

        //if (hardnessTime < 0)
        //{
        //    hardnessDelayMultiplier /= 1.2f;
        //    hardnessTime = 10;
        //}
	}

    private void SpawnMan()
    {
        int h = Random.Range(0, levels.Length);
        GameObject nextMan = Instantiate(stickman);
        nextMan.transform.position = new Vector3(-11, levels[h].position.y, 0);
        nextMan.layer = levels[h].gameObject.layer + 7;

        Stickman s = nextMan.GetComponent<Stickman>();
        s.aParams = aParams;
        s.rParams = rParams;
        s.fParams = fParams;
        s.Init();
    }

    private void CaluculateNextSpawn()
    {
        nextSpawn += Random.Range(delay * Mathf.Min(0, hardnessDelayMultiplier - 0.5f), delay * hardnessDelayMultiplier + 0.5f);
    }


}
