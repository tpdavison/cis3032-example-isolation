using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Movies.Web.Controllers;

public class ReviewsController : Controller
{
    // GET: /reviews/
    public IActionResult Index()
    {
        return View();
    }

    // GET: /reviews/details/{id}
    public IActionResult Details(int id)
    {
        return View();
    }
}
