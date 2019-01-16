using Model.DTO;
using Serialization;
using Serialization.Mapper;
using SerializationModel.DTO;
using System;
using System.ComponentModel.Composition;

namespace Repository
{
    [Export(typeof(IRepositoryActions))]
    public class XML_Repository : IRepositoryActions
    {
        static readonly Lazy<XMLSerializer<Assembly_DTO>> XMLSerializer = new Lazy<XMLSerializer<Assembly_DTO>>();


        public void SaveToRepository(AssemblyBaseDTO data, string fileName)
        {
            XMLSerializer.Value.SaveToRepository(data.MapToSerializationModel(), fileName);
        }

        public AssemblyBaseDTO LoadFromRepository(string fileName)
        {
            //return XMLSerializer.Value.LoadFromRepository(fileName);
            return null;
        }
    }
}
