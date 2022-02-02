using Assets.SamplesResources.SceneAssets.GroundPlane.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Resources.SceneAssets.GroundPlane.Scripts
{
    public class ElementoPilha : Elemento
    {
        public override void CalculateTransform()
        {
            _cube.transform.localPosition = new Vector3(0f, 0f, 0f);
            _cube.transform.localScale = new Vector3(0.07f, 0.07f, 0.07f);
            _cube.transform.localRotation = Quaternion.identity;
            _cube.transform.localPosition = new Vector3(0, (((ElementoPilha)_parentElemento)?._cube?.transform?.localPosition.y ?? 0) + 0.1f, 0);
            _line.transform.localPosition = new Vector3(0f, 0f, 0f);
            _line.transform.localScale = new Vector3(0.04f, 0.04f, 0.04f);
            _line.transform.localRotation = Quaternion.identity;
            _line.transform.localPosition = new Vector3(0, (((ElementoPilha)_parentElemento)?._cube?.transform?.localPosition.y ?? 0) + 0.03f, 0);
        }

        public override void ConfigureMaterials()
        {
            var lineRender = _line.GetComponent<Renderer>();
            lineRender.material.SetColor("_Color", Color.red);
        }
    }
}
