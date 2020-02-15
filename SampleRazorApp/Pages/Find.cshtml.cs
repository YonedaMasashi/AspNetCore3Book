using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SampleRazorApp.Models;

namespace SampleRazorApp.Pages
{
    public class FindModel : PageModel
    {
        private readonly SampleRazorAppContext _context;
        public IList<Person> People { get; set; }

        [BindProperty(SupportsGet = true)]
        public int p { get; set; } // ページ番号
        
        [BindProperty(SupportsGet = true)]
        public int n { get; set; } // ページ当たりの個数
        

        public FindModel(SampleRazorAppContext context) {
            _context = context;
        }

        public async Task OnGetAsync() {
            //n = n <= 0 ? 3 : n;
            //People = await _context.Person.OrderBy(m => m.Age)
            //    .Skip(p * n).Take(n).ToArrayAsync();
            IQueryable<Person> result = _context.Person.FromSqlRaw("select * from person order by PersonId desc");
            People = await result.ToListAsync();
        }

        public async Task OnPostAsync(string Find) {
            IQueryable<Person> result = from p in _context.Person where
                p.Name == Find select p;
            People = await result.ToListAsync();
        }
    }
}
