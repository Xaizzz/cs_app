using Blazor.Data.Models;

namespace Blazor.Services
{
    public interface ICustomerProvider //интерфейс, описывающий получение данных по клиентам
    {
        Task<List<Customer>> GetAll();
        Task<Customer> GetOne(int id);
        Task<bool> Add(Customer item);
        Task<Customer> Edit(Customer item);
        Task<bool> Remove(int id);
    }
}
