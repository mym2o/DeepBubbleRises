using UnityEngine;

public class SpawnWall : MonoBehaviour
{
    public GameObject wallToSpawn;
    public float yOffset = 30f;

    private GameObject wallsList;

    private void Start()
    {
        wallsList = GameObject.FindGameObjectWithTag("WallsList");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Spawn a wall");

            Vector3 spawnPos = new Vector3(0, transform.position.y + yOffset, 0);
            GameObject newWall = GameObject.Instantiate(wallToSpawn, spawnPos, Quaternion.identity);
            newWall.transform.SetParent(wallsList.transform);

            if (wallsList.transform.childCount > 2)
            {
                GameObject.Destroy(wallsList.transform.GetChild(0).gameObject);
            }

            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
