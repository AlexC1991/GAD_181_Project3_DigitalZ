using Unity.Collections;
using UnityEngine;
using Unity.Entities;
using Unity.Rendering;
using Unity.Transforms;

namespace AlexzanderCowell
{
    public class EntitieTestScript : MonoBehaviour
    {
        [SerializeField] private Mesh _mesh;
        [SerializeField] private Material _material;
        private void Start()
        {
            EntityManager _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
           
            EntityArchetype entityArchetype = 
                _entityManager.CreateArchetype(typeof(LevelComponent), 
                typeof(Translation),
                typeof(RenderMesh),
                typeof(LocalToWorld)
                );
            NativeArray<Entity> _entitieArray = new NativeArray<Entity>(1, Allocator.Temp);
            _entityManager.CreateEntity(entityArchetype, _entitieArray);
            
            for (int i = 0; i < _entitieArray.Length; i++)
            {
                Entity entity = _entitieArray[i];
                _entityManager.SetComponentData(entity, new LevelComponent{ level = Random.Range(0, 100)});

                _entityManager.SetSharedComponentData(entity, new RenderMesh
                {
                    mesh = _mesh,
                    material = _material
                });

            }

            _entitieArray.Dispose();
        }
        
    }
}
