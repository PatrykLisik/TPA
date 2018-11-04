using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Reader 
    {
        //vars
        /*     to do:   
        private string m_typeName;
        private string m_NamespaceName;
        private TypeMetadata m_BaseType;
        private Tuple<AccessLevel, SealedEnum, AbstractENum> m_Modifiers;
        private TypeKind m_TypeKind;
        private TypeMetadata m_DeclaringType;
        */
        private IEnumerable<PropertyInfo> m_Properties;
        private IEnumerable<MethodInfo> m_Methods;
        private IEnumerable<ConstructorInfo> m_Constructors;
        private IEnumerable<Type> m_GenericArguments;
        private IEnumerable<Attribute> m_Attributes;
        private IEnumerable<FieldInfo> m_Fields;
        private IEnumerable<Type> m_ImplementedInterfaces;
        private IEnumerable<Type> m_NestedTypes;

        public void read()
        {
            Console.WriteLine();
            string path = @"C:\Users\Bartosz\Dysk Google\Studia\Technologie Programowania Adaptacyjnego\TPA\Mock\TP.Introduction.dll";
            Assembly assembly = Assembly.LoadFile(path);
            Console.WriteLine(assembly.FullName);

            Type[] typ = assembly.GetTypes();
            foreach (Type t in typ)
            {                
                m_Properties = t.GetProperties();
                m_Methods = t.GetMethods();
                m_Constructors = t.GetConstructors();
                m_GenericArguments = t.GetGenericArguments();
                m_Attributes = t.GetCustomAttributes();
                m_Fields = t.GetFields();
                m_ImplementedInterfaces = t.GetInterfaces();
                m_NestedTypes = t.GetNestedTypes();
 
                Console.WriteLine("Type:); " + t.Name + " Base type: " + t.BaseType);
                foreach (var v in m_Constructors) { Console.WriteLine("\tConstructors: " + v.Name + ", " +v.Attributes); }
                foreach (var p in m_Properties) { Console.WriteLine("\tProperty: " + p.Name + ", Property type: " + p.PropertyType); }
                foreach (var f in m_Fields){Console.WriteLine("\tFields: " + f.Name + ", Field type: " + f.FieldType);}
                foreach (var m in m_Methods) { Console.WriteLine("\tMethods: " + m.Name + ", Return type: " + m.ReturnType); }
                foreach (var g in m_GenericArguments) { Console.WriteLine("\tGeneric: " + g.Name); }
                foreach (var i in m_ImplementedInterfaces) { Console.WriteLine("\tImplementedInterfaces: " + i.Name + ", " + i.Attributes); }
                foreach (var n in m_NestedTypes) { Console.WriteLine("\tNestedTypes: " + n.Name); }
            }


        }
    }
}
