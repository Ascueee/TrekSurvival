using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessModeManager : MonoBehaviour
{
    [Header("Endless Mode Variables")]
    [SerializeField] GameObject[] objectivesToPick;
    [SerializeField] Transform[] objectiveSpawnPoints;
    [SerializeField] Transform[] dropsSpawnPoints;
    [SerializeField] GameObject objective;
    [SerializeField] GameObject hordeSurvivalObj;
    [SerializeField] bool spawnObjective;
    [SerializeField] int rounds;

    [Header("Drop Componenets")]
    [SerializeField] GameObject[] drops;

    [Header("Sound Effects")]
    [SerializeField] AudioSource audioSrc;
    [SerializeField] AudioClip completedObjectiveSfx;

    GameObject payload;
    bool spawnOneObjective = true;
    int currentObjective;
    int currentSpawnPoint;
    bool incrementOnce;
    // Start is called before the first frame update
    void Start()
    {
        rounds = 0;
        spawnObjective = true;
        currentObjective = -1; 
    }

    // Update is called once per frame
    void Update()
    {
        
        SpawnObjective();

        if(spawnObjective == false)
        {
            ObjectiveInGame();
        } 
    }

    //Handles the objectives when they are spawned and checks if they are completed
    //if so then it 
    void ObjectiveInGame()
    {
        if(spawnOneObjective == true)
        {
            //Spawns the game object into the world
            objective = Instantiate(objectivesToPick[currentObjective], objectiveSpawnPoints[currentSpawnPoint].position, Quaternion.identity);
            objective.SetActive(true);
            spawnOneObjective = false;
        }

        if (objective.name == "GatherAndHold" || objective.name == "GatherAndHold(Clone)")
        {
            if (objective.GetComponent<GatherAndHold>().GetObjectiveComplete() == true)
            {
                rounds++;
                objective.SetActive(false);
                Destroy(objective);
                objective = null;
                spawnObjective = true;
                SpawnDrops();
                CheckRounds();
                CompletedObjectiveSound();
            }
        }
        else if(objective.name == "PayLoad" || objective.name == "PayLoad(Clone)")
        {
            if (objective.GetComponent<PayLoad>().GetObjectiveComplete() == true)
            {
                rounds++;
                objective.SetActive(false);
                Destroy(objective);
                objective = null;
                spawnObjective = true;
                SpawnDrops();
                CheckRounds();
                CompletedObjectiveSound();
            }
        }
        else if(objective.name == "StrongPoint" || objective.name == "StrongPoint(Clone)")
        {
            if (objective.GetComponent<StrongPoint>().GetObjectiveComplete() == true)
            {
                rounds++;
                objective.SetActive(false);
                Destroy(objective);
                objective = null;
                spawnObjective = true;
                SpawnDrops();
                CheckRounds();
                CompletedObjectiveSound();
            }
        }
        else if (objective.name == "DestroyTheTurret" || objective.name == "DestroyTheTurret(Clone)")
        {
            if (objective.GetComponent<DestroyTheTurret>().GetObjectiveComplete() == true)
            {
                rounds++;
                objective.SetActive(false);
                Destroy(objective);
                objective = null;
                spawnObjective = true;
                SpawnDrops();
                CheckRounds();
                CompletedObjectiveSound();
            }
        }
        else if (objective.name == "CaptureTheTarget" || objective.name == "CaptureTheTarget(Clone)")
        {
            if (objective.GetComponent<CaptureTheTarget>().GetObjectiveComplete() == true)
            {
                rounds++;
                objective.SetActive(false);
                Destroy(objective);
                objective = null;
                spawnObjective = true;
                SpawnDrops();
                CheckRounds();
                CompletedObjectiveSound();
            }
        }
    }

    void CheckRounds()
    {
        if (rounds % 2 == 0 && incrementOnce == false)
        {
            hordeSurvivalObj.GetComponent<HordeSurvival>().IncreaseZombiesPerHorde(2);
            
        }

    }

    void CompletedObjectiveSound()
    {
        audioSrc.clip = completedObjectiveSfx;
        audioSrc.Play();
    }

    void SpawnDrops()
    {
        var canItDrop = Random.Range(0, 3);

        
        if (canItDrop == 0)
        {
            //spawn drop
            var randomDrop = Random.Range(0, drops.Length);
            var randSpawnpoint = Random.Range(0, dropsSpawnPoints.Length);
            var dropInGame = Instantiate(drops[randomDrop], dropsSpawnPoints[randSpawnpoint].position, Quaternion.identity);
        }
    }


    //randomly Spawns a random objective for the player
    void SpawnObjective()
    {
        if (spawnObjective == true)
        {
            var randNum = Random.Range(0, objectivesToPick.Length);
            var randSpawnpoint = Random.Range(0, objectiveSpawnPoints.Length);


            if(randNum != currentObjective)
            {
                currentObjective = randNum;
                currentSpawnPoint = randSpawnpoint;
                spawnObjective = false;
                spawnOneObjective = true;
            }
            else
            {
                SpawnObjective();
            }
        }
    }

    public int GetRounds()
    {
        return rounds;
    }

    public string GetObjectiveName() {
        if(objective.name == "PayLoad(Clone)")
        {
            return "PayLoad";
        }
        else if(objective.name == "GatherAndHold(Clone)")
        {
            return "GatherAndHold";
        }
        else if (objective.name == "StrongPoint(Clone)")
        {
            return "StrongPoint";
        }
        else if (objective.name == "DestroyTheTurret(Clone)")
        {
            return "DestroyTheTurret";
        }
        else if (objective.name == "CaptureTheTarget(Clone)")
        {
            return "CaptureTheTarget";
        }
        else
        {
            return objective.name;
        }
        
    }
}

