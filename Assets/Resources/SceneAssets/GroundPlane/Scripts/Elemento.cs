using Assets.Resources.SceneAssets.GroundPlane.Scripts;
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
        protected GameObject _cube;
        protected GameObject _line;
        protected Elemento _parentElemento;
        protected TipoEstrutura _tipoEstrutura;
        public Elemento()
        {
        }
        public void Renderizar(Elemento parentElemento, TipoEstrutura tipoEstrutura)
        {
            _parentElemento = parentElemento;
            _tipoEstrutura = tipoEstrutura;
            _cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _cube.transform.parent = gameObject.transform;
            _cube.gameObject.SetActive(true);
            _line = GameObject.CreatePrimitive(PrimitiveType.Cube);
            _line.transform.parent = gameObject.transform;
            _line.gameObject.SetActive(true);

            CalculateTransform();
            ConfigureMaterials();

            //var boxCollider = _cube.gameObject.AddComponent<BoxCollider>();
            //boxCollider.center = _cube.transform.localPosition;
            //boxCollider.size = new Vector3(0.07f, 0.07f, 0.07f);
            //boxCollider.isTrigger = true;
            //Transform myModelTrf = GameObject.Instantiate(myModelPrefab) as Transform;
            //myModelTrf.parent = mTrackableBehaviour.transform;
            //myModelTrf.localPosition = new Vector3(0f, 0f, 0f);
            //myModelTrf.localRotation = Quaternion.identity;
            //myModelTrf.localScale = new Vector3(0.0005f, 0.0005f, 0.0005f);
            //myModelTrf.gameObject.active = true;
        }
        private void Start()
        {
            
        }

        internal void Destroy()
        {
            Destroy(_cube);
            Destroy(_line);
        }

        public virtual void CalculateTransform()
        {
        }

        public virtual void ConfigureMaterials()
        {
        }
    }
}
