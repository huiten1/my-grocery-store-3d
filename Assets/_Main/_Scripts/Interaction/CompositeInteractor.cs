using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Main._Scripts.Interaction
{
    public class CompositeInteractor : MonoBehaviour, IInteractable
    {
        [SerializeField] private GameObject[] interactableObjects;
        private IInteractable[] interactables;

        private void Start()
        {
            interactables = interactableObjects.Select(e => e.GetComponent<IInteractable>()).ToArray();
        }

        private void OnValidate()
        {
            for (int i = 0; i < interactableObjects.Length; i++)
            {
                if (interactableObjects[i].GetComponent<IInteractable>() == null)
                {
                    interactableObjects[i] = null;
                }
            }
        
        }

        public void Interact(GameObject interactor)
        {
            foreach (var interactable in interactables)
            {
                interactable.Interact(interactor);
            }
        }
    }
}