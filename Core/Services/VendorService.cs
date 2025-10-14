using ChimeWebApi.Core.Enums;
using ChimeWebApi.Core.Objects;
using ChimeWebApi.Database;
using ChimeWebApi.Entities;
using ChimeWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ChimeWebApi.Core.Services
{
	public class VendorService(ProductDatabase ProductDb)
	{
		public async Task<Response<List<Guid>>> ConfirmPurchase(PurchaseDto dto)
		{
			List<Guid> responses = [];
			foreach (var e in dto.CartItemIds)
			{
				responses.Add((await ConfirmPurchase(e, dto.UserId)).Data);
			}
			return new()
			{
				Code = ResponseCode.Success,
				Message = "Transaction completed",
				Source = nameof(VendorService),
				Data = responses,
			};
		}

		public async Task<Response<Guid>> ConfirmPurchase(Guid cartItemId, Guid userId)
		{
			CartItem? cartItem = await ProductDb.CartItems.FindAsync(cartItemId);

			if (cartItem == null) return new()
			{
				Code = ResponseCode.Failed,
				Message = "Item purchase failed",
				Source = nameof(VendorService),
			};

			var newTransaction = await ProductDb.Transactions.AddAsync(new() {
				Status = TransactionStatus.Pending,
				Id = Guid.NewGuid(),
				CreatedDate = DateTime.UtcNow,
				ResolvedDate = DateTime.MinValue,
				CartItem = cartItem,
				CartItemId = cartItemId
			});

			bool invalidPurchase = false;
			var result = await CartItemConfirmPurchase(cartItem);
			if (result.Code == ResponseCode.Failed) invalidPurchase = true;

			if (invalidPurchase) newTransaction.Entity.Status = TransactionStatus.Failed;
			else newTransaction.Entity.Status = TransactionStatus.Success;
			newTransaction.Entity.ResolvedDate = DateTime.UtcNow;

			await ProductDb.SaveChangesAsync();

			return new()
			{
				Code = ResponseCode.Success,
				Message = "Purchase successful",
				Source = string.Empty,
				Data = newTransaction.Entity.Id
			};
		}

		protected async Task<Response> CartItemConfirmPurchase(CartItem cartItem)
		{
			Product? product = await ProductDb.Products.FindAsync(cartItem.ProductId);
			if (product == null) return new()
			{
				Code = ResponseCode.Failed,
				Message = "Product does not exist",
				Source = nameof(VendorService)
			};
			ProductVariant? variant = await ProductDb.Variants.FindAsync(cartItem.VariantId);
			if (variant == null) return new()
			{
				Code = ResponseCode.Failed,
				Message = "Product variant does not exist",
				Source = nameof(VendorService)
			};
			if (variant.Stock <= 0) return new()
			{
				Code = ResponseCode.Failed,
				Message = "Product variant is out of stock",
				Source = nameof(VendorService)
			};

			variant.Stock--;
			await ProductDb.SaveChangesAsync();
			return new()
			{
				Code = ResponseCode.Success,
				Message = "Product purchase successful",
				Source = nameof(VendorService)
			};
		}
	}
}
