using Assets.SamplesResources.SceneAssets.GroundPlane.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Resources.SceneAssets.GroundPlane.Scripts
{
    public class ElementoFila : Elemento
    {
        public override void CalculateTransform()
        {
            Cube.transform.localPosition = new Vector3(0f, 0f, 0f);
            Cube.transform.localScale = new Vector3(0.09f, 0.09f, 0.09f);
            Cube.transform.localRotation = Quaternion.identity;
            Cube.transform.localPosition = new Vector3((((ElementoFila)_parentElemento)?.Cube?.transform?.localPosition.x ?? 0) + 0.1f, 0, 0);
            Line.transform.localPosition = new Vector3(0f, 0f, 0f);
            Line.transform.localScale = new Vector3(0.04f, 0.06f, 0.06f);
            Line.transform.localRotation = Quaternion.identity;
            Line.transform.localPosition = new Vector3((((ElementoFila)_parentElemento)?.Cube?.transform?.localPosition.x ?? 0) + 0.05f, 0, 0);
        }

        public override void ConfigureMaterials()
        {
            base.ConfigureMaterials();
        }
    }
}
