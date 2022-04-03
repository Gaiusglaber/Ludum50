using UnityEngine;

namespace Pathfinders.Toolbox.Singletons
{
    public class GenericSingleton<T> : MonoBehaviour where T : Component
    {
        #region EXPOSED_FIELDS
        [SerializeField] protected bool dontDestroy = true;
        #endregion

        #region PRIVATE_FIELDS
        private static T instance;
        #endregion

        #region PUBLIC_METHODS
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                    if (instance == null)
                    {
                        GameObject obj = new GameObject();
                        obj.name = typeof(T).Name;
                        instance = obj.AddComponent<T>();
                    }
                }
                return instance;
            }
        }
        #endregion

        #region PROTECTED_METHODS
        protected virtual void Awake()
        {
            Configure();
        }
        #endregion

        #region PRIVATE_METHODS
        private void Configure()
        {
            if (instance == null)
            {
                instance = this as T;

                if (dontDestroy)
                {
                    DontDestroyOnLoad(gameObject);
                }
            }
            else if (instance != this)
            {
                Destroy(gameObject);
                return;
            }
        }
        #endregion
    }
}

