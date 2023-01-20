using ETicketMvc.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ETicketMvc.Data.Services
{
    public interface IOrderService
    {

        Task StoreOrderAsync(List<ShoppingCartItem> item, string userId, string userEmailAddress);

        Task<List<Order>> GetOrderByUserIdAsync(string userId);


    }
}
