
namespace Logic.ReflectionMetadata
{
    public class ParameterMetadata
    {
        public ParameterMetadata(string name, TypeMetadata typeMetadata)
        {
            m_Name = name;
            m_TypeMetadata = typeMetadata;
        }

        //private vars
        public string m_Name { get; private set; }
        public TypeMetadata m_TypeMetadata { get; private set; }

    }
}