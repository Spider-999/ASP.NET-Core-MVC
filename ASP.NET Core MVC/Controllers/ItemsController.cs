using ASP.NET_Core_MVC.Models;
using ASP.NET_Core_MVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_MVC.Controllers
{
    public class ItemsController : Controller
    {
        private readonly Data.AppContext _context;

        #region Constructor
        public ItemsController(Data.AppContext context)
        {
            _context = context;
        }
        #endregion

        #region Actions
        /// <summary>
        /// List all of the items in the database
        /// </summary>
        public async Task<IActionResult> Index()
        {
            // Wait until the task is performed
            var item = await _context.Items.Include(s => s.SerialNumber).ToListAsync();
            // Return the view with the items from the database
            return View(item);
        }

        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Create a new item and add it to the database.
        /// Bind the item we get from the form to the item object.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id","Name","Price")] Item item)
        {
            // Check if the item we get is a valid item.
            if(ModelState.IsValid)
            {
                // Add the item to the database
                _context.Items.Add(item);
                // Save the changes to the database
                await _context.SaveChangesAsync();
                // Redirect the user to the index page after the item is added
                return RedirectToAction(nameof(Index));
            }
            // Otherwise keep the user on the same page
            return View(item);
        }

        /// <summary>
        /// Find an item in the database to edit.
        /// </summary>
        public async Task<IActionResult> Edit(int id)
        {
            // Find the item in the database
            var item = await _context.Items.FirstOrDefaultAsync(item => item.Id == id);
            // Return the view with the item
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id", "Name", "Price")] Item item)
        {
            // Check if the item we get is a valid item.
            if (ModelState.IsValid)
            {
                // Update the item in the database
                _context.Update(item);
                // Save the changes to the database
                await _context.SaveChangesAsync();
                // Redirect the user to the index page after the item is updated
                return RedirectToAction(nameof(Index));
            }
            // Otherwise keep the user on the same page
            return View(item);
        }


        /// <summary>
        /// Find an item in the database to delete.
        /// </summary>
        public async Task<IActionResult> Delete(int id)
        {
            // Find the item in the database
            var item = await _context.Items.FirstOrDefaultAsync(item => item.Id == id);
            // Return the view with the item
            return View(item);
        }

        /// <summary>
        /// Confirm the deletion of an item in the database.
        /// Using ActionName map this function to the delete asp action in the delete.cshtml file.
        /// </summary>
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item != null)
            {
                // Remove the item from the database
                _context.Items.Remove(item);
                // Save the changes to the database
                await _context.SaveChangesAsync();
                // Redirect the user to the index page after the item is deleted
            }

            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
