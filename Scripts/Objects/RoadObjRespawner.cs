using UnityEngine;

namespace CVRunner
{

    public class RoadObjRespawner : BaseObjectScene
    {
        //Prefabs of created game objects
        [SerializeField] private GameObject[] prefabObj;

        //All respawn poins on the road
        private Transform[] RespawnPoints;

        //Count of childs
        private int chCount;
        //Time of object life
        [SerializeField] float lifeTime = 8f;

        //Counter for timer
        private float timeCounter = 0f;
        //Float for timer reset
        private float reset = 0f;

        void Start()
        {
            //Get count of child objects, and create array
            chCount = transform.childCount;
            RespawnPoints = new Transform[chCount];
            //Fill array
            int i = 0; // counter
            foreach (Transform T in transform)
            {
                RespawnPoints[i] = T;
                i++;
            }
        }

        // Update is called once per frame
        void Update()
        {
            timeCounter += Time.deltaTime;

            if (timeCounter > 2)
            {
                Respawn();
                timeCounter = reset;
            }
        }

        //Create new random prefab in random point and set lifeTime
        private void Respawn()
        {
            int objID = Random.Range(0, prefabObj.Length);
            int posID = Random.Range(0, chCount);

            float x = RespawnPoints[posID].transform.position.x;
            float y = RespawnPoints[posID].transform.position.y;
            float z = RespawnPoints[posID].transform.position.z;

            GameObject tmpObj;
            tmpObj = Instantiate(prefabObj[objID], new Vector3(x,y,z), Quaternion.identity);
            tmpObj.AddComponent<CityMover>();
            Destroy(tmpObj, lifeTime);
        }
    }
}
