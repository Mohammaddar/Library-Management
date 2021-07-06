using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class Member
    {
        public string name;
        public string password;
        public string email;
        public string phoneNumber;
        public byte[] picture;
        public string membershipDate;
        public string lastPaymentDate;
        public string balance;

        public Member(string name, string password, string email, string phoneNumber,
                      byte[] picture, string membershipDate, string lastPaymentDate, string balance)
        {
            this.name = name;
            this.password = password;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.picture = picture;
            this.membershipDate = membershipDate;
            this.lastPaymentDate = lastPaymentDate;
            this.balance = balance;
        }
    }
}
