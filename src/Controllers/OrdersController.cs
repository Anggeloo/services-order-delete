using Microsoft.AspNetCore.Mvc;
using services_order_delete.Models;
using services_order_delete.Services;


[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly OrderServices _orderService;

    private readonly HttpClient _httpClient;

    public OrdersController(OrderServices orderService, HttpClient httpClient)
    {
        _orderService = orderService;
        _httpClient = httpClient;
    }

    [HttpDelete("delete/{codice}")]
    public async Task<IActionResult> DeñeteOrder(string codice)
    {
        var exitsOrder = await _orderService.CheckIfOrderExistsAsync(codice);

        if (exitsOrder == false)
        {
            return BadRequest(new ApiResponse<string>("Error", null, "The order code does not exist"));
        }

        var delete = await _orderService.DeleteOrderAsync(codice);

        if (delete == null)
        {
            return StatusCode(400, new ApiResponse<string>("Error", null, "Error ..."));
        }

        return Ok(new ApiResponse<Orders>("success", delete , "Order deleted successfully"));
    }
}
