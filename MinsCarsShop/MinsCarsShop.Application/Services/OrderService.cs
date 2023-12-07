using Azure.Core;
using Microsoft.EntityFrameworkCore;
using MinsCarsShop.Application.Interfaces;
using MinsCarsShop.Data.EF;
using MinsCarsShop.Data.Models;
using MinsCarsShop.Dto.Cart;
using MinsCarsShop.Dto.Constants;
using MinsCarsShop.Dto.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinsCarsShop.Application.Services
{
    public class OrderService : IOrderService
    {
        private ToteDbContext _context;
        public OrderService(ToteDbContext context)
        {
            _context = context; 
        }
        public async Task<ApiResult<int>> OrderAsync()
        {
            //Tính total
            var productsInCarts = await _context.Carts
                .Where(c => c.UserId == 1 && c.IsDeleted == false)
                .Select(c => new ProductsInCartDTO()
            {
                ToteId = c.ToteId,
                Image = c.Tote.Image,
                Name = c.Tote.Name,
                Price = c.Tote.Price,
                Amount = c.Amount,
                Subtotal = c.Amount * c.Tote.Price,
            }).ToListAsync();

            if (productsInCarts.Count == 0)
            {
                return new ApiResult<int>(0)
                {
                    Message = "Something went wrong!",
                    StatusCode = 400
                };
            }

            var total = productsInCarts.Sum(c => c.Subtotal);

            //Create new Order
            var newOrder = new Order()
            {
                UserId = 1,
                OrderTime = DateTime.Now,
                DeliveryTime = DateTime.Now,
                StatusId = 1,
                Total = total,
            };
            await _context.AddAsync(newOrder);
            await _context.SaveChangesAsync();

            foreach (var item in productsInCarts) 
            {
                var newOrderDetail = new OrderDetail()
                {
                    OrderId = newOrder.Id,
                    ToteId = item.ToteId,
                    Amount = item.Amount,
                    OrderPrice = item.Price,
                };
                await _context.AddAsync(newOrderDetail);
            }

            //Delete product after add to order detail
            var itemCart = await _context.Carts
                .Where(c => c.UserId == 1 && c.IsDeleted == false)
                .ToListAsync();
            foreach (var item in itemCart)
            {
                item.IsDeleted = true;
            }
            await _context.SaveChangesAsync();

            return new ApiResult<int>(newOrder.Id)
            {
                Message = "Make an order successfully!",
                StatusCode = 200
            };
        }

    }
}
