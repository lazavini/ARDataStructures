using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Resources.SceneAssets.GroundPlane.Scripts
{
    public interface IElemento
    {
        void CalculateTransform();
        void ConfigureMaterials();
    }
}
