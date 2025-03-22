namespace InfodengueAPI.Services
{
    public interface IInfoDengueService
    {
        Task<string> GetDadosEpidemiologicosAsync(string codigoIBGE, int semanaInicio, int semanaFim, string arbovirose);
        Task<string> GetDadosMunicipioAsync(string codigoIBGE);
    }
}
