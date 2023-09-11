using VillaAPI.Models.Dto;

namespace VillaAPI.Data
{
    public static class VillaStore
    {
        public static List<VillaDTO> villaList = new List<VillaDTO>()
            {
                new VillaDTO{Id=1, Name="Pool View", Occupancy=100, Sqft=4},
                new VillaDTO{Id=2, Name="Beach View", Occupancy = 200, Sqft =3 }
            };
    }
}
