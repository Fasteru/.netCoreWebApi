using NAYABAZAARCLOUD.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAYABAZAARCLOUD.Controllers
{
    
    public class HomeController : Controller
    {

        private ProductRepository productRepository;
        public HomeController()
        {
            productRepository = new ProductRepository();
        }
        // GET: Home
        public ActionResult Index()
        {
            return View(productRepository.GetProducts());
        }
    }
}