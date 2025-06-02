using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using System.Data;
using System.Security.Claims;
using Core.Models;
using CustomAuh.Helpers;

namespace YourApp.Controllers
{
    [Authorize]
    public class NotebookController : Controller
    {
        private readonly DatabaseHelper _dbHelper;

        public NotebookController(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        // GET: Notebook
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", userId);

            var entries = await _dbHelper.QueryAsync<NotebookEntry>("[dbo].[GetUserNotebookEntries]", parameters);
            return View(entries);
        }

        // GET: Notebook/Create
        public IActionResult Create()
        {
            return View(new NotebookEntryViewModel
            {
                EntryDate = DateTime.Today
            });
        }

        // POST: Notebook/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NotebookEntryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.Name);
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", userId);
                parameters.Add("@EntryDate", model.EntryDate);
                parameters.Add("@Content", model.Content);
                parameters.Add("@Tags", model.Tags);
                parameters.Add("@IsImportant", model.IsImportant);
                parameters.Add("@EntryId", dbType: DbType.Int32, direction: ParameterDirection.Output);

                await _dbHelper.ExecuteAsync("[dbo].[CreateNotebookEntry]", parameters);

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Notebook/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@EntryId", id);

            var entry = await _dbHelper.QuerySingleAsync<NotebookEntryViewModel>(
                "[dbo].[GetNotebookEntryById]", parameters);

            if (entry == null)
            {
                return NotFound();
            }

            return View(entry);
        }

        // POST: Notebook/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, NotebookEntryViewModel model)
        {
            if (id != model.EntryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@EntryId", id);
                parameters.Add("@EntryDate", model.EntryDate);
                parameters.Add("@Content", model.Content);
                parameters.Add("@Tags", model.Tags);
                parameters.Add("@IsImportant", model.IsImportant);

                await _dbHelper.ExecuteAsync("[dbo].[UpdateNotebookEntry]", parameters);

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Notebook/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@EntryId", id);

            var entry = await _dbHelper.QuerySingleAsync<NotebookEntryViewModel>(
                "[dbo].[GetNotebookEntryById]", parameters);

            if (entry == null)
            {
                return NotFound();
            }

            return View(entry);
        }

        // POST: Notebook/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@EntryId", id);

            await _dbHelper.ExecuteAsync("[dbo].[DeleteNotebookEntry]", parameters);

            return RedirectToAction(nameof(Index));
        }

        // GET: Notebook/Search
        public async Task<IActionResult> Search(string query)
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", userId);
            parameters.Add("@SearchQuery", query);

            var results = await _dbHelper.QueryAsync<NotebookEntry>(
                "[dbo].[SearchNotebookEntries]", parameters);

            return View("Index", results);
        }

        // GET: Notebook/DailyReview
        public async Task<IActionResult> DailyReview(DateTime date)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", userId);
            parameters.Add("@EntryDate", date);

            var entries = await _dbHelper.QueryAsync<NotebookEntry>(
                "[dbo].[GetNotebookEntriesByDate]", parameters);

            return View(entries);
        }
    }
}