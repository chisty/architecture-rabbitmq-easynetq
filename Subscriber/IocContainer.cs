using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber
{
    public class IocContainer
    {
        public static IocContainer Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (LockObject)
                    {
                        if (_instance == null) _instance = new IocContainer();
                    }
                }

                return _instance;
            }
        }

        

        public T Resolve<T>()
        {
            Create();
            lock (LockObject)
            {                
                return Container.GetExportedValue<T>();
            }
        }


        public IEnumerable<T> ResolveAll<T>()
        {
            Create();
            lock (LockObject)
            {
                return Container.GetExportedValues<T>();
            }
        }

        public T Resolve<T>(string name)
        {
            Create();
            lock (LockObject)
            {
                return Container.GetExportedValue<T>(name);
            }
        }

        public void AddAssembly<T>()
        {
            AddAssembly(typeof(T).Assembly);
        }

        public void AddAssembly(Assembly assembly)
        {
            if (Assemblies.Contains(assembly.FullName) == false)
            {
                Catalog.Catalogs.Add(new AssemblyCatalog(assembly));
                Assemblies.Add(assembly.FullName);
            }
        }


        private void Create()
        {
            if (Container == null)
            {
                lock (LockObject)
                {
                    if(Container == null)   Container= new CompositionContainer(Catalog);
                }
            }
        }

        private IocContainer()
        {
            Catalog = new AggregateCatalog();
            Assemblies= new List<string>();
            AddAssembly(Assembly.GetExecutingAssembly());
        }

        private static IocContainer _instance;
        private static readonly object LockObject= new object();
        private AggregateCatalog Catalog { get; set; }
        private CompositionContainer Container { get; set; }
        private List<string> Assemblies { get; set; }
    }
}
