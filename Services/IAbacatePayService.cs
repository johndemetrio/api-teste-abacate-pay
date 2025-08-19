using teste_abacate_pay.Models;

namespace teste_abacate_pay.Services
{
    public interface IAbacatePayService
    {
        Task<ResponseApi> CreatePixQrCode(RequestApi requestApi);
        Task<ResponseApi> SimulatePayment(string id);
        Task<ResponseApi> CheckStatus(string id);
    }
}
