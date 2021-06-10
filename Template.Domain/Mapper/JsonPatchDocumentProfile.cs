using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;

namespace MicroservicioHotel.Domain.Mapper
{
    public class JsonPatchDocumentProfile : Profile
    {
        public JsonPatchDocumentProfile()
        {
            CreateMap(typeof(JsonPatchDocument<>), typeof(JsonPatchDocument<>));
            CreateMap(typeof(Operation<>), typeof(Operation<>));
        }
    }
}
