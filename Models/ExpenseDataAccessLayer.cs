using Microsoft.EntityFrameworkCore;

namespace ExpenseManager.Models
{
    public class ExpenseDataAccessLayer
    {
        ExpenseDbContext db = new ExpenseDbContext();
        public IEnumerable<ExpenseAttributes> GetAllExpenses()
        {
            try
            {
                return db.ExpenseReport.ToList();
            }
            catch
            {
                throw;
            }
        }

        //To Add new Expense record       
        public void AddExpense(ExpenseAttributes expense)
        {
            try
            {
                db.ExpenseReport.Add(expense);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        //To Update the records of a particluar expense  
        public int UpdateExpense(ExpenseAttributes expense)
        {
            try
            {
                db.Entry(expense).State = EntityState.Modified;
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }
        //Get the data for a particular expense  
        public ExpenseAttributes GetExpenseData(int id)
        {
            try
            {
                ExpenseAttributes expense = db.ExpenseReport.Find(id);
                return expense;
            }
            catch
            {
                throw;
            }
        }
        //To Delete the record of a particular expense  
        public void DeleteExpense(int id)
        {
            try
            {
                ExpenseAttributes emp = db.ExpenseReport.Find(id);
                db.ExpenseReport.Remove(emp);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        // To calculate last six months expense
        public Dictionary<string, decimal> CalculateMonthlyExpense()
        {
            ExpenseDataAccessLayer objexpense = new ExpenseDataAccessLayer();
            List<ExpenseAttributes> lstEmployee = new List<ExpenseAttributes>();
            Dictionary<string, decimal> dictMonthlySum = new Dictionary<string, decimal>();
            decimal foodSum = db.ExpenseReport.Where
                (cat => cat.Category == "Food" && (cat.ExpenseDate > DateTime.Now.AddMonths(-7)))
                .Select(cat => cat.Amount)
                .Sum();
            decimal shoppingSum = db.ExpenseReport.Where
               (cat => cat.Category == "Shopping" && (cat.ExpenseDate > DateTime.Now.AddMonths(-7)))
               .Select(cat => cat.Amount)
               .Sum();
            decimal travelSum = db.ExpenseReport.Where
               (cat => cat.Category == "Travel" && (cat.ExpenseDate > DateTime.Now.AddMonths(-7)))
               .Select(cat => cat.Amount)
               .Sum();
            decimal healthSum = db.ExpenseReport.Where
               (cat => cat.Category == "Health" && (cat.ExpenseDate > DateTime.Now.AddMonths(-7)))
               .Select(cat => cat.Amount)
               .Sum();
            dictMonthlySum.Add("Food", foodSum);
            dictMonthlySum.Add("Shopping", shoppingSum);
            dictMonthlySum.Add("Travel", travelSum);
            dictMonthlySum.Add("Health", healthSum);
            return dictMonthlySum;
        }
        // To calculate last four weeks expense
        public Dictionary<string, decimal> CalculateWeeklyExpense()
        {
            ExpenseDataAccessLayer objexpense = new ExpenseDataAccessLayer();
            List<ExpenseAttributes> lstEmployee = new List<ExpenseAttributes>();
            Dictionary<string, decimal> dictWeeklySum = new Dictionary<string, decimal>();
            decimal foodSum = db.ExpenseReport.Where
                (cat => cat.Category == "Food" && (cat.ExpenseDate > DateTime.Now.AddDays(-7)))
                .Select(cat => cat.Amount)
                .Sum();
            decimal shoppingSum = db.ExpenseReport.Where
               (cat => cat.Category == "Shopping" && (cat.ExpenseDate > DateTime.Now.AddDays(-28)))
               .Select(cat => cat.Amount)
               .Sum();
            decimal travelSum = db.ExpenseReport.Where
               (cat => cat.Category == "Travel" && (cat.ExpenseDate > DateTime.Now.AddDays(-28)))
               .Select(cat => cat.Amount)
               .Sum();
            decimal healthSum = db.ExpenseReport.Where
               (cat => cat.Category == "Health" && (cat.ExpenseDate > DateTime.Now.AddDays(-28)))
               .Select(cat => cat.Amount)
               .Sum();
            dictWeeklySum.Add("Food", foodSum);
            dictWeeklySum.Add("Shopping", shoppingSum);
            dictWeeklySum.Add("Travel", travelSum);
            dictWeeklySum.Add("Health", healthSum);
            return dictWeeklySum;
        }
    }
}
