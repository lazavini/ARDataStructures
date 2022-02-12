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

        public GameObject ElementoBase => GameObject.FindGameObjectsWithTag("ElementoBase")
                        .FirstOrDefault(x => x.name == "Elemento" + (TipoEstrutura == TipoEstrutura.Fila ? "Fila" : TipoEstrutura == TipoEstrutura.Pilha ? "Pilha" : "Lista"));

        private void Start()
        {
            switch (TipoEstrutura)
            {
                case TipoEstrutura.Fila:
                    _elementos = new Queue<ElementoFila>();
                    break;
                case TipoEstrutura.Pilha:
                    _elementos = new Stack<ElementoPilha>();
                    break;
                case TipoEstrutura.Lista:
                    _elementos = new List<ElementoLista>();
                    break;
            }
        }

        public void AdicionarElemento()
        {
            var ultimoElemento = _elementos?.LastOrDefault();
            var cloneObject = Instantiate(ElementoBase, gameObject.transform, true);
            var elemento = cloneObject.GetComponent<Elemento>();
            switch (TipoEstrutura)
            {
                case TipoEstrutura.Fila:
                    
                    ((Queue<ElementoFila>)_elementos).Enqueue((ElementoFila)elemento);
                    break;
                case TipoEstrutura.Pilha:
                    ultimoElemento = _elementos?.FirstOrDefault();
                    ((Stack<ElementoPilha>)_elementos).Push((ElementoPilha)elemento);
                    break;
                case TipoEstrutura.Lista:
                    ((List<ElementoLista>)_elementos).Add((ElementoLista)elemento);
                    break;
            }
            elemento?.Renderizar(ultimoElemento, TipoEstrutura, _elementos.Count());
        }

        public void RemoverElemento()
        {
            if (_elementos.Count() <= 1)
                return;

            Elemento elemento = null;
            switch (TipoEstrutura)
            {   
                case TipoEstrutura.Fila:
                    elemento = ((Queue<ElementoFila>)_elementos).Dequeue();
                    break;
                case TipoEstrutura.Pilha:
                    elemento = ((Stack<ElementoPilha>)_elementos).Pop();
                    break;
                case TipoEstrutura.Lista:
                    elemento = ((List<ElementoLista>)_elementos).LastOrDefault();
                    ((List<ElementoLista>)_elementos).Remove((ElementoLista)elemento);
                    break;
            }
            elemento?.Destroy();
        }

        public void AnimarElementos()
        {
            foreach(var elemento in _elementos)
            {
                elemento.Animar();
            }
        }

        public void DefinirEstrutura(string tipoEstrutura)
        {
            foreach (var elemento in _elementos)
                elemento.Destroy();

            switch (tipoEstrutura)
            {
                case "Fila":
                    TipoEstrutura = TipoEstrutura.Fila;
                    break;
                case "Pilha":
                    TipoEstrutura = TipoEstrutura.Pilha;
                    break;
                case "Lista":
                    TipoEstrutura = TipoEstrutura.Lista;
                    break;
            }
            Start();
        }
    }
}
