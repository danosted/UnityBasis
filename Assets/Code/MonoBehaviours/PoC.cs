namespace Assets.Code.MonoBehaviours
{
    using UnityEngine;

    public class PoC : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.down * Time.deltaTime);
        }
    }
}
