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
        public string Data;
        protected Elemento _parentElemento;
        protected TipoEstrutura _tipoEstrutura;
        protected Animation _animationCube;
        protected Animation _animationLine;
        private Animator Animator => GetComponent<Animator>();
        private bool _scaled;
        protected object _data;

        public void Renderizar(Elemento parentElemento, TipoEstrutura tipoEstrutura, object data)
        {
            _parentElemento = parentElemento;
            _tipoEstrutura = tipoEstrutura;
            _data = data;
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
            this.Animator.Play("RemoverElemento");
            this.transform.SetParent(null);
            gameObject.SetActive(false);
            GameObject.Destroy(this);
            //Destroy(Cube);
            //Destroy(Line);
        }

        public virtual void CalculateTransform()
        {
            
        }

        public virtual void ConfigureMaterials()
        {
            Canvas canvasObj = Cube.AddComponent<Canvas>();
            canvasObj.renderMode = RenderMode.WorldSpace;
            var texts = Cube.GetComponentsInChildren<TextMesh>();
            foreach (var text in texts)
                text.text = _data.ToString();
        }


        public void Animar()
        {
            _animationCube.Play();
            _animationLine.Play();
            
        }
    }
}
