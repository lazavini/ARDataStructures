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
        public GameObject Cube;
        public GameObject Line;
        protected Elemento _parentElemento;
        protected TipoEstrutura _tipoEstrutura;
        protected Animation _animationCube;
        protected Animation _animationLine;
        private bool _scaled;

        public void Renderizar(Elemento parentElemento, TipoEstrutura tipoEstrutura)
        {
            _parentElemento = parentElemento;
            _tipoEstrutura = tipoEstrutura;
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
            Destroy(Cube);
            Destroy(Line);
        }

        public virtual void CalculateTransform()
        {
        }

        public virtual void ConfigureMaterials()
        {
        }


        public void Animar()
        {
            _animationCube.Play();
            _animationLine.Play();
            //if (!_scaled)
            //{
            //    _cube.transform.localScale = new Vector3(_cube.transform.localScale.x + 0.05f, _cube.transform.localScale.y + 0.05f, _cube.transform.localScale.z + 0.05f);
            //    _line.transform.localScale = new Vector3(_line.transform.localScale.x + 0.05f, _line.transform.localScale.y + 0.05f, _line.transform.localScale.z + 0.05f);
            //    _scaled = true;
            //}
            //else
            //{
            //    _cube.transform.localScale = new Vector3(_cube.transform.localScale.x - 0.05f, _cube.transform.localScale.y - 0.05f, _cube.transform.localScale.z - 0.05f);
            //    _line.transform.localScale = new Vector3(_line.transform.localScale.x - 0.05f, _line.transform.localScale.y - 0.05f, _line.transform.localScale.z - 0.05f);
            //    _scaled = false;
            //}
        }

        public void Animar2()
        {
        }

        public virtual void ConfigureMaterials()
        {
        }
    }
}
