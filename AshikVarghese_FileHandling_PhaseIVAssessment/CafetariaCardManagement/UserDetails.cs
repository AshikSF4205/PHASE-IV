using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafetariaCardManagement
{
    public class UserDetails : PersonalDetails, IBalance
    {
        private static int s_id = 1000;
        private string _userId;
        public string UserID
        {
            get
            {
                return _userId;
            }
        }
        public string WorkStationNumber { get; set; }
        private double _balance;
        public double WalletBalance
        {
            get
            {
                return _balance;
            }
        }
        public UserDetails(string name, string fatherName, long mobile, string mailId, Gender gender, string workStationNumber, double walletBalance)
        {
            s_id++;
            _userId = "SF" + s_id;
            Name = name;
            FatherName = fatherName;
            Gender = gender;
            Mobile = mobile;
            MailID = mailId;
            _balance = walletBalance;
            WorkStationNumber = workStationNumber;
        }

        public UserDetails(string user){
            string[] userArray = user.Split(",");
            s_id=Convert.ToInt32(userArray[0].Remove(0,2));
            _userId = userArray[0];
            Name = userArray[1];
            FatherName= userArray[2];
            Mobile = long.Parse(userArray[3]);
            MailID = userArray[4];
            Gender = Enum.Parse<Gender>(userArray[5],true);
            WorkStationNumber = userArray[6];
            _balance = Convert.ToDouble(userArray[7]);

        }
        public void WalletRecharge(double amount)
        {
            _balance += amount;
        }
        public void DeductAmount(double amount)
        {
            _balance -= amount;
        }
    }

}