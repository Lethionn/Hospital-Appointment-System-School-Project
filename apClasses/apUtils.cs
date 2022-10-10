using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace HospitalApp.apClasses
{
    class apUtils
    {
    }

    public enum EUserType
    {
        Admin=0,
        Doctor=1,
        Assistant=2,
        Operator=3

    }

    

    public class CAppUser
    {
        private int _UserId;
        private string _UserName;
        private string _Password;

        private string _PersonName;
        private string _PersonSurname;
        private int _PersonID;

        EUserType _UType;

        public int UserId { get => _UserId;  }
        public string UserName { get => _UserName; }
        public string Password { get => _Password; }
        public EUserType UType { get => _UType;}
        public string PersonName { get => _PersonName;  }
        public string PersonSurname { get => _PersonSurname;}
        public int PersonID { get => _PersonID;  }

        public CAppUser (DataRow r)
        {
            _UserId = Convert.ToInt32(r["USID"]);
            _UserName = r["UName"].ToString();
            _Password = r["Passw"].ToString();
            _UType = (EUserType)r["UType"];

        }


        public void SetInterestPerson(string vPerName,string vPerSurname,int vPersonID)
        {
            _PersonName = vPerName;
            _PersonSurname = vPerSurname;
            _PersonID = vPersonID;


        }

    }
}
