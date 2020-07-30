using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PetStore.Services.Interfaces;

using System.Collections.Generic;
using System.Linq;

namespace PetStore.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            var allProducts = productService.GetAll().ToList();

            ICollection<ListAllProductsViewModel> viewModels = this.mapper.Map<List<ListAllProductsViewModel>>(allProducts);

            return View(viewModels);
        }
    }
}
