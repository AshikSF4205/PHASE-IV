using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{

    // Field: _balance
    // Properties: CustomerID, WalletBalance


    /// <summary>
    /// Class used to CustomerDetails Datatype creation
    /// </summary>
    public class CustomerDetails : PersonalDetails, IBalance
    {
        // Field
        /// <summary>
        /// Static field for auto-incrementing the Customer Id <see cref="CustomerDetails"/> class
        /// </summary>
        private static int s_customerId = 1000;

        /// <summary>
        /// field for return the balance <see cref="CustomerDetails"/> class
        /// </summary>
        private double _balance;

        // property
        /// <summary>
        /// Property name used to get Customer ID
        /// </summary>
        /// <value>string returnType</value>
        public string CustomerID { get; }

        // property
        /// <summary>
        /// Property name used to get wallet balance
        /// </summary>
        /// <value>double returnType</value>
        public double WalletBalance
        {
            get
            {
                return _balance;
            }
        }

        // constructor
        /// <summary>
        /// Constructor used to get Customer details
        /// </summary>
        /// <param name="name"></param>
        /// <param name="fatherName"></param>
        /// <param name="gender"></param>
        /// <param name="mobile"></param>
        /// <param name="dob"></param>
        /// <param name="mailId"></param>
        /// <param name="location"></param>
        /// <param name="walletBalance"></param>
        public CustomerDetails(string name, string fatherName, GenderType gender, long mobile, DateTime dob, string mailId, string location, double walletBalance)
        {
            CustomerID = "CID" + (++s_customerId);
            Name = name;
            FatherName = fatherName;
            Gender = gender;
            Mobile = mobile;
            DOB = dob;
            MailID = mailId;
            Location = location;
            _balance = walletBalance;
        }

        // Method for recharging the wallet
        /// <summary>
        /// Method used to recharge the wallet
        /// </summary>
        /// <param name="rechargeAmount"></param>
        public void WalletRecharge(double rechargeAmount)
        {
            _balance += rechargeAmount;
        }
        
        // Method for deducting amount from wallet
        /// <summary>
        /// Method used to deduct the balance
        /// </summary>
        /// <param name="deductAmount"></param>
        public void DeductBalance(double deductAmount)
        {
            _balance -= deductAmount;
        }
    }

}