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
            base.CalculateTransform();
            Cube.transform.localPosition = new Vector3(0f, 0f, 0f);
            Cube.transform.localRotation = Quaternion.identity;
            Cube.transform.localPosition = new Vector3((((ElementoFila)_parentElemento)?.Cube?.transform?.localPosition.x ?? 0) + 0.08f, 0, 0);
        }
    }
}
