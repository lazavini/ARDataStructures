using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.SamplesResources.SceneAssets.GroundPlane.Scripts
{
    public class ElementoManager : MonoBehaviour
    {
        public TipoEstrutura TipoEstrutura;
        private IEnumerable<Elemento> _elementos;

        private void Start()
        {
            switch (TipoEstrutura)
            {
                case TipoEstrutura.Fila:
                    _elementos = new Queue<Elemento>();
                    break;
                case TipoEstrutura.Pilha:
                    _elementos = new Stack<Elemento>();
                    break;
                case TipoEstrutura.Lista:
                    _elementos = new List<Elemento>();
                    break;
            }
        }

        public void AdicionarElemento()
        {
            var elemento = gameObject.AddComponent<Elemento>();
            elemento.Renderizar(_elementos.LastOrDefault()?.transform);
            switch (TipoEstrutura)
            {
                case TipoEstrutura.Fila:
                    ((Queue<Elemento>)_elementos).Enqueue(elemento);
                    break;
                case TipoEstrutura.Pilha:
                    ((Stack<Elemento>)_elementos).Push(elemento);
                    break;
                case TipoEstrutura.Lista:
                    ((List<Elemento>)_elementos).Add(elemento);
                    break;
            }
        }
    }
}
