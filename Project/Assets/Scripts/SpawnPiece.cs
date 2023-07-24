using UnityEngine;

public class SpawnPiece : MonoBehaviour
{
    [SerializeField] private GameObject[] tetriminosList;
    // Start is called before the first frame update
    void Start()
    {
        SpawnRandomTetramino();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnRandomTetramino()
    {
        Instantiate(tetriminosList[Random.Range(0, tetriminosList.Length)], transform.position, transform.rotation);
    }
}
