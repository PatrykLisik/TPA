using Logic.Mappers;
using Logic.ReflectionMetadata;
using Serialization;
using SerializationModel.DTO;
using System;

namespace Repository
{
    public class XML_Repository : IRepositoryActions
    {
        static readonly Lazy<XMLSerializer<Assembly_DTO>> XMLSerializer = new Lazy<XMLSerializer<SerializationModel.DTO.Assembly_DTO>>();

        public AssemblyMetadata LoadFromRepository(string fileName)
        {
            return XMLSerializer.Value.LoadFromRepository(fileName).MapToObject();
        }

        public void SaveToRepository(AssemblyMetadata data, string fileName)
        {
            XMLSerializer.Value.SaveToRepository(data.ToXML_DTO(), fileName);
        }
    }
}
