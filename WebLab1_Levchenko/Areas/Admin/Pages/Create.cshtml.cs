using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebLab1_Levchenko.DAL.Data;
using WebLab1_Levchenko.DAL.Entities;

namespace WebLab1_Levchenko.Areas.Admin.Pages
{
    public class CreateModel : PageModel
    {
        private readonly WebLab1_Levchenko.DAL.Data.ApplicationDbContext _context;

        private readonly IWebHostEnvironment _environment;

        public CreateModel(ApplicationDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _environment = env;
        }

        public IActionResult OnGet()
        {
        ViewData["CatsGroupID"] = new SelectList(_context.CatsGroups, "CatsGroupID", "GroupName");
            return Page();
        }

        [BindProperty]
        public Cats Cats { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cats.Add(Cats);
            await _context.SaveChangesAsync();
            if (Image != null)
            {
                var fileName = $"{Cats.CatsID}" +
                Path.GetExtension(Image.FileName);
                Cats.Image = fileName;
                var path = Path.Combine(_environment.WebRootPath, "Images",
                fileName);
                using (var fStream = new FileStream(path, FileMode.Create))
                {
                    await Image.CopyToAsync(fStream);
                }
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
