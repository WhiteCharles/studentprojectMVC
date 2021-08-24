using Microsoft.AspNetCore.Mvc;
using studentprojectMVC.Models;
using studentprojectMVC.Services;
using studentprojectMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentprojectMVC.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IRecordRepository _recordRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IRecordRepository recordRepository, ShoppingCart shoppingCart)
        {
            _recordRepository = recordRepository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(Guid recordId)   // int
        {
            var selectedRecord = _recordRepository.AllRecords.FirstOrDefault(p => p.RecordId == recordId);

            if (selectedRecord != null)
            {
                _shoppingCart.AddToCart(selectedRecord, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(Guid recordId)   //  int
        {
            var selectedRecord = _recordRepository.AllRecords.FirstOrDefault(p => p.RecordId == recordId);

            if (selectedRecord != null)
            {
                _shoppingCart.RemoveFromCart(selectedRecord);
            }
            return RedirectToAction("Index");
        }
    }
}
