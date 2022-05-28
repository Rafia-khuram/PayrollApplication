using PayrollApplication.BOL;
using PayrollApplication.DAL;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollApplication.BAL
{
    public class PaymentBAL
    {
        public void AddPaymentStatus(PaymentStatus paymentStatus)
        {
            new PaymentDAL().AddPaymentStatus(paymentStatus);
        }
        public void EditPaymentStatus(PaymentStatus paymentStatus)
        {
            new PaymentDAL().EditPaymentStatus(paymentStatus);
        }
        public void DeletePaymentStatus(int Id)
        {
            new PaymentDAL().DeletePaymentStatus(Id);
        }
        public List<PaymentStatus> GetPaymentStatuses()
        {
            return new PaymentDAL().GetPaymentStatuses();
        }
        public PaymentStatus GetPaymentStatus(int Id)
        {
            return new PaymentDAL().GetPaymentStatus(Id);
        }


        public void AddPayment(Payment payment)
        {
            payment.IssuedDate = DateTime.UtcNow.AddHours(5);
            new PaymentDAL().AddPayment(payment);
        }

        public List<Payment> GetPayment(int Id)
        {
            return new PaymentDAL().GetPayment(Id);
        }
        public void EditPayment(Payment payment)
        {
            new PaymentDAL().EditPayment(payment);
        }
        public void DeletePayment(int Id)
        {
            new PaymentDAL().DeletePayment(Id);
        }
        public List<Payment> GetPayments()
        {
            return new PaymentDAL().GetPayments();
        }
    }
}
