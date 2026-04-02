using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public Transform player;
    public Transform ground;

    public float spawnYOffset = 8f;
    public float minX = -2.5f;
    public float maxX = 2.5f;

    private float highestSpawnY;

    void Start()
	{
        //highestSpawnY = ground.position.y + 1.5f;	
        highestSpawnY = player.position.y;

        for(int i = 0; i <6 ; i++)
        {
            SpawnPlatform();
        }
	}

	void Update()
	{
        if(player.position.y + spawnYOffset > highestSpawnY)
        {
            SpawnPlatform();
        }
	}

    void SpawnPlatform()
    {
        highestSpawnY += Random.Range(1.5f, 2.5f);
        
        float randomX = Random.Range(minX, maxX);

        Instantiate(platformPrefab, new Vector3(randomX,highestSpawnY,0), Quaternion.identity);
    }
}
