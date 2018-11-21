namespace Logic.ReflectionMetadata
{
    public class ParameterMetadata
    {
        private string m_Name;
        private TypeMetadata m_TypeMetadata;

        public ParameterMetadata(string name, TypeMetadata typeMetadata)
        {
            Name = name;
            TypeMetadata = typeMetadata;
        }

        public string Name { get => m_Name; set => m_Name = value; }
        public TypeMetadata TypeMetadata { get => m_TypeMetadata; set => m_TypeMetadata = value; }
    }
}