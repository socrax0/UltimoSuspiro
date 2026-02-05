using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject[] enemies;

    void Update()
    {
        foreach(GameObject enemy in enemies)
        {
            //instanciação
        }
        
    }
}
