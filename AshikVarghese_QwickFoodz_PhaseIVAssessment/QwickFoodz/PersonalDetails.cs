using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{

    // Properties: Name, FatherName, Gender- {Select, Male, Female, Transgender}, Mobile, DOB, MailID, Location

    public enum GenderType { Select, Male, Female, Transgender }

    /// <summary>
    /// Class used to PersonalDetails Datatype creation
    /// </summary>
    public class PersonalDetails
    {
        // property
        /// <summary>
        /// Property name used to get user name
        /// </summary>
        /// <value>string returnType</value>
        public string Name { get; set; }

        // property
        /// <summary>
        /// Property name used to get user's father name
        /// </summary>
        /// <value>string returnType</value>
        public string FatherName { get; set; }


        // property
        /// <summary>
        /// Property name used to get gender of the user
        /// </summary>
        /// <value>GenderType returnType</value>
        public GenderType Gender { get; set; }


        // property
        /// <summary>
        /// Property name used to get mobile number of the user
        /// </summary>
        /// <value>long returnType</value>
        public long Mobile { get; set; }

        // property
        /// <summary>
        /// Property name used to get dob of the user
        /// </summary>
        /// <value>DateTime returnType</value>
        public DateTime DOB { get; set; }

        // property
        /// <summary>
        /// Property name used to get mail id of the user
        /// </summary>
        /// <value>string returnType</value>
        public string MailID { get; set; }

        // property
        /// <summary>
        /// Property name used to get location of the user
        /// </summary>
        /// <value>string returnType</value>
        public string Location { get; set; }

    }

}