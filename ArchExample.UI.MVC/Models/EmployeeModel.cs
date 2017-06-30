namespace ArchExample.UI.MVC.Models
{
    public class EmployeeModel
    {
        public string CI { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal HourlyPayment { get; set; }

        public decimal TotalPayment { get; set; }

        public int HoursWorked { get; set; }

        public string HourlyPaymentFormatted
        {
            get { return this.HourlyPayment.ToString("F"); }
        }

        public string TotalPaymentFormatted
        {
            get { return this.TotalPayment.ToString("F"); }
        }
    }
}