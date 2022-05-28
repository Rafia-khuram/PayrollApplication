using PayrollApplication.BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApplication.DAL
{
    public class PaymentDAL
    {
        PayrollContext db = new PayrollContext();
        // payment status
        public List<PaymentStatus> GetPaymentStatuses()
        {
            return db.PaymentStatuses.ToList();
        }

        public PaymentStatus GetPaymentStatus(int id)
        {
            return db.PaymentStatuses.Where(x => x.Id == id).FirstOrDefault();
        }

        public void AddPaymentStatus(PaymentStatus paymentStatus)
        {
            db.PaymentStatuses.Add(paymentStatus);
            db.SaveChanges();
        }

        public void DeletePaymentStatus(int id)
        {
            db.PaymentStatuses.Remove(db.PaymentStatuses.Find(id));
            db.SaveChanges();
        }

        public void EditPaymentStatus(PaymentStatus paymentStatus)
        {
            var dbPaymentStatus = db.Roles.Where(x => x.Id == paymentStatus.Id).FirstOrDefault();
            if (dbPaymentStatus != null)
            {
                if (!String.IsNullOrEmpty(paymentStatus.Name))
                {
                    dbPaymentStatus.Name = paymentStatus.Name;
                }
            }
            db.SaveChanges();
        }

        /// /////////////////////////////////////

        public List<Payment> GetPayments()
        {
            return db.Payments.ToList();
        }
        public List<Payment> GetPayment(int id)
        {
            return db.Payments.Where(x => x.Salary.EmployeeId == id).ToList();
        }

        public void AddPayment(Payment payment)
        {
            db.Payments.Add(payment);
            db.SaveChanges();
        }

        public void DeletePayment(int id)
        {
            db.Payments.Remove(db.Payments.Find(id));
            db.SaveChanges();
        }
        public void EditPayment(Payment payment)
        {
            var dbPayment = db.Payments.Where(x => x.Id == payment.Id).FirstOrDefault();
            if (dbPayment != null)
            {

                if (!String.IsNullOrEmpty(payment.PaymentStatusId.ToString()))
                {
                    dbPayment.PaymentStatusId = payment.PaymentStatusId;

                }
                if (!String.IsNullOrEmpty(payment.SalaryId.ToString()))
                {
                    dbPayment.SalaryId = payment.SalaryId;

                }


            }
            db.SaveChanges();
        }

    }
}
