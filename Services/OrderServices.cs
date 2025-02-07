
using Microsoft.EntityFrameworkCore;
using services_order_delete.Database;
using services_order_delete.Models;
using NewtonsoftJson = Newtonsoft.Json.JsonConvert;

namespace services_order_delete.Services
{
    public class OrderServices
    {
        private readonly DBContext _context;
        private readonly HttpClient _httpClient;

        public OrderServices(DBContext context, HttpClient httpClient)
        {
            _context = context;
            _httpClient = httpClient;
        }

        public async Task<Orders> DeleteOrderAsync(string codice)
        {
            var result = await _context.Orders.FirstOrDefaultAsync(x => x.OrderCode == codice);

            if (result == null)
            {
                return null;
            }

            result.Status = false;
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<bool> CheckIfOrderExistsAsync(string codice)
        {
            var exist = await _context.Orders.FirstOrDefaultAsync(x => x.OrderCode == codice);
            if (exist == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
