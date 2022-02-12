using Assets.SamplesResources.SceneAssets.GroundPlane.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Resources.SceneAssets.GroundPlane.Scripts
{
    public class ElementoLista : Elemento
    {
        public override void CalculateTransform()
        {
            Cube.transform.localPosition = new Vector3(0f, 0f, 0f);
            Cube.transform.localScale = new Vector3(0.07f, 0.07f, 0.07f);
            Cube.transform.localRotation = Quaternion.identity;
            Cube.transform.localPosition = new Vector3((((ElementoLista)_parentElemento)?.Cube?.transform?.localPosition.x ?? 0) + 0.1f, 0, 0);
            Line.transform.localPosition = new Vector3(0f, 0f, 0f);
            Line.transform.localScale = new Vector3(0.04f, 0.04f, 0.04f);
            Line.transform.localRotation = Quaternion.identity;
            Line.transform.localPosition = new Vector3((((ElementoLista)_parentElemento)?.Cube?.transform?.localPosition.x ?? 0) + 0.03f, 0, 0);

        }

        public override void ConfigureMaterials()
        {
            var lineRender = Line.GetComponent<Renderer>();
            lineRender.material.SetColor("_Color", Color.red);
        }
    }
}
