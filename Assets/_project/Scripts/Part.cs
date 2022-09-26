using UnityEngine;

public class Part : MonoBehaviour
{
    [SerializeField] private bool _isFirst;
    [SerializeField] private Transform SpawnPoints;
    [SerializeField] private GameObject[] Lets;
    [SerializeField] private GameObject Tablet;

    private void Start()
    {
        int sumPoints = SpawnPoints.childCount;
        Transform[] points = new Transform[sumPoints];

        for (int i = 0; i < sumPoints; i++)
        {
            points[i] = SpawnPoints.GetChild(i);
        }

        if (_isFirst)
        {
            foreach (Transform point in points)
            {
                GameObject tablet = Instantiate(Tablet);
                tablet.transform.position = point.position;

                SetCount(tablet.GetComponent<UsableObject>());
            }
        }
        else
        {
            System.Random rand = new();
            foreach (Transform point in points)
            {
                GameObject obj;

                int random = rand.Next(0, 10);
                if (random > 6)
                    obj = Instantiate(Tablet);
                else
                    obj = Instantiate(Lets[rand.Next(0, Lets.Length)]);

                obj.transform.position = point.transform.position;
                obj.transform.parent = transform;

                SetCount(obj.GetComponent<UsableObject>());
                
            }
        }
    }
    private void SetCount(UsableObject usable)
    {
        System.Random rand = new();
        usable.SetCount(rand.Next(1, 4));
    }
}
