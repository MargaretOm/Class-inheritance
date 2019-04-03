using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using System.Reflection;

namespace WindowsFormsApp1
{
    public class ClassPlugin
    {
       
            public List<Class1> objects;

            private string[] dllFileNames;
            private List<Assembly> assemblies;
            private List<Type> pluginTypes;

            public ClassPlugin(string path)
            {
                GetFiles(path);

                GetAssemblies();

                GetPluginTypes();

                CreatePluginList();
            }

            private void GetFiles(string path)
            {
                if (Directory.Exists(path))
                {
                    dllFileNames = Directory.GetFiles(path, "*.dll");
                }
            }

            private void GetAssemblies()
            {
                assemblies = new List<Assembly>(dllFileNames.Length);

                foreach (string dllFile in dllFileNames)
                {
                    AssemblyName name = AssemblyName.GetAssemblyName(dllFile);
                    Assembly assembly = Assembly.Load(name);
                    assemblies.Add(assembly);
                }
            }

            private void GetPluginTypes()
            {
                Type pluginType = typeof(Class1);
                pluginTypes = new List<Type>();

                foreach (Assembly assembly in assemblies)
                {
                    if (assembly != null)
                    {
                        Type[] types = assembly.GetTypes();
                        foreach (Type type in types)
                        {
                            if (type.IsInterface || type.IsAbstract)
                            {
                                continue;
                            }
                            else
                            {
                                if (type.GetInterface(pluginType.FullName) != null)
                                {
                                    pluginTypes.Add(type);
                                }
                            }
                        }
                    }
                }
            }

            private void CreatePluginList()
            {
                objects = new List<Class1>(pluginTypes.Count);

                foreach (Type type in pluginTypes)
                {
                Class1 plugin = (Class1)Activator.CreateInstance(type);
                    objects.Add(plugin);
                }
            
            }
    }
}
