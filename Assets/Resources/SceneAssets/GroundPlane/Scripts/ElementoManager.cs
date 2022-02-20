using Assets.Resources.SceneAssets.GroundPlane.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.SamplesResources.SceneAssets.GroundPlane.Scripts
{
    public class ElementoManager : MonoBehaviour
    {
        [SerializeField] public TipoEstrutura TipoEstrutura;
        [SerializeField] public IEnumerable<Elemento> _elementos;
        public InputField ElementoInput;
        private Canvas _canvas => gameObject.GetComponentInChildren<Canvas>(true);

        public GameObject ElementoBase =>
            TipoEstrutura == TipoEstrutura.Fila ? gameObject.GetComponentInChildren<ElementoFila>(true).gameObject
            : TipoEstrutura == TipoEstrutura.Lista ? gameObject.GetComponentInChildren<ElementoLista>(true).gameObject 
            : gameObject.GetComponentInChildren<ElementoPilha>(true).gameObject;

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

        public void ExibirInputElemento()
        {
            ElementoInput.text = string.Empty;
            _canvas.gameObject.SetActive(true);
        }

        public void AdicionarElemento()
        {
            _canvas.gameObject.SetActive(false);
            var ultimoElemento = _elementos?.LastOrDefault();
            var cloneObject = Instantiate(ElementoBase, gameObject.transform, true);
            cloneObject.SetActive(true);
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
            elemento?.Renderizar(ultimoElemento, TipoEstrutura, ElementoInput.text);
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
            Destroy(elemento);
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
            {
                elemento.Destroy();
                Destroy(elemento);
            }

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
