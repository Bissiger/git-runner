using UnityEngine;

namespace CVRunner
{
    public class SityCreator : BaseObjectScene
    {
        //Road prebaf
        [SerializeField] GameObject road;
        //Position where creating gameObject
        [SerializeField] private Vector3 creatingPos;

        private GameObject tmpGameObj;

        private void Start()
        {
            creatingPos = new Vector3(-8.5f, 0f, -3f);
            Create();
            creatingPos = new Vector3(-8.5f, 0f, 37f);
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
                gameObject.AddComponent<SityMover>();
                //add destroyer
            }
        }
    }
}