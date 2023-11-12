﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using QLSV;
using AspNetCoreHero.ToastNotification.Abstractions;
using QLSV.OtpModels;
using QLSV.ModelViews;

namespace DuAnGame.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Dev")]
    [Area("Admin")]
    [Route("admin.html", Name = "AdminIndex")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public INotyfService _notyfService { get; }
        public HomeController(IUnitOfWork unitOfWork, INotyfService notyfService)
        {
            _unitOfWork = unitOfWork;
            _notyfService = notyfService;
        }
        public IActionResult Index()
        {
            var topproduct = _unitOfWork.KhoaHocRepository.GetAll();
            var orders = _unitOfWork.OrderRepository.GetAll().Where(t => t.DatePurchase.Month == DateTime.Now.Month).ToList();
            var sale = _unitOfWork.KhoaHocRepository.GetAll();
            if (topproduct != null)
            {
                ViewBag.Topproduct = topproduct;
            }
            ViewBag.Sale = sale;
            ViewBag.orders = orders;
            return View();
        }
    }
}
