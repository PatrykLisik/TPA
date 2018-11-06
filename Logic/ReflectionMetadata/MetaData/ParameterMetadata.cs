
namespace Logic.ReflectionMetadata
{
    public class ParameterMetadata
    {
        public string m_Name { get; private set; }
        public TypeMetadata m_TypeMetadata { get; private set; }

        public ParameterMetadata(string name, TypeMetadata typeMetadata)
        {
            this.m_Name = name;
            this.m_TypeMetadata = typeMetadata;
        }
    }
}