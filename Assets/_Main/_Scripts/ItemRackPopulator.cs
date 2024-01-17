using System;
using UnityEngine;

namespace _Main._Scripts
{
    public class ItemRackPopulator : MonoBehaviour
    {
        public GameObject itemToPopulate;
        public GameObject[] itemsToPopulate;
        public bool shouldPopulate;
        [SerializeField] private LimitedItemHolder itemRack;
        [SerializeField] private float spawnPeriod;
        private float t;

        private void Start()
        {
            if (!shouldPopulate) return;
            for (int i = 0; i < itemRack.MaxItemCount; i++)
            {
                var item = Instantiate(itemToPopulate);
                item.name = itemToPopulate.name;
                itemRack.Add(item);
            }
        }

        private void Update()
        {
            if (!shouldPopulate) return;
            if (t <= 0)
            {
                t = spawnPeriod;
                if (!itemRack.IsFull)
                {
                    var item = Instantiate(itemToPopulate);
                    item.name = itemToPopulate.name;
                    itemRack.Add(item);
                }

                return;
            }

            t -= Time.deltaTime;
        }
    }
}