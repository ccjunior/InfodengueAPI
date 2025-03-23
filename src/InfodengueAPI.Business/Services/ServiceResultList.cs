namespace InfodengueAPI.Business.Services
{
    public class ServiceResultList<T>
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public IEnumerable<T> Data { get; private set; }

        private ServiceResultList(bool success, string message, IEnumerable<T> data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public static ServiceResultList<T> SuccessResult(IEnumerable<T> data, string message = "Operação realizada com sucesso.")
        {
            return new ServiceResultList<T>(true, message, data);
        }

        public static ServiceResultList<T> ErrorResult(string message)
        {
            return new ServiceResultList<T>(false, message, default);
        }
    }
}
