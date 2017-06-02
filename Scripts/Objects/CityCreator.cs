using UnityEngine;

namespace CVRunner
{
    public class CityCreator : BaseObjectScene
    {
        //Road prebaf
        [SerializeField] GameObject road;
        //Position where creating gameObject
        [SerializeField] private Vector3 creatingPos;

        //Deviation of road position
        private float deviation = -32f;

        //Life time o road element
        private float lifeTime = 8f;

        private GameObject tmpGameObj;

        private void Start()
        {
            creatingPos = new Vector3(-8.5f, 0f, -16f);
            Create();
        }


        private void Update()
        {
            if (!Main.Instance.GetPause.IsPaused)
            {
                Create();
            }
        }

        private void Create()
        {
            if (!tmpGameObj)
            {
                tmpGameObj = Instantiate(road, creatingPos, Quaternion.identity);
                tmpGameObj.AddComponent<CityMover>();
            }
            else if (tmpGameObj.transform.position.z < deviation)
            {
                float z = tmpGameObj.transform.position.z + 119f; 
                creatingPos = new Vector3(-8.5f, 0f, z);
                tmpGameObj = Instantiate(road, creatingPos, Quaternion.identity);
                tmpGameObj.AddComponent<CityMover>();
            }
        }
    }
}