using UnityEngine;

namespace CVRunner
{
    public class CityCreator : BaseObjectScene
    {
        //Road prebaf
        [SerializeField] private GameObject road;
        //Position where creating gameObject
        [SerializeField] private Vector3 creatingPos;
        //Life time of segment
        [SerializeField] private float lifeTime = 8f;
        //Step for next position of road segment creating
        private float step = 120f;
        //Speed deviation
        private float deviation = 0f;
        
        private GameObject tmpGameObj;

        private void Start()
        {
            creatingPos = new Vector3(-8.5f, 0f, -3f);
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
            //work once
            if (!tmpGameObj)
            {
                deviation = Main.Instance.GetData.Speed;
                tmpGameObj = Instantiate(road, creatingPos, Quaternion.identity);
                tmpGameObj.AddComponent<CityMover>();
                Destroy(tmpGameObj, lifeTime);
            }
            else if (tmpGameObj.transform.position.z < -3f)
            {
                deviation = Main.Instance.GetData.Speed;
                step -= deviation;
                creatingPos = new Vector3(-8.5f, 0f, tmpGameObj.transform.position.z + step);
                tmpGameObj = Instantiate(road, creatingPos, Quaternion.identity);
                tmpGameObj.AddComponent<CityMover>();
                Destroy(tmpGameObj, lifeTime);
            }
        }
    }
}