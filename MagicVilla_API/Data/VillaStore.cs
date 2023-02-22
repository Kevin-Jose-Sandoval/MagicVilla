using MagicVilla_API.Models.Dto;

namespace MagicVilla_API.Data
{
    public static class VillaStore
    {
        public static List<VillaDto> villaList = new List<VillaDto>
        {
            new VillaDto { Id = 1, Name = "Vista a la piscina", Capacity = 3, SquareMeter = 50},
            new VillaDto { Id = 2, Name = "Vista a la playa", Capacity = 4, SquareMeter = 80},
        };
    }
}
