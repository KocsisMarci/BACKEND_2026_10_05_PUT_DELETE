using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Numerics;
using System.Xml.Linq;
using WebAppPelda.Models;
using WebAppPelda.Services;
using static System.Formats.Asn1.AsnWriter;

namespace WebAppPelda.Controllers
{
    public class HomeController : Controller
    {

     


        
        
           

        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Sajat()
        {

            List<Customer> vasarlok = new VasarloService().GetAllCustomer();


            return View(vasarlok);
           
        }

        public IActionResult Vasarlo(int id)
        {
            Customer valasztottVasarlo = new VasarloService().GetCustomerById(id);

            return View(valasztottVasarlo);
        }

        [HttpGet] //Itt jelezzük,hogy get lesz
        public IActionResult CreateVasarlo() {
            Customer uresVasarlo=new Customer();
            return View(uresVasarlo);
        }

        [HttpPost] //Itt jelezzük, hogy post lesz
        public IActionResult CreateVasarlo(Customer customer) {
            string result = new VasarloService().PostCustomer(customer);

            TempData["SuccessMessage"] = result;

            return RedirectToAction(nameof(CreateVasarlo));
            

        }


        [HttpGet] //Itt jelezzük,hogy get lesz
        public IActionResult UpdateVasarlo()
        {
            Customer uresVasarlo = new Customer();
            return View(uresVasarlo);
        }

        [HttpPost] //Itt jelezzük, hogy post lesz
        public IActionResult UpdateVasarlo(Customer customer)
        {
            string result = new VasarloService().PutCustomer(customer);

            TempData["SuccessMessage"] = result;

            return RedirectToAction(nameof(UpdateVasarlo));


        }




        [HttpGet] //Itt jelezzük,hogy get lesz
        public IActionResult DeleteVasarlo()
        {
            Customer uresVasarlo = new Customer();
            return View(uresVasarlo);
        }

        [HttpPost] //Itt jelezzük, hogy post lesz
        public IActionResult DeleteVasarlo(Customer customer)
        {
            string result = new VasarloService().DeleteCustomer(customer);

            TempData["SuccessMessage"] = result;

            return RedirectToAction(nameof(DeleteVasarlo));


        }








        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
