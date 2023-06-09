﻿using ExpenseManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManager.Controllers
{
    
    public class ExpenseController : Controller
    {
        ExpenseDataAccessLayer objexpense = new ExpenseDataAccessLayer();
   
        public IActionResult Index(string searchString)
        {
            List<ExpenseAttributes> lstEmployee = new List<ExpenseAttributes>();
            lstEmployee = objexpense.GetAllExpenses().ToList();

            return View(lstEmployee);
        }
        public ActionResult AddEditExpenses(int itemId)
        {
            ExpenseAttributes model = new ExpenseAttributes();
            if (itemId > 0)
            {
                model = objexpense.GetExpenseData(itemId);
            }
            return PartialView("_expenseForm", model);
        }
        [HttpPost]
        public ActionResult Create(ExpenseAttributes newExpense)
        {
            if (ModelState.IsValid)
            {
                if (newExpense.ItemId > 0)
                {
                    objexpense.UpdateExpense(newExpense);
                }
                else
                {
                    objexpense.AddExpense(newExpense);
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            objexpense.DeleteExpense(id);
            return RedirectToAction("Index");
        }
        public ActionResult ExpenseSummary()
        {
            return PartialView("_expenseReport");
        }
        public JsonResult GetMonthlyExpense()
        {
            Dictionary<string, decimal> monthlyExpense = objexpense.CalculateMonthlyExpense();
            return new JsonResult(monthlyExpense);
        }
        public JsonResult GetWeeklyExpense()
        {
            Dictionary<string, decimal> weeklyExpense = objexpense.CalculateWeeklyExpense();
            return new JsonResult(weeklyExpense);
        }
    }
}
