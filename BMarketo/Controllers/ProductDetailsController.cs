using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BMarketo.Models;
using BMarketo.Services.Repositories;
using BMarketo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BMarketo.Controllers
{
    public class ProductDetailsController : Controller
    {
        private readonly ProductsRepository _productRepository;

        public ProductDetailsController(ProductsRepository productRepository)
        {
            ViewData["Title"] = "Product Details";
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index(int id)
        {
            var productDetailEntity = await _productRepository.GetByIdAsync(id);
            var productImages = await _productRepository.GetProductImagesAsync(id);
            byte[] mainImageBytes = await _productRepository.GetMainImageAsync(id);

            // Fetch random products 
            var randomProducts = await _productRepository.GetRandomProductsAsync(4);

            var smallCards = new List<GridCollectionSmallCardsItemViewModel>();
          
            var viewModel = new ProductDetailViewModel
            {
                ProductDetailTitle = productDetailEntity.Title,
                Description = productDetailEntity.Description!,
                Price = (decimal)productDetailEntity.Price!,
                SKUNumber = productDetailEntity.SKUNumber!,
                MainImage = mainImageBytes,
                Images = productImages.ToList(),
                UnderImage1 = productImages.FirstOrDefault()?.Image,
                UnderImage2 = productImages.Skip(1).FirstOrDefault()?.Image,
                UnderImage3 = productImages.Skip(2).FirstOrDefault()?.Image,
                UnderImage4 = productImages.Skip(3).FirstOrDefault()?.Image,
                SmallCards = new GridCollectionViewModel
                {
                    GridItemsSmall = smallCards
                }
            };

            return View(viewModel);
        }

        private static async Task<List<byte[]>> GetSmallCardsImages(string[] urls)
        {
            var images = new List<byte[]>();
            using var httpClient = new HttpClient();
            foreach (var url in urls)
            {
                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var bytes = await response.Content.ReadAsByteArrayAsync();
                    images.Add(bytes);
                }
            }
            return images;
        }
    }
}
