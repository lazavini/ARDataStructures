using Assets.Resources.SceneAssets.GroundPlane.Scripts;
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
        [SerializeField] public TipoEstrutura TipoEstrutura;
        [SerializeField] public IEnumerable<Elemento> _elementos;

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
            var ultimoElemento = _elementos?.LastOrDefault();
            Elemento elemento = null;
            switch (TipoEstrutura)
            {
                case TipoEstrutura.Fila:
                    elemento = gameObject.AddComponent<ElementoFila>();
                    ((Queue<Elemento>)_elementos).Enqueue(elemento);
                    break;
                case TipoEstrutura.Pilha:
                    ultimoElemento = _elementos?.FirstOrDefault();
                    elemento = gameObject.AddComponent<ElementoPilha>();
                    ((Stack<Elemento>)_elementos).Push(elemento);
                    break;
                case TipoEstrutura.Lista:
                    elemento = gameObject.AddComponent<ElementoLista>();
                    ((List<Elemento>)_elementos).Add(elemento);
                    break;
            }
            elemento?.Renderizar(ultimoElemento, TipoEstrutura);
        }

        public void RemoverElemento()
        {
            Elemento elemento = null;
            switch (TipoEstrutura)
            {
                case TipoEstrutura.Fila:
                    elemento = ((Queue<Elemento>)_elementos).Dequeue();
                    break;
                case TipoEstrutura.Pilha:
                    elemento = ((Stack<Elemento>)_elementos).Pop();
                    break;
                case TipoEstrutura.Lista:
                    elemento = ((List<Elemento>)_elementos).LastOrDefault();
                    ((List<Elemento>)_elementos).Remove(elemento);
                    break;
            }
            elemento?.Destroy();
        }
    }
}
