using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.SamplesResources.SceneAssets.GroundPlane.Scripts
{
    public class Elemento : MonoBehaviour
    {
        private GameObject _cube;
        public Elemento()
        {
        }

        public void Renderizar(Transform parentTransform)
        {
            _cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _cube.transform.localScale = new Vector3(0.07f, 0.07f, 0.07f);
            _cube.transform.parent = gameObject.transform;
            _cube.transform.localPosition = new Vector3(0, (parentTransform?.localPosition.y ?? 0)  + 0.05f, 0);
        }

        private void Start()
        {
            
        }
    }
}
